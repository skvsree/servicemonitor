using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceMonitor
{
    public enum ServiceStartupType
    {
        Unknown = 0,
        Automatic = 2,
        Manual = 3,
        Disabled = 4,
        Boot = 5,
        System = 1
    }
}
