﻿using System;
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

      //[Test]
      //public void RecieveTrackEvent_EventFired_NewTrackListIsUpdated()
      //{
      //   TrackInfo _track1 = new TrackInfo();
      //   {

      //   }
      //   _trackReciever.TracksInASEvent+=Raise.EventWith(new List<TrackInfo>())
      //}
   }
}
