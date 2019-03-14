using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class DataCalculator:IDataCalculator
   {
      public List<TrackInfo> NewTrackList { get; private set; }
      public List<TrackInfo> OldTrackList { get; private set; }

      public event EventHandler<TracksEventArgs> CalculateEvent; //oprette det event der skal sendes videre. 

      public DataCalculator(ITrackReciever trackReciever) //i parentesen skrives det interface hvor man modtager event fra.
      {
         trackReciever.TracksInASEvent += RecieveTrackEvent; //første del er fra parentesen ovenfor, efter += skrives den metode i denne klasse, som kaldes, når eventet sker. 
         OldTrackList = new List<TrackInfo>();
         NewTrackList = new List<TrackInfo>();
      }
      public void DoCalculations()
      {
         CalculateCourse();
         CalculateVelocity();
      }

      public void CalculateVelocity()
      {
         foreach (var track in OldTrackList)
         {
            for (int i = 0; i < NewTrackList.Count; i++)
            {
               if (track.Tag == NewTrackList[i].Tag)
               {
                  //Calculate velocity
                  int timeTraveled = NewTrackList[i].DataTime.Subtract(track.DataTime).Milliseconds;
                  double timeTraveled_sec = (double)timeTraveled / 100;
                  double deltaY = NewTrackList[i].Ycoor - track.Ycoor;
                  double deltaX = NewTrackList[i].Xcoor - track.Xcoor;
                  double distanceTraveled = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                  NewTrackList[i].Velocity = distanceTraveled / timeTraveled;

               }
            }
         }
      }

      public void CalculateCourse()
      {
         foreach (var track in OldTrackList)
         {
            for (int i = 0; i < NewTrackList.Count; i++)
            {
               if (track.Tag == NewTrackList[i].Tag)
               {
                  //Calculate course
                  double deltaY = NewTrackList[i].Ycoor - track.Ycoor;
                  double deltaX = NewTrackList[i].Xcoor - track.Xcoor;
                  double theta_rad = Math.Atan(deltaY / deltaX);
                  double theta_degrees = theta_rad * 180 / Math.PI;

                  if (deltaY < 0 && deltaX>0)
                  {
                     NewTrackList[i].CompassCourse = (270 - (int)theta_degrees);
                  }
                  else if (deltaY <= 0 && deltaX <= 0)
                  {
                     NewTrackList[i].CompassCourse = (270 - Math.Abs((int)theta_degrees));
                  }
                  else
                  {
                     NewTrackList[i].CompassCourse = (90 - (int)theta_degrees);
                  }
               }
            }
         }
      }

      public void RecieveTrackEvent(object sender, TracksEventArgs e) //Når metoden kaldes fås et objekt e af typen TracksEventArgs
      {
         OldTrackList=NewTrackList;
         NewTrackList = e.TrackInfos; //den nye liste skal sættes lig med den liste der er sendt over med eventet. 
         DoCalculations();
         TrackCalcDoneEvent(new TracksEventArgs {TrackInfos = NewTrackList}); //kalde metoden som raiser det nye event der skal sendes afsted. 
      }

      protected virtual void TrackCalcDoneEvent(TracksEventArgs e)
      {
         CalculateEvent?.Invoke(this,e);
      }
   }
}
