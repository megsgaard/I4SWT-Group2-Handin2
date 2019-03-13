using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ATM.Test.Unit
{
    [TestFixture]
    class SeperationCheckerUnitTests
    {
        private SeperationChecker _uut;
        private List<TrackInfo> _trackInfoList;

        [SetUp]
        public void Setup()
        {
            _uut = new SeperationChecker();
            _trackInfoList = new List<TrackInfo>();
        }

        [Test]
        public void CheckSeperation_SeperationConditionPresent_SeperationMessageNotNull()
        {
            var plane1 = new TrackInfo() { Altitude = 1000, Xcoor = 70000, Ycoor = 60000 };
            var plane2 = new TrackInfo() { Altitude = 900, Xcoor = 69000, Ycoor = 61000 };
            _trackInfoList.Add(plane1);
            _trackInfoList.Add(plane2);

            _uut.CheckSeperation(_trackInfoList);

            Assert.That(_uut.SeperationMessage, Is.Not.Null);
        }

        [Test]
        public void CheckSeperation_SeperationConditionNotPresent_SeperationMessageIsNull()
        {
            var plane1 = new TrackInfo() { Altitude = 5000, Xcoor = 70000, Ycoor = 60000 };
            var plane2 = new TrackInfo() { Altitude = 900, Xcoor = 69000, Ycoor = 61000 };
            _trackInfoList.Add(plane1);
            _trackInfoList.Add(plane2);

            _uut.CheckSeperation(_trackInfoList);

            Assert.That(_uut.SeperationMessage, Is.Null);
        }
    }
}
