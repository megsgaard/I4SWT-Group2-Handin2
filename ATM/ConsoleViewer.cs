using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConsoleViewer: IConditionViewer
    {
        public string TrackMessage { get; set; }

        //public event EventHandler<List<TrackInfo>> RecievedEvent;

        public void PrintCurrentCondition(List<TrackInfo> TrackList)
        {
            foreach (var track in TrackList)
            {
                TrackMessage = ("New aircraft comming in!\nTag: " + track.Tag+ "\nAltitude: " + track.Altitude+ "\nTime: " + track.DataTime+ "\nCompass Course: "+track.CompassCourse + "\nVelocity: " + track.Velocity + "\nX-coor: " + track.Xcoor + "\nY-coor: " +track.Ycoor);
                Console.WriteLine(TrackMessage);
            }
        }
    }
}
