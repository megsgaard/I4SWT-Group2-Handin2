using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public interface IConditionViewer
   {
       //event EventHandler<List<TrackInfo>> RecievedEvent; 
       void PrintCurrentCondition(List<TrackInfo> TrackList);
   }
}
