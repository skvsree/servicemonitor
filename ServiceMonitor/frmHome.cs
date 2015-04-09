using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public partial class FrmHome : Form
    {
        private static List<WindowsMachine> _machines = new List<WindowsMachine>();
        private readonly BindingSource _bindingSourceLstServers = new BindingSource();
        private readonly BindingSource _bindingSourceDgvServices = new BindingSource();
        private readonly Timer _refreshTimer = new Timer();

        private frmStatus status = new frmStatus();
        public FrmHome()
        {
            InitializeComponent();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            var manage = new frmManage(_machines);
            manage.ShowDialog();
            LoadDataSource();
            RefreshServices();
        }

        private void FrmHomeLoad(object sender, EventArgs e)
        {
            //cmStartupType.DataSource = Enum.GetNames(typeof(ServiceStartupType));
            lstServers.DataSource = _bindingSourceLstServers;
            dgvServices.DataSource = _bindingSourceDgvServices;
            _refreshTimer.Tick += RefreshTimer;
            if (nudRefreshPeriod.Value > 0)
            {
                _refreshTimer.Interval = (int)nudRefreshPeriod.Value * 1000;
                _refreshTimer.Enabled = true;
            }
            else
            {
                _refreshTimer.Enabled = false;
            }
            LoadDataSource();
            RefreshServices();
            bgWorkerForServices.Disposed += (dissender, dise) =>
                                                {
                                                    bgWorkerForServices = new BackgroundWorker();
                                                    bgWorkerForServices.WorkerReportsProgress = true;
                                                    bgWorkerForServices.WorkerSupportsCancellation = true;
                                                };
            bgWorkerForServices.RunWorkerCompleted += (sender2, e2) =>
                                                          {
                                                              RefreshServices();
                                                              status.Close();
                                                              bgWorkerForServices.Dispose();
                                                          };

        }

        private void RefreshTimer(object sender, EventArgs e)
        {
            if (!nudRefreshPeriod.Value.Equals(0))
            {
                RefreshServices();
            }

        }

        private void LoadDataSource()
        {
            if (!File.Exists(CommonPlace.MachineConfigFileName)) return;
            _machines = File.ReadAllText(CommonPlace.MachineConfigFileName).Deserialize(typeof(List<WindowsMachine>));
            _bindingSourceLstServers.DataSource = _machines.Select(x => x.Name).ToList();
        }

        private void DgvServicesCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var serviceName = dgvServices.SelectedRows[0].Cells["Name"].Value.ToString();
                var isSelectedValue = dgvServices.SelectedRows[0].Cells["IsSelected"].Value.ToString().ToUpper().Equals("TRUE");
                var selectedMachine = _machines.First(x => x.Name.Equals(dgvServices.SelectedRows[0].Cells["MachineName"].Value.ToString()));
                var selectedCheckBox = (DataGridViewCheckBoxCell)dgvServices.SelectedRows[0].Cells["IsSelected"];
                selectedMachine.Services.First(x => x.Name.Equals(serviceName)).IsSelected = !isSelectedValue;
                selectedCheckBox.Value = !isSelectedValue;
            }
        }

        private void DgvServicesSelectionChanged(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count <= 0) return;
            //cmStartupType.SelectedItem = dgvServices.SelectedRows[0].Cells["StartUpType"].Value.ToString();
            btnContinue.Enabled = false;
            btnPause.Enabled = false;
            btnRestart.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            switch (dgvServices.SelectedRows[0].Cells["Status"].Value.ToString())
            {
                case "Started":
                    btnStop.Enabled = true;
                    btnPause.Enabled = true;
                    btnRestart.Enabled = true;
                    break;
                case "Stopped":
                    btnStart.Enabled = true;
                    break;
                case "Paused":
                    btnContinue.Enabled = true;
                    break;
            }
        }

        private void BtnStopClick(object sender, EventArgs e)
        {
            DoServiceOperation(ServiceOperation.Stop, ServiceStatus.Started);
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            DoServiceOperation(ServiceOperation.Start, ServiceStatus.Stopped);
        }

        private void BtnRestartClick(object sender, EventArgs e)
        {
            DoServiceOperation(ServiceOperation.Restart, ServiceStatus.Started );
        }

        private void BtnPauseClick(object sender, EventArgs e)
        {
            DoServiceOperation(ServiceOperation.Pause, ServiceStatus.Started);
        }

        private void BtnContinueClick(object sender, EventArgs e)
        {
            DoServiceOperation(ServiceOperation.Continue, ServiceStatus.Paused);
        }

        private void RefreshServices()
        {
            if (lstServers.SelectedItems.Count > 0)
            {
                var services = new List<WindowsService>();

                foreach (var selectedMachine in _machines.Where(x => x.IsSelected))
                {
                    IWindowsServiceManager windowsServiceManager;
                    if (selectedMachine.IsWmiEnabled)
                    {
                        windowsServiceManager = new WMIWindowServiceManager();
                        services.AddRange(windowsServiceManager.GetServices(selectedMachine));
                    }
                    else
                    {
                        MessageBox.Show("Information",
                                        string.Format("WMI Not Enabled in the machine: {0}", selectedMachine.Name));
                    }
                }

                _bindingSourceDgvServices.DataSource = new BindingList<WindowsService>(services);
                var dataGridViewColumn = dgvServices.Columns["Machine"];
                if (dataGridViewColumn != null) dataGridViewColumn.Visible = false;

                foreach (DataGridViewRow row in dgvServices.Rows)
                {
                    var selectedMachine = _machines.First(x => x.Name.Equals(row.Cells["MachineName"].Value.ToString()));
                    var serviceName = row.Cells["Name"].Value.ToString();
                    var serviceStatus = row.Cells["Status"].Value.ToString();
                    var selectedService = selectedMachine.Services.First(x => x.Name.Equals(serviceName));
                    selectedService.Status = (ServiceStatus)Enum.Parse(typeof(ServiceStatus), serviceStatus);
                }
            }
            else
            {
                _bindingSourceDgvServices.DataSource = new BindingList<WindowsService>(new List<WindowsService>());
            }
        }



        private void BtnRefreshClick(object sender, EventArgs e)
        {
            RefreshServices();
        }

        private void NudRefreshPeriodValueChanged(object sender, EventArgs e)
        {
            if (nudRefreshPeriod.Value > 0)
            {
                _refreshTimer.Interval = (int)nudRefreshPeriod.Value * 1000;
                _refreshTimer.Enabled = true;
            }
            else
            {
                _refreshTimer.Enabled = false;
            }
        }

        private void CmStartupTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lstServers.SelectedItems.Count <= 0) return;
            //if(dgvServices.SelectedRows[0].Cells["StartUpType"].Value.ToString().Equals(cmStartupType.SelectedItem.ToString())) return;
            //var selectedMachine = _machines.First(x => x.Name.Equals(lstServers.SelectedItem.ToString()));
            //IWindowsServiceManager windowsServiceManager;
            //if (selectedMachine.IsWmiEnabled)
            //{
            //    var selectedService = selectedMachine.Services.First(x => x.Name.Equals(dgvServices.SelectedRows[0].Cells["Name"].Value.ToString()));
            //    windowsServiceManager = new WMIWindowServiceManager();
            //    windowsServiceManager.UpdatedStartupType(selectedMachine, selectedService, (ServiceStartupType) Enum.Parse(typeof (ServiceStartupType), cmStartupType.SelectedItem.ToString()));
            //    RefreshServices();
            //}
            //else
            //{
            //    MessageBox.Show("Non WMI machines are not supported in this Version", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                var serviceName = row.Cells["Name"].Value.ToString();
                var selectedMachine = _machines.First(x => x.Name.Equals(row.Cells["MachineName"].Value.ToString()));
                var selectedCheckBox = (DataGridViewCheckBoxCell)row.Cells["IsSelected"];
                selectedMachine.Services.First(x => x.Name.Equals(serviceName)).IsSelected = true;
                selectedCheckBox.Value = true;
            }
        }

        private void btnUnCheck_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                var serviceName = row.Cells["Name"].Value.ToString();
                var selectedMachine = _machines.First(x => x.Name.Equals(row.Cells["MachineName"].Value.ToString()));
                var selectedCheckBox = (DataGridViewCheckBoxCell)row.Cells["IsSelected"];
                selectedMachine.Services.First(x => x.Name.Equals(serviceName)).IsSelected = false;
                selectedCheckBox.Value = false;
            }
        }

        private void lstServers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstServers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            _machines.First(x => x.Name.Equals(lstServers.Items[e.Index].ToString())).IsSelected = e.NewValue ==
                                                                                                   CheckState.Checked;
            //lstServers.SetItemChecked(e.Index, e.NewValue == CheckState.Checked);
            RefreshServices();
        }

        private void DisableStuff()
        {
            lstServers.Enabled = false;
            grpServiceActions.Enabled = false;
            dgvServices.Enabled = false;
            nudRefreshPeriod.Enabled = false;
        }

        private void EnableStuff()
        {
            _EnableStuff(lstServers);
            _EnableStuff(grpServiceActions);
            _EnableStuff(dgvServices);
            _EnableStuff(nudRefreshPeriod);
        }

        private static void _EnableStuff(Control ctl)
        {
            if (ctl.InvokeRequired)
            {
                ctl.Invoke((Action)(() =>
                {
                    ctl.Enabled = true;
                }));
            }
            else
            {
                ctl.Enabled = true;
            }
        }

        private void DoServiceOperation(ServiceOperation operation, ServiceStatus expectedStatus)
        {

            DisableStuff();
            processStatus.Value = 0;
            lblPerogressPercent.Text = string.Format("{0}%", 0);
            var bgWorkers = new List<BackgroundWorker>();
            foreach (var selectedMachine in _machines.Where(x => x.IsSelected))
            {
                var selectedServiceCount =
                    _machines.Where(x => x.IsSelected).Sum(x => x.Services.Count(y => y.IsSelected));
                if (selectedMachine.IsWmiEnabled)
                {
                    var i = 0;
                    foreach (var selectedService in selectedMachine.Services.Where(x => x.IsSelected))
                    {
                        var bgWorkerForService = new BackgroundWorker()
                        {
                            WorkerReportsProgress = true,
                            WorkerSupportsCancellation = true
                        };
                        if (!selectedService.Status.Equals(expectedStatus)) continue;
                        IWindowsServiceManager windowsServiceManager = new WMIWindowServiceManager();
                        var service = selectedService;
                        var machine = selectedMachine;

                        bgWorkerForService.ProgressChanged += (sender3, e3) =>
                        {
                            processStatus.Value = (e3.ProgressPercentage * 100) /
                                                  (2 * selectedServiceCount);
                            lblPerogressPercent.Text = string.Format("{0}%",
                                                                     processStatus
                                                                         .Value);
                        };
                        bgWorkerForService.DoWork += (sender2, e2) =>
                        {
                            bgWorkerForService.ReportProgress(i++);
                            windowsServiceManager.DoOperation(operation, machine, service);
                            bgWorkerForService.ReportProgress(i++);
                        };
                        bgWorkerForService.RunWorkerCompleted += (sender2, e2) => bgWorkerForService.Dispose();
                        bgWorkerForService.RunWorkerAsync();
                        bgWorkers.Add(bgWorkerForService);
                    }
                }
                else
                {
                    // ReSharper disable LocalizableElement
                    MessageBox.Show("Non WMI machines are not supported in this Version", "Warning",
                        // ReSharper restore LocalizableElement
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                // bgWorkerForServices.RunWorkerAsync();

            }
            Task.Factory.StartNew(() =>
            {
                while (bgWorkers.Count(x => x.IsBusy) != 0)
                {

                }
                if (InvokeRequired)
                {
                    Invoke((Action)(() =>
                    {

                        EnableStuff();
                        RefreshServices();
                        processStatus.Value = 100;
                        lblPerogressPercent.Text = string.Format("{0}%", processStatus.Value);
                    }));
                }
            });
        }

    }
}
