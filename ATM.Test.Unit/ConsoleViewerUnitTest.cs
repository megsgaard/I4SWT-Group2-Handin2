using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    class ConsoleViewerUnitTest
    {
        private ConsoleViewer _uut;
        private TrackInfo _trackInfo;

        [SetUp]
        public void SetUp()
        {
            _uut = new ConsoleViewer();
            _trackInfo = new TrackInfo();

        }

        [Test]
        public void PrintCurrentCondition_DataAvailable_MessageNotNull()
        {
            var data = new TrackInfo() { Altitude = 10,CompassCourse = 5,DataTime = '10'}
        }

    }
}
