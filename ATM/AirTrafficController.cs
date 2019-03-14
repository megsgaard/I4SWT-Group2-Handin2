using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class AirTrafficController
    {
        public List<TrackInfo> TrackList { get; private set; }
        public event EventHandler<TracksEventArgs> Event;
        private ISeperationChecker _seperationChecker;
        private IConditionViewer _conditionViewer;

        public AirTrafficController(IDataCalculator dataCalculator)
        {
            dataCalculator.CalculateEvent += RecieveCalculatedEvent;
            TrackList = new List<TrackInfo>();
        }

        public void InvestigateInfo(ISeperationChecker seperationChecker)
        {
            _seperationChecker = seperationChecker;
           seperationChecker.CheckSeperation(TrackList); 
        }

        public void Print(IConditionViewer conditionViewer)
        {
            _conditionViewer = conditionViewer;
            conditionViewer.PrintCurrentCondition(TrackList);

        }

        public void RecieveCalculatedEvent(object sender, TracksEventArgs e)
        {
            TrackList = e.TrackInfos;
            //InvestigateInfo(_seperationChecker);
            //Print(_conditionViewer);
            CalcDoneEvent(new TracksEventArgs{TrackInfos = TrackList});
        }

        protected virtual void CalcDoneEvent(TracksEventArgs e)
        {
            Event?.Invoke(this,e);
        }

    }
}
