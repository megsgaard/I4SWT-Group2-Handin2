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
       public string Tag { get; set; }
       public int Xcoor { get; set; }
       public int Ycoor { get; set; }
       public int Altitude { get; set; }
       public DateTime DataTime { get; set; }
       public int CompassCourse { get; set; }
       public double Velocity { get; set; }
    }
}
