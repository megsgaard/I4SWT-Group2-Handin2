using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IDataCalculator
    {
       event EventHandler<TracksEventArgs> CalculateEvent;

       void DoCalculations();
       void CalculateVelocity();
       void CalculateCourse();
       void CompareLists();
       void RecieveTrackEvent(object sender, TracksEventArgs e);
    }
}
