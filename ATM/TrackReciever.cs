using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class TrackReciever
    {
        private List<TrackInfo> trackInfoList;
        private ITransponderReceiver reciever;

        public TrackReciever(ITransponderReceiver reciever)
        {
            this.reciever = reciever;

            this.reciever.TransponderDataReady += Reciever_TransponderDataReady;
        }

        private void Reciever_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}
