using System;

namespace ATM
{
    interface ITransponderReciever
    {
        event EventHandler<ITrackReciever> NewTransponderRecieverEvent;

        void DataReady(object RawTransponderDataEventArgs);


    }
}
