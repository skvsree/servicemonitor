namespace ServiceMonitor
{
    partial class FrmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpServiceActions = new System.Windows.Forms.GroupBox();
            this.btnUnCheck = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.nudRefreshPeriod = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstServers = new System.Windows.Forms.CheckedListBox();
            this.bgWorkerForServices = new System.ComponentModel.BackgroundWorker();
            this.processStatus = new System.Windows.Forms.ProgressBar();
            this.lblPerogressPercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.grpServiceActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefreshPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "MANAGE SERVERS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Location = new System.Drawing.Point(403, 103);
            this.dgvServices.MultiSelect = false;
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.Size = new System.Drawing.Size(811, 267);
            this.dgvServices.TabIndex = 3;
            this.dgvServices.VirtualMode = true;
            this.dgvServices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvServicesCellContentClick);
            this.dgvServices.SelectionChanged += new System.EventHandler(this.DgvServicesSelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "SERVERS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "SERVICES";
            // 
            // grpServiceActions
            // 
            this.grpServiceActions.Controls.Add(this.btnUnCheck);
            this.grpServiceActions.Controls.Add(this.button2);
            this.grpServiceActions.Controls.Add(this.btnContinue);
            this.grpServiceActions.Controls.Add(this.btnPause);
            this.grpServiceActions.Controls.Add(this.btnRestart);
            this.grpServiceActions.Controls.Add(this.btnStart);
            this.grpServiceActions.Controls.Add(this.btnStop);
            this.grpServiceActions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpServiceActions.Location = new System.Drawing.Point(403, 16);
            this.grpServiceActions.Name = "grpServiceActions";
            this.grpServiceActions.Size = new System.Drawing.Size(811, 61);
            this.grpServiceActions.TabIndex = 7;
            this.grpServiceActions.TabStop = false;
            this.grpServiceActions.Text = "Service Actions";
            // 
            // btnUnCheck
            // 
            this.btnUnCheck.Location = new System.Drawing.Point(693, 24);
            this.btnUnCheck.Name = "btnUnCheck";
            this.btnUnCheck.Size = new System.Drawing.Size(112, 31);
            this.btnUnCheck.TabIndex = 6;
            this.btnUnCheck.Text = "UNCHECK ALL";
            this.btnUnCheck.UseVisualStyleBackColor = true;
            this.btnUnCheck.Click += new System.EventHandler(this.btnUnCheck_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(578, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "CHECK ALL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(350, 24);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(92, 31);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "CONTINUE";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.BtnContinueClick);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(269, 24);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 31);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "PAUSE";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPauseClick);
            // 
            // btnRestart
            // 
            this.btnRestart.Enabled = false;
            this.btnRestart.Location = new System.Drawing.Point(188, 24);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 31);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "RESTART";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.BtnRestartClick);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(107, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 31);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(26, 24);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 31);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(429, 376);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 31);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "&REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefreshClick);
            // 
            // nudRefreshPeriod
            // 
            this.nudRefreshPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudRefreshPeriod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRefreshPeriod.Location = new System.Drawing.Point(676, 376);
            this.nudRefreshPeriod.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRefreshPeriod.Name = "nudRefreshPeriod";
            this.nudRefreshPeriod.Size = new System.Drawing.Size(89, 25);
            this.nudRefreshPeriod.TabIndex = 8;
            this.nudRefreshPeriod.ValueChanged += new System.EventHandler(this.NudRefreshPeriodValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(546, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "REFRESH PERIOD";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(771, 378);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "SEC(S)";
            // 
            // lstServers
            // 
            this.lstServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstServers.FormattingEnabled = true;
            this.lstServers.Location = new System.Drawing.Point(27, 103);
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(330, 268);
            this.lstServers.TabIndex = 11;
            this.lstServers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstServers_ItemCheck);
            this.lstServers.SelectedIndexChanged += new System.EventHandler(this.lstServers_SelectedIndexChanged);
            // 
            // bgWorkerForServices
            // 
            this.bgWorkerForServices.WorkerReportsProgress = true;
            this.bgWorkerForServices.WorkerSupportsCancellation = true;
            // 
            // processStatus
            // 
            this.processStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.processStatus.Location = new System.Drawing.Point(881, 376);
            this.processStatus.Name = "processStatus";
            this.processStatus.Size = new System.Drawing.Size(333, 23);
            this.processStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.processStatus.TabIndex = 12;
            // 
            // lblPerogressPercent
            // 
            this.lblPerogressPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPerogressPercent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPerogressPercent.Location = new System.Drawing.Point(825, 378);
            this.lblPerogressPercent.Name = "lblPerogressPercent";
            this.lblPerogressPercent.Size = new System.Drawing.Size(50, 20);
            this.lblPerogressPercent.TabIndex = 13;
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 425);
            this.Controls.Add(this.lblPerogressPercent);
            this.Controls.Add(this.processStatus);
            this.Controls.Add(this.lstServers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudRefreshPeriod);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpServiceActions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvServices);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmHome";
            this.Text = "ServiceMonitor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmHomeLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.grpServiceActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRefreshPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpServiceActions;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.NumericUpDown nudRefreshPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUnCheck;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox lstServers;
        private System.ComponentModel.BackgroundWorker bgWorkerForServices;
        private System.Windows.Forms.ProgressBar processStatus;
        private System.Windows.Forms.Label lblPerogressPercent;
    }
}

