using System;
using System.Collections.Generic;

namespace ATM
{
    public class SeperationChecker : ISeperationChecker
    {
        private int counter;
        public string SeperationMessage { get; set; }

        public void CheckSeperation(List<TrackInfo> trackInfoList)
        {
            counter = 1;
            foreach (var item in trackInfoList)
            {
                for (int i = counter; i < trackInfoList.Count; i++)
                {
                    var altitudeDifference = Math.Abs(item.Altitude - trackInfoList[i].Altitude);
                    var xcoordinateDifference = Math.Abs(item.Xcoor - trackInfoList[i].Xcoor);
                    var ycoordinateDifference = Math.Abs(item.Ycoor - trackInfoList[i].Ycoor);

                    if (altitudeDifference < 300)
                    {
                        if (xcoordinateDifference < 5000 || ycoordinateDifference < 5000)
                        {
                            SeperationMessage = $"{item.Tag} and {trackInfoList[i].Tag} are about to crash";
                        }
                    }
                }
                counter++;
            }
        }
    }
}