using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public partial class frmManage : Form
    {
        private List<WindowsMachine> _machines = null;
        private WindowsMachine _selectedMachine = null;
        private BindingSource bsDgvServices = new BindingSource();
        public frmManage()
        {
            InitializeComponent();
        }

        public frmManage(List<WindowsMachine> machines)
        {
            _machines = machines;
            InitializeComponent();
        }


        private void grpManageService_Enter(object sender, EventArgs e)
        {

        }

        private void btnFindMachine_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMachine.Text.Trim()))
            {
                _selectedMachine = new WindowsMachine { Name = txtMachine.Text.Trim(), IsWmiEnabled = chkIsWmi.Checked };
                if (!txtMachine.Text.Trim().Equals("."))
                {
                    var logon = new frmLogon(_selectedMachine);
                    logon.ShowDialog();
                }
                else
                {
                    CommonPlace.IsMachineFound = true;
                }
                chkMachineFound.Checked = CommonPlace.IsMachineFound;
            }
            else
            {
                MessageBox.Show("Machine name Cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkMachineFound_CheckedChanged(object sender, EventArgs e)
        {
            btnAddMachine.Enabled = chkMachineFound.Checked;
        }

        private void btnAddMachine_Click(object sender, EventArgs e)
        {
            if (_machines.Any(x => x.Name.Equals(_selectedMachine.Name))) return;
            _machines.Add(_selectedMachine);
            LoadServers();
            txtMachine.Text = string.Empty;
        }

        private void LoadServers()
        {
            if (_machines != null)
            {
                lstServers.DataSource = _machines.Select(x => x.Name).ToList();
            }
        }

        private void brnFindService_Click(object sender, EventArgs e)
        {
            if (txtService.Text.Trim().Length <= 0) return;
            var selectedMachine = _machines.First(x => x.Name.Equals(lstServers.SelectedItem.ToString()));
            var services = new frmListServices(selectedMachine, txtService.Text);
            services.ShowDialog();
            foreach (var service in CommonPlace.PickedUpWindowsServices)
            {
                if (_selectedMachine.Services.Any(x => x.Name.Equals(service.Name)))
                {
                    _selectedMachine.Services.Remove(_selectedMachine.Services.First(x => x.Name.Equals(service.Name)));
                }
                _selectedMachine.Services.Add(service);
            }

            var serviceNameArray = selectedMachine.Services.Select(x => x.Name).ToArray();
            selectedMachine.Services.Clear();
            for (var i = 0; i < serviceNameArray.Count(); i++)
            {
                IWindowsServiceManager windowsServiceManager = null;
                if (_selectedMachine.IsWmiEnabled)
                {
                    windowsServiceManager = new WMIWindowServiceManager();
                    var service = windowsServiceManager.GetService(_selectedMachine,
                                                                   serviceNameArray[i]);
                    if (service != null)
                    {
                        selectedMachine.Services.Add(service);
                    }

                }
                else
                {
                    MessageBox.Show("Information", "WMI Not Enabled in the machine");
                }
            }
            bsDgvServices.DataSource = selectedMachine.Services;
            //dgvManageServices.DataSource = bsDgvServices;
            var dataGridViewColumn = dgvManageServices.Columns["Machine"];
            if (dataGridViewColumn != null) dataGridViewColumn.Visible = false;
            var gridViewColumn = dgvManageServices.Columns["IsSelected"];
            if (gridViewColumn != null)
                gridViewColumn.Visible = false;
            dgvManageServices.ResetBindings();
        }

        private void txtService_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpManageService.Enabled = lstServers.SelectedItems.Count > 0;
            btnDeleteMachine.Enabled = lstServers.SelectedItems.Count > 0;
            if (lstServers.SelectedItems.Count > 0)
            {
                _selectedMachine = _machines.First(x => x.Name.Equals(lstServers.SelectedItem.ToString()));
                IWindowsServiceManager windowsServiceManager = null;
                if (_selectedMachine.IsWmiEnabled)
                {
                    windowsServiceManager = new WMIWindowServiceManager();

                    dgvManageServices.DataSource = bsDgvServices;
                    bsDgvServices.DataSource = windowsServiceManager.GetServices(_selectedMachine);
                    var dataGridViewColumn = dgvManageServices.Columns["Machine"];
                    if (dataGridViewColumn != null) dataGridViewColumn.Visible = false;
                    var gridViewColumn = dgvManageServices.Columns["IsSelected"];
                    if (gridViewColumn != null)
                        gridViewColumn.Visible = false;
                }
                else
                {
                    MessageBox.Show("Information", "WMI Not Enabled in the machine");
                }
            }
            else
            {
                bsDgvServices.DataSource = new List<WindowsService>();
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Do your want to save Config changes?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult.Equals(DialogResult.Yes))
            {
                File.WriteAllText(CommonPlace.MachineConfigFileName, _machines.SerializeAsString(typeof(List<WindowsMachine>)));
            }
        }

        private void frmManage_Load(object sender, EventArgs e)
        {
            LoadServers();
        }

        private void dgvManageServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDeleteService.Enabled = dgvManageServices.SelectedRows.Count > 0;
        }

        private void btnDeleteMachine_Click(object sender, EventArgs e)
        {
            if (lstServers.SelectedItems.Count > 0)
            {
                _machines.Remove(_selectedMachine);
                LoadServers();
                if (!_machines.Any())
                {
                    bsDgvServices.DataSource = new List<WindowsService>();
                }
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvManageServices.SelectedRows.Count <= 0) return;
            var serviceName = dgvManageServices.SelectedRows[0].Cells["Name"].Value.ToString();
            _selectedMachine.Services.Remove(_selectedMachine.Services.First(x => x.Name.Equals(serviceName)));
            bsDgvServices.DataSource = new BindingList<WindowsService>(_selectedMachine.Services); 
           // dgvManageServices.Rows.Clear();
            dgvManageServices.ResetBindings();
            dgvManageServices.DataSource = bsDgvServices;
        }

        private void dgvManageServices_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteService.Enabled = dgvManageServices.SelectedRows.Count > 0;
        }

        private void dgvManageServices_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgvManageServices.ResetBindings();
        }
    }
}
