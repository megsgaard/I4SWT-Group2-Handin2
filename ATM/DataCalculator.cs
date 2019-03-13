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
         int count = 0;
         foreach (var track in OldTrackList)
         {
            for (int i = count; i < OldTrackList.Count; i++)
            {
               if (track.Tag == NewTrackList[i].Tag)
               {
                  //Calculate velocity
               }
            }
         }


         //sådan kan man få tidsforskellen ud i millisekunder
         int timeTravelled = NewTrackList[1].DataTime.Subtract(OldTrackList[1].DataTime).Milliseconds;

         //velocity skal være i meter i sek.

      }

      public void CalculateCourse()
      {
         int count = 0;
         foreach (var track in OldTrackList)
         {
            for (int i = count; i < OldTrackList.Count; i++)
            {
               if (track.Tag == NewTrackList[i].Tag)
               {
                  //Calculate velocity
               }
            }
         }
      }

      public void RecieveTrackEvent(object sender, TracksEventArgs e) //Når metoden kaldes fås et objekt e af typen TracksEventArgs
      {
         OldTrackList=NewTrackList;
         NewTrackList = e.TrackInfos; //den nye liste skal sættes lig med den liste der er sendt over med eventet. 
         //DoCalculations();
         TrackCalcDoneEvent(new TracksEventArgs {TrackInfos = NewTrackList}); //kalde metoden som raiser det nye event der skal sendes afsted. 
      }

      protected virtual void TrackCalcDoneEvent(TracksEventArgs e)
      {
         CalculateEvent?.Invoke(this,e);
      }
   }
}
