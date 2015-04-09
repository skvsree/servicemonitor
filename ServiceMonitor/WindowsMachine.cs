using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiceMonitor
{
    public class WindowsMachine
    {
        public bool IsSelected { get; set; }

        public string Name
        {
            get;
            set;
        }


        [XmlElement("Services")]
        public List<WindowsService> Services
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public bool IsWmiEnabled { get; set; }

        public WindowsMachine()
        {
            Services = new List<WindowsService>();
        }

        public new string ToString()
        {
            return Name;
        }
    }
}