using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public partial class frmLogon : Form
    {
        private WindowsMachine _machine = null;
        public frmLogon()
        {
            InitializeComponent();
        }

        public frmLogon(WindowsMachine machine)
        {
            _machine = machine;
            InitializeComponent();
        }

        private void frmLogon_Load(object sender, EventArgs e)
        {
            
        }

        private void btnFindMachine_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUsername.Text))
            {
                _machine.UserName = txtUsername.Text;
                _machine.Password = txtPassword.Text;
                IWindowsServiceManager windowsServiceManager = null;
                if(_machine.IsWmiEnabled)
                {
                    windowsServiceManager = new WMIWindowServiceManager();
                }
                else
                {
                    MessageBox.Show("WMI Not Enabled in the machine", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CommonPlace.IsMachineFound = windowsServiceManager.CanTheMachineBeFound(_machine);
                this.Close();
            }
            else
            {
                MessageBox.Show("Username Cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
