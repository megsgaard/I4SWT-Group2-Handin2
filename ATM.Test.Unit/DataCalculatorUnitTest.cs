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
   public class DataCalculatorUnitTest
   {
      private DataCalculator uut;
      private ITrackReciever _trackReciever;

      [SetUp]
      public void SetUp()
      {
         _trackReciever = Substitute.For<ITrackReciever>();
         uut= new DataCalculator(_trackReciever);

      }

      [Test]
      public void RecieveTrackEvent_EventFired_NewTrackListIsUpdated()
      {
         //TrackInfo _track1 = new TrackInfo()
         //{
         //   Tag = "FHJ"
         //};
         List<TrackInfo> trackList = new List<TrackInfo>();
         trackList.Add(new TrackInfo() { Tag="FHJ"});
         _trackReciever.TracksInASEvent += Raise.EventWith(new TracksEventArgs {TrackInfos = trackList});
         Assert.That(uut.NewTrackList,Is.EqualTo(trackList));
      }

      [TestCase(1,1,3,3,45)]
      public void CalculateCourse_FirstPointCoorIsX1AndY1SecondPointCoorIsX2AndY2_CourseIsCC(int X1, int Y1, int X2,
         int Y2, int CC)
      {
         List<TrackInfo> trackList = new List<TrackInfo>();
         trackList.Add(new TrackInfo(){Xcoor = 1,Ycoor = 1});
         _trackReciever.TracksInASEvent += Raise.EventWith(new TracksEventArgs { TrackInfos = trackList });
      }
   }
}
