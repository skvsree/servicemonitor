using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceMonitor
{
    public enum ServiceStatus
    {
        Started = 4,
        Stopped = 1,
        StartPending = 2,
        StopPending = 3,
        ContinuePending = 5,
        PausePending = 6,
        Paused = 7,
        Error = 8
    }
}
