using System;
using System.Collections.Generic;
using System.Threading;

namespace ServiceMonitor
{
    public class CommonPlace
    {
        public static bool IsMachineFound = false;
        public static List<WindowsService> PickedUpWindowsServices = new List<WindowsService>();
        public static string MachineConfigFileName = "Machines.xml";
        public static frmStatus statusform = new frmStatus();
        public static void ShowLoadingBar()
        {
            if (statusform.IsDisposed)
            {
                statusform = new frmStatus();
            }
            statusform.Show();
        }

        public static void SetStatus(string message)
        {
            statusform.SetMesage(message);
        }

        public static void CloseLoadingBar()
        {
            try
            {
                statusform.Close();
            }
            catch
            {
                
            }
        }

    }
}