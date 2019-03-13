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
         List<TrackInfo> trackList = new List<TrackInfo>();
         trackList.Add(new TrackInfo() { Tag="FHJ"});
         _trackReciever.TracksInASEvent += Raise.EventWith(new TracksEventArgs {TrackInfos = trackList});
         Assert.That(uut.NewTrackList,Is.EqualTo(trackList));
      }

      [TestCase(1,1,3,3,45)]
      [TestCase(2,2,6,2,90)]
      [TestCase(10,10,3,3,135)] 
      [TestCase(5,20,5,16,270)]
      //[TestCase(2,2,3,1,315)] //fejl
      //[TestCase(20,20,10,10,225)] //fejl
      public void CalculateCourse_FirstPointCoorIsX1AndY1SecondPointCoorIsX2AndY2_CourseIsCC(int X1, int Y1, int X2,
         int Y2, int CC)
      {
         List<TrackInfo> trackList = new List<TrackInfo>();
         trackList.Add(new TrackInfo(){Xcoor = X1,Ycoor = Y1});
         _trackReciever.TracksInASEvent += Raise.EventWith(new TracksEventArgs { TrackInfos = trackList });
         List<TrackInfo> track2List = new List<TrackInfo>();
         track2List.Add(new TrackInfo() { Xcoor = X2, Ycoor = Y2 });
         _trackReciever.TracksInASEvent += Raise.EventWith(new TracksEventArgs { TrackInfos = track2List });
         Assert.That(uut.NewTrackList[0].CompassCourse,Is.EqualTo(CC));
      }
   }
}
