using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;

namespace ServiceMonitor
{
    public class WMIWindowServiceManager : IWindowsServiceManager
    {
        private bool _isOperationCompleted;
        private WindowsService _toBeReturnedAfterOperation = null;
        public static Dictionary<string, ServiceStatus> ServiceStatusMapping = new Dictionary<string, ServiceStatus>
            {
                {"Stopped", ServiceStatus.Stopped},
                {"Start Pending", ServiceStatus.StartPending},
                {"Stop Pending", ServiceStatus.StopPending},
                {"Running", ServiceStatus.Started},
                {"Continue Pending", ServiceStatus.ContinuePending},
                {"Pause Pending", ServiceStatus.PausePending},
                {"Paused", ServiceStatus.Paused},
                {"Unknown", ServiceStatus.Error},
            };

        public static Dictionary<string, ServiceStartupType> StartTypeMapping = new Dictionary<string, ServiceStartupType>
            {
                {"Boot", ServiceStartupType.Boot},
                {"System", ServiceStartupType.System},
                {"Auto", ServiceStartupType.Automatic},
                {"Manual", ServiceStartupType.Manual},
                {"Disabled", ServiceStartupType.Disabled},
            };
        public List<string> ListServices(WindowsMachine machine, string serviceNameLike = "%")
        {
            const string basequery = "select * from Win32_Service";
            var scope = ConnectToMachine(machine);
            var query = string.Format("{0} where DisplayName like '{1}'", basequery, serviceNameLike);
            var searcher =
                new ManagementObjectSearcher(scope, new ObjectQuery(string.Format(query)));
            return (from ManagementObject mo in searcher.Get() select mo["DisplayName"].ToString()).OrderBy(x => x).ToList();
        }

        public WindowsService StartService(WindowsMachine machine, WindowsService service)
        {
            if (RunCommand(machine, service, "StartService"))
            {
                service.Status = ServiceStatus.Started;
            }
            return service;
        }

        public WindowsService StopService(WindowsMachine machine, WindowsService service)
        {
            if (RunCommand(machine, service, "StopService"))
            {
                service.Status = ServiceStatus.Stopped;
            }
            return service;
        }

        public WindowsService RestartService(WindowsMachine machine, WindowsService service)
        {
            if (RunCommand(machine, service, "StopService"))
            {
                service.Status = ServiceStatus.Stopped;
                var i = 0;
                while (!GetService(machine, service.Name).Status.Equals(ServiceStatus.Stopped) && i < 60)
                {
                    Thread.Sleep(1000);
                    i++;
                }
                if (RunCommand(machine, service, "StartService"))
                {
                    service.Status = ServiceStatus.Started;
                }

            }
            return service;
        }


        public WindowsService GetService(WindowsMachine machine, string serviceName)
        {
            const string basequery = "select * from Win32_Service";
            var scope = ConnectToMachine(machine);
            var query = string.Format("{0} where DisplayName = '{1}'", basequery, serviceName);
            var searcher =
                new ManagementObjectSearcher(scope, new ObjectQuery(string.Format(query)));
            var mo = searcher.Get();
            return (from ManagementBaseObject service in mo
                    select new WindowsService()
                        {
                            Name = service["DisplayName"].ToString(),
                            Status = ServiceStatusMapping[service["State"].ToString()],
                            StartUpType = StartTypeMapping[service["StartMode"].ToString()],
                            Machine = machine,
                            IsSelected = machine.Services.Any(x => x.Name.Equals(service["DisplayName"].ToString())) ? machine.Services.First(x => x.Name.Equals(service["DisplayName"].ToString())).IsSelected : false
                        }).FirstOrDefault();
        }


        public bool CanTheMachineBeFound(WindowsMachine machine)
        {
            try
            {
                ConnectToMachine(machine);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static ManagementScope ConnectToMachine(WindowsMachine machine)
        {
            const string ns = @"root\cimv2";

            var options = new ConnectionOptions();
            if (!machine.Name.Equals("."))
            {
                if (!string.IsNullOrEmpty(machine.UserName))
                {
                    options.Username = machine.UserName;
                    options.Password = machine.Password;
                }
            }

            var scope =
                new ManagementScope(string.Format(@"\\{0}\{1}", machine.Name, ns), options);
            scope.Connect();

            return scope;
        }




        public List<WindowsService> GetServices(WindowsMachine machine)
        {
            const string basequery = "select * from Win32_Service";
            var serviceNames = machine.Services.Select(x => x.Name).ToArray();
            var scope = ConnectToMachine(machine);
            var query = string.Format("{0} where DisplayName = '{1}'", basequery, string.Join("' or DisplayName = '", serviceNames));
            var searcher =
                new ManagementObjectSearcher(scope, new ObjectQuery(string.Format(query)));
            var mo = searcher.Get();
            return (from ManagementBaseObject service in mo
                    select new WindowsService()
                        {
                            Name = service["DisplayName"].ToString(),
                            Status = ServiceStatusMapping[service["State"].ToString()],
                            StartUpType = StartTypeMapping[service["StartMode"].ToString()],
                            Machine = machine,
                            IsSelected = machine.Services.Any(x => x.Name.Equals(service["DisplayName"].ToString())) ? machine.Services.First(x => x.Name.Equals(service["DisplayName"].ToString())).IsSelected : false
                        }).ToList();
        }

        private bool RunCommand(WindowsMachine machine, WindowsService service, string command, ManagementBaseObject inParams = null)
        {
            var objPath = string.Format("select * from Win32_Service where DisplayName='{0}'", service.Name);
            var scope = ConnectToMachine(machine);
            var observer = new ManagementOperationObserver();

            var searcher = new ManagementObjectSearcher(scope, new ObjectQuery(string.Format(objPath)));
            _isOperationCompleted = false;
            observer.ObjectReady += ObjectTobeReturned;
            //observer.Completed += Completed;
            //observer.Progress += Progress;
            foreach (ManagementObject mo in searcher.Get())
            {
                mo.InvokeMethod(observer, command, inParams, null);
            }


            var sleepCount = 0;
            while (!_isOperationCompleted && sleepCount <= 60)
            {
                Thread.Sleep(1000);
                sleepCount++;
            }
            return _isOperationCompleted;
        }

        private void Progress(object sender, ProgressEventArgs obj)
        {
            var i = obj.Current;
        }

        private void Completed(object sender, CompletedEventArgs obj)
        {
            _isOperationCompleted = true;
        }

        private void ObjectTobeReturned(object sender, ObjectReadyEventArgs obj)
        {
            if (_toBeReturnedAfterOperation == null)
            {
                _toBeReturnedAfterOperation = new WindowsService();
            }
            var result = int.Parse(obj.NewObject.Properties["returnValue"].Value.ToString());
            _isOperationCompleted = result.Equals(0);
        }



        public WindowsService PauseService(WindowsMachine machine, WindowsService service)
        {
            if (RunCommand(machine, service, "PauseService"))
            {
                service.Status = ServiceStatus.Paused;
            }
            return service;
        }

        public WindowsService ResumeService(WindowsMachine machine, WindowsService service)
        {
            if (RunCommand(machine, service, "ResumeService"))
            {
                service.Status = ServiceStatus.Started;
            }
            return service;
        }


        public WindowsService UpdatedStartupType(WindowsMachine machine, WindowsService service, ServiceStartupType serviceStartupType)
        {
            var objPath = string.Format("select * from Win32_Service where DisplayName='{0}'", service.Name);
            var scope = ConnectToMachine(machine);
            var observer = new ManagementOperationObserver();

            var searcher = new ManagementObjectSearcher(scope, new ObjectQuery(string.Format(objPath)));
            _isOperationCompleted = false;
            observer.ObjectReady += ObjectTobeReturned;


            //observer.Completed += Completed;
            //observer.Progress += Progress;
            foreach (ManagementObject mo in searcher.Get())
            {
                ManagementBaseObject inParams = mo.GetMethodParameters("ChangeStartMode");
                inParams["StartMode"] = StartTypeMapping.First(x => x.Value.Equals(serviceStartupType));

                mo.InvokeMethod(observer, "ChangeStartMode", inParams, null);
            }


            var sleepCount = 0;
            while (!_isOperationCompleted && sleepCount <= 60)
            {
                Thread.Sleep(1000);
                sleepCount++;
            }
            if (_isOperationCompleted)
            {
                service.StartUpType = serviceStartupType;
            }
            return service;
        }


        public WindowsService DoOperation(ServiceOperation operation, WindowsMachine machine, WindowsService service)
        {
            switch (operation)
            {
                case ServiceOperation.Continue:
                    return ResumeService(machine, service);
                case ServiceOperation.Pause:
                    return PauseService(machine, service);
                case ServiceOperation.Restart:
                    return RestartService(machine, service);
                case ServiceOperation.Start:
                    return StartService(machine, service);
                case ServiceOperation.Stop:
                    return StopService(machine, service);
                default:
                    throw new InvalidEnumArgumentException(string.Format("{0} is invalid", operation));
            }
        }
    }
}
