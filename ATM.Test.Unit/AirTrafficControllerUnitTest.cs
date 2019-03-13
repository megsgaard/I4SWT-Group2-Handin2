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
        private IDataCalculator _dataCalculator;
        private IConditionViewer _conditionViewer;
        private ISeperationChecker _seperationChecker;

        [SetUp]
        public void SetUp()
        {
            _dataCalculator = Substitute.For<IDataCalculator>();
            _conditionViewer = Substitute.For<IConditionViewer>();
            _seperationChecker = Substitute.For<ISeperationChecker>();
      

            _uut = new AirTrafficController();
        }

        [Test]
        public void Calculate_CallingMethod_DoCalculationsWasCalled()
        {
            _uut.Calculate(_dataCalculator);
            _dataCalculator.Received(1).DoCalculations();
        }

        [Test]
        public void Print_CallingMethod_PrintCurrentConditionWasCalled()
        {
            _uut.Print(_conditionViewer);
            _conditionViewer.Received(1).PrintCurrentCondition();
        }

        [Test]
        public void InvestigateInfo_CallingMethod_CheckSeperationWasCalled()
        {
            _uut.Print(_conditionViewer);
            _conditionViewer.Received(1).PrintCurrentCondition();
        }


    }
}
