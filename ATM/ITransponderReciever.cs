using System;

namespace ATM
{
    public interface ITransponderReciever
    {
        event EventHandler<ITrackReciever> NewTransponderRecieverEvent;

        void DataReady(object RawTransponderDataEventArgs);


    }
}
