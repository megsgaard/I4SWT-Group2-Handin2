using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class TracksEventArgs : EventArgs
   {
      public List<TrackInfo> TrackInfos { get; set; }
   }
}
