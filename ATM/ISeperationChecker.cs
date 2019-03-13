using System.Collections.Generic;

namespace ATM
{
    public interface ISeperationChecker
    {
        void CheckSeperation(List<TrackInfo> trackInfoList);
    }
}
