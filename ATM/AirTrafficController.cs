using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class AirTrafficController
    {
        public void InvestigateInfo(ISeperationChecker seperationChecker)
        {
            seperationChecker = new SeperationChecker();
            seperationChecker.CheckSeperation();
        }

        public void Calculate(IDataCalculator dataCalculator)
        {
            dataCalculator = new DataCalculator();
            dataCalculator.DoCalculations();
        }

        public void Print(IConditionViewer conditionViewer)
        {
            conditionViewer = new ConsoleViewer();

        }

        public void RecieveCalculatedEvent()
        {

        }

    }
}
