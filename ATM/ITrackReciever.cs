﻿using System;
using System.Collections.Generic;

namespace ATM
{
    public interface ITrackReciever
    {
       event EventHandler<List<TrackInfo>> TracksInASEvent;
    }
}
