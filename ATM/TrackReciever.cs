using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class TrackReciever : ITrackReciever
    {
        private ITransponderReceiver reciever;
        public event EventHandler<TracksEventArgs> TracksInASEvent;

        public TrackReciever(ITransponderReceiver reciever)
        {
            this.reciever = reciever;

            this.reciever.TransponderDataReady += Reciever_TransponderDataReady;
        }

        private void Reciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var trackInfoList = new List<TrackInfo>();
            var trackEventArgs = new TracksEventArgs();
            foreach (var data in e.TransponderData)
            {
                var dataList = new List<string>();
                var trackInfo = new TrackInfo();
                dataList = data.Split(';').ToList();

                var xcoordinate = Convert.ToInt32(dataList[1]);
                var ycoordinate = Convert.ToInt32(dataList[2]);

                if (xcoordinate < 80000 && ycoordinate < 80000)
                {
                    trackInfo.Xcoor = xcoordinate;
                    trackInfo.Ycoor = ycoordinate;
                    trackInfo.Tag = dataList[0];
                    trackInfo.Altitude = Convert.ToInt32(dataList[3]);
                    trackInfo.DataTime = DateTime.ParseExact(
                        dataList[4],
                        "yyyyMMddHHmmssfff",
                        null);

                    trackInfoList.Add(trackInfo);
                }
            }
            trackEventArgs.TrackInfos = trackInfoList;
            TracksInASEvent?.Invoke(this, trackEventArgs);
        }
    }
}
