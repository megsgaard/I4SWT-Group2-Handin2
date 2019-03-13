using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConsoleViewer: IConditionViewer
    {
        private List<TrackInfo> TrackList;

        //public event EventHandler<List<TrackInfo>> RecievedEvent;

        public void PrintCurrentCondition()
        {
            foreach (var track in TrackList)
            {
                Console.WriteLine("New aircraft comming in!");
                Console.WriteLine("Tag: " + track.Tag);
                Console.WriteLine("Altitude: " + track.Altitude);
                Console.WriteLine("Time: " + track.DataTime);
                Console.WriteLine("Compass Course: " + track.CompassCourse);
                Console.WriteLine("Velocity: " + track.Velocity);
                Console.WriteLine("X-coor: " + track.Xcoor);
                Console.WriteLine("Y-coor: " + track.Ycoor);
            }
        }
    }
}
