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
        private List<TrackInfo> _trackInfo;

        [SetUp]
        public void SetUp()
        {
            _uut = new ConsoleViewer();
            _trackInfo = new List<TrackInfo>();

        }

        [Test]
        public void PrintCurrentCondition_DataAvailable_MessageNotNull()
        {
            var data = new TrackInfo() {Altitude = 1000, CompassCourse = 5, DataTime = new DateTime(2011-1-2-12-14), Tag = "Flight 1", Velocity = 1000, Xcoor = 3, Ycoor = 7};
            _trackInfo.Add(data);

            _uut.PrintCurrentCondition(_trackInfo);

            Assert.That(_uut.TrackMessage,Is.Not.Null);
        }

        [Test]
        public void PrintCurrentCondition_DataNotAvailable_MessageNull()
        {
            var data = new TrackInfo();

            _uut.PrintCurrentCondition(_trackInfo);

            Assert.That(_uut.TrackMessage, Is.Null);
        }

    }
}
