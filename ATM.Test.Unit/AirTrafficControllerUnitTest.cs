using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    public class AirTrafficControllerUnitTest
    {
        private AirTrafficController _uut;
        private IConditionViewer _conditionViewer;
        private ISeperationChecker _seperationChecker;
        private IDataCalculator _dataCalculator;

        [SetUp]
        public void SetUp()
        {
            _conditionViewer = Substitute.For<IConditionViewer>();
            _seperationChecker = Substitute.For<ISeperationChecker>();
            _dataCalculator = Substitute.For<IDataCalculator>();

            _uut = new AirTrafficController(_dataCalculator);
        }


        [Test]
        public void Print_CallingMethod_PrintCurrentConditionWasCalled()
        {
            TrackInfo _track1 = new TrackInfo();

            List<TrackInfo> trackList = new List<TrackInfo>();
            trackList.Add(_track1);

            _dataCalculator.CalculateEvent += Raise.EventWith(new TracksEventArgs { TrackInfos = trackList });

            _uut.Print(_conditionViewer);
            _conditionViewer.Received(1).PrintCurrentCondition(trackList);

        }

        [Test]
        public void InvestigateInfo_CallingMethod_CheckSeperationWasCalled()
        {
            TrackInfo _track1 = new TrackInfo();

            List<TrackInfo> trackList = new List<TrackInfo>();
            trackList.Add(_track1);

            _dataCalculator.CalculateEvent += Raise.EventWith(new TracksEventArgs { TrackInfos = trackList });

            _uut.InvestigateInfo(_seperationChecker);
            _seperationChecker.Received(1).CheckSeperation(trackList);
        }

        [Test]
        public void RecieveCalculatedEvent_EventFired_TrackListIsUpdated()
        {
            TrackInfo _track1 = new TrackInfo();
            
            List<TrackInfo> trackList = new List<TrackInfo>();
            trackList.Add(_track1);

            _dataCalculator.CalculateEvent += Raise.EventWith(new TracksEventArgs {TrackInfos = trackList});
            Assert.That(_uut.TrackList, Is.EqualTo(trackList));
        }

    }
}
