using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace ATM.Test.Unit
{
    class TrackRecieverUnitTests
    {
        private ITransponderReceiver _fakeTransponderReceiver;
        private TrackReciever _uut;

        [SetUp]
        public void Setup()
        {
            _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            _uut = new TrackReciever(_fakeTransponderReceiver);
        }

        [Test]
        public void TransponderDataReady_EventContainsThreeElements_ThreeTrackInfoObjectsAreCreated()
        {
            List<string> testTransponderData = new List<string>();
            testTransponderData.Add("ATR423;39045;12932;14000;20151006213456789");
            testTransponderData.Add("BCD123;10005;55890;12000;20151006213456789");
            testTransponderData.Add("XYZ987;25059;75654;4000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testTransponderData));

            Assert.That(_uut.trackEventArgs.TrackInfos.Count, Is.EqualTo(3));
        }

        [Test]
        public void TransponderDataReady_TwoOutOfThreeElementsAreInsideTheSurveilledAirspace_TwoTrackInfoObjectsAreCreated()
        {
            List<string> testTransponderData = new List<string>();
            testTransponderData.Add("BCD123;90005;55890;12000;20151006213456789"); //outside the surveilled airspace
            testTransponderData.Add("ATR423;39045;12932;14000;20151006213456789");
            testTransponderData.Add("XYZ987;25059;75654;4000;20151006213456789");

            _fakeTransponderReceiver.TransponderDataReady
                += Raise.EventWith(this, new RawTransponderDataEventArgs(testTransponderData));

            Assert.That(_uut.trackEventArgs.TrackInfos.Count, Is.EqualTo(2));
        }
    }
}
