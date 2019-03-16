using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;


namespace ATM.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            var trackReciever = new TrackReciever(receiver);
            var dataCalculator = new DataCalculator(trackReciever);
            var controller = new AirTrafficController(dataCalculator);

            while (true)
            {

            }
        }
    }
}
