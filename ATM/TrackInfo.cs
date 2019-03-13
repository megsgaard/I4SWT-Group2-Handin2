using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class TrackInfo
   {
       public string Tag { get; private set; }
       public int Xcoor { get; private set; }
       public int Ycoor { get; private set; }
       public int Altitude { get; private set; }
       public DateTime DataTime { get; private set; }
       public int CompassCourse { get; set; }
       public int Velocity { get; set; }
    }
}
