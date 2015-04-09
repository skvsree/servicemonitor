using System;
using System.Linq;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public partial class frmListServices : Form
    {

        IWindowsServiceManager _windowsServiceManager = null;
        private WindowsMachine _machine = null;
        private string _serviceNameLike = "%";
        public frmListServices()
        {
            InitializeComponent();
        }

        public frmListServices(WindowsMachine machine,string serviceNameLike="%")
        {
            _machine = machine;
            _serviceNameLike = serviceNameLike;
            InitializeComponent();
        }

        private void frmListServices_Load(object sender, EventArgs e)
        {
            if(_machine.IsWmiEnabled)
            {
                _windowsServiceManager = new WMIWindowServiceManager();
            }
            else
            {
                MessageBox.Show("Information", "WMI Not Enabled in the machine");
                return;
            }
            lstServers.DataSource = _windowsServiceManager.ListServices(_machine,_serviceNameLike).ToList();
        }

        private void btnFindMachine_Click(object sender, EventArgs e)
        {
            
            CommonPlace.PickedUpWindowsServices.Clear();
            foreach (var selectedItem in lstServers.CheckedItems)
            {
                CommonPlace.PickedUpWindowsServices.Add(_windowsServiceManager.GetService(_machine,selectedItem.ToString()));
            }
            this.Close();
        }

        private void lstServers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnFindMachine.Enabled = lstServers.CheckedItems.Count  > 0 || e.NewValue.Equals(CheckState.Checked);
        }
    }
}
