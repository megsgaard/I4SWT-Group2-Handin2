﻿using System;
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
        private TrackInfo _info;
        private List<TrackInfo> _list;

        [SetUp]
        public void SetUp()
        {
            _conditionViewer = Substitute.For<IConditionViewer>();
            _seperationChecker = Substitute.For<ISeperationChecker>();
            _info = Substitute.For<TrackInfo>();

            _uut = new AirTrafficController();
        }


        [Test]
        public void Print_CallingMethod_PrintCurrentConditionWasCalled()
        {
            _uut.Print(_conditionViewer);
            _conditionViewer.Received(1).PrintCurrentCondition(_list);
        }

        [Test]
        public void InvestigateInfo_CallingMethod_CheckSeperationWasCalled()
        {
            _uut.Print(_conditionViewer);
            _conditionViewer.Received(1).PrintCurrentCondition(_list);
        }


    }
}
