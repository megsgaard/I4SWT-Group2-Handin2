using System;
using System.Collections.Generic;
using System.Globalization;
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
      private TracksEventArgs _recievedEventArgs;

      [SetUp]
      public void SetUp()
      {
         _trackReciever = Substitute.For<ITrackReciever>();
         uut= new DataCalculator(_trackReciever);
         _recievedEventArgs = null;
         uut.CalculateEvent += (sender, args)=>{
            _recievedEventArgs = args;
         }
         ;

      }

      [Test]
      public void RecieveTrackEvent_EventRecievedFired_NewTrackListIsUpdated()
      {
         List<TrackInfo> trackList = new List<TrackInfo>();
         trackList.Add(new TrackInfo() { Tag="FHJ"});
         _trackReciever.TracksInASEvent += Raise.EventWith(new TracksEventArgs {TrackInfos = trackList});
         Assert.That(uut.NewTrackList,Is.EqualTo(trackList));
      }

      [Test]
      public void DoneCalculations_CalculationsFinished_EventFired()
      {
         List<TrackInfo> trackList = new List<TrackInfo>();
         trackList.Add(new TrackInfo() { Tag = "FHJ" });
         _trackReciever.TracksInASEvent += Raise.EventWith(new TracksEventArgs { TrackInfos = trackList });
         Assert.That(_recievedEventArgs,Is.Not.Null);
      }

      [TestCase(1000,1000,3000,3000,45)]
      [TestCase(3,1,1,3,135)]
      [TestCase(3,3,1,1,225)]
      [TestCase(1,3,3,1,315)]
      [TestCase(1,1,1,3,0)]
      [TestCase(1,3,1,1,180)] 
      [TestCase(1,1,3,1,90)]
      [TestCase(3,1,1,1,270)] 
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

      [TestCase(1,1,"14-03-2019 11:00:00:000",1001,1,"14-03-2019 11:00:05:000",200)]
      [TestCase(1,1000,"20-12-2010 07:00:00:100",3,1040, "20-12-2010 07:00:00:200",400.5)]
      [TestCase(1000, 1000, "14-03-2019 11:00:00:000", 31000, 41000, "14-03-2019 11:04:10:000", 200)]
      [TestCase(1000, 1000, "14-03-2019 11:00:00:000", 4000, 5000, "14-03-2019 11:00:20:000", 250)]
      public void CalculateVelocity_FirstPointCoorIsX1AndY1AndDateTimeIsD1SecondPointCoorIsX2AndY2AndDateTimeIsD2_VelocityIsCalculatedToV(
         int X1, int Y1, string D1, int X2, int Y2, string D2, double V)
      {
         List<TrackInfo> trackList = new List<TrackInfo>();
         trackList.Add(new TrackInfo() { Xcoor = X1, Ycoor = Y1, DataTime = DateTime.ParseExact(D1, "dd-MM-yyyy hh:mm:ss:fff",
            CultureInfo.InvariantCulture)});
         _trackReciever.TracksInASEvent += Raise.EventWith(new TracksEventArgs { TrackInfos = trackList });
         List<TrackInfo> track2List = new List<TrackInfo>();
         track2List.Add(new TrackInfo() { Xcoor = X2, Ycoor = Y2,DataTime = DateTime.ParseExact(D2, "dd-MM-yyyy hh:mm:ss:fff",
            CultureInfo.InvariantCulture)});
         _trackReciever.TracksInASEvent += Raise.EventWith(new TracksEventArgs { TrackInfos = track2List });
         Assert.That(uut.NewTrackList[0].Velocity, Is.EqualTo(V).Within(0.1));
      }
   }
}
