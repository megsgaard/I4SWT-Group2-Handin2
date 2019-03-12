using System;

namespace ATM
{
    public class TransponderReciever : ITransponderReciever
    {
       public event EventHandler<ITrackReciever> NewTransponderRecieverEvent;
       public void DataReady(object RawTransponderDataEventArgs)
       {
          throw new NotImplementedException();
       }
    }
}