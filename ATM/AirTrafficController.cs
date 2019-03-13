﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class AirTrafficController
    {
        private List<TrackInfo> TrackList;

        public void InvestigateInfo(ISeperationChecker seperationChecker)
        {
            seperationChecker.CheckSeperation();
        }

        public void Calculate(IDataCalculator dataCalculator)
        {
            dataCalculator.DoCalculations();
        }

        public void Print(IConditionViewer conditionViewer)
        {
            conditionViewer.PrintCurrentCondition();

        }

        public void RecieveCalculatedEvent(object sender, List<TrackInfo> e)
        {
            TrackList = e;
        }

    }
}
