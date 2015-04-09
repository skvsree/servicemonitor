using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceMonitor
{
    public partial class frmStatus : Form
    {
        public frmStatus()
        {
            InitializeComponent();
        }
        private void frmStatus_Load(object sender, EventArgs e)
        {
            
        } 

        public void SetMesage(string message,int percentage=0)
        {
            this.Invoke((MethodInvoker) delegate
                                            {
                                                lblStatus.Text = message;
                                                statusProgress.Value = percentage;
                                            });
        }
    }
}
