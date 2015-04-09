using System;
using System.Collections.Generic;
using System.Management;

namespace ServiceMonitor
{
    public interface IWindowsServiceManager
    {

        List<string> ListServices(WindowsMachine machine,string serviceNameLike);

        WindowsService StartService(WindowsMachine machine, WindowsService service);

        WindowsService StopService(WindowsMachine machine, WindowsService service);

        WindowsService RestartService(WindowsMachine machine, WindowsService service);

        WindowsService PauseService(WindowsMachine machine, WindowsService service);

        WindowsService ResumeService(WindowsMachine machine, WindowsService service);

        WindowsService DoOperation(ServiceOperation operation, WindowsMachine machine, WindowsService service);

        WindowsService GetService(WindowsMachine machine, string serviceName);

        WindowsService UpdatedStartupType(WindowsMachine machine, WindowsService service, ServiceStartupType serviceStartupType);

        List<WindowsService> GetServices(WindowsMachine machine);

        bool CanTheMachineBeFound(WindowsMachine machine);


    }
}