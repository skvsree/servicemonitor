using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ServiceMonitor
{
    public class WindowsService
    {
        public bool IsSelected { get; set; }

        [XmlIgnore]
        public WindowsMachine Machine { get; set; }
        
        public string MachineName
        {
            get
            {
                if (Machine == null)
                {
                    return string.Empty;
                }
                return Machine.Name;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public ServiceStatus Status
        {
            get;
            set;
        }

        public ServiceMonitor.ServiceStartupType StartUpType
        {
            get;
            set;
        }
    }
}
