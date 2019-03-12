using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class DataCalculator:IDataCalculator
   {
      public event EventHandler<List<TrackInfo>> CalculateEvent;
      public void DoCalculations()
      {
         CompareLists();
         CalculateCourse();
         CalculateVelocity();
      }

      public void CalculateVelocity()
      {
         throw new NotImplementedException();
      }

      public void CalculateCourse()
      {
         throw new NotImplementedException();
      }

      public void CompareLists()
      {
         throw new NotImplementedException();
      }

      public void RecieveTrackEvent(object sender, TrackInfo e)
      {
         throw new NotImplementedException();
      }
   }
}
