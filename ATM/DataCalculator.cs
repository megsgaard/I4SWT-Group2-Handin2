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
      private List<TrackInfo> TracksInBothLists;

      public event EventHandler<List<TrackInfo>> CalculateEvent;

      public DataCalculator(ITrackReciever trackReciever)
      {
         trackReciever.TracksInASEvent += RecieveTrackEvent;
      }
      public void DoCalculations()
      {
         CompareLists();
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
         throw new NotImplementedException();
      }

      public void CompareLists()
      {
         int count = 0;
         foreach (var track in OldTrackList)
         {
            for (int i = count; i < OldTrackList.Count; i++)
            {
               if (track.Tag==NewTrackList[i].Tag)
               {
                  TracksInBothLists.Add(NewTrackList[i]);
               }
            }
         }
      }

      public void RecieveTrackEvent(object sender, List<TrackInfo> e)
      {
         OldTrackList=NewTrackList;
         NewTrackList = e;
         DoCalculations();
         CalculateEvent?.Invoke(this,NewTrackList);
      }
   }
}
