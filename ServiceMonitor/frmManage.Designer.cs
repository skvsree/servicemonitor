namespace ServiceMonitor
{
    partial class frmManage
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
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.btnFindMachine = new System.Windows.Forms.Button();
            this.chkMachineFound = new System.Windows.Forms.CheckBox();
            this.btnAddMachine = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpManageService = new System.Windows.Forms.GroupBox();
            this.dgvManageServices = new System.Windows.Forms.DataGridView();
            this.btnDeleteService = new System.Windows.Forms.Button();
            this.txtService = new System.Windows.Forms.TextBox();
            this.brnFindService = new System.Windows.Forms.Button();
            this.btnDeleteMachine = new System.Windows.Forms.Button();
            this.chkIsWmi = new System.Windows.Forms.CheckBox();
            this.lstServers = new System.Windows.Forms.ListBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.grpManageService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageServices)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMachine
            // 
            this.txtMachine.Location = new System.Drawing.Point(24, 28);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(272, 25);
            this.txtMachine.TabIndex = 0;
            // 
            // btnFindMachine
            // 
            this.btnFindMachine.Location = new System.Drawing.Point(377, 19);
            this.btnFindMachine.Name = "btnFindMachine";
            this.btnFindMachine.Size = new System.Drawing.Size(127, 40);
            this.btnFindMachine.TabIndex = 1;
            this.btnFindMachine.Text = "FIND MACHINE";
            this.btnFindMachine.UseVisualStyleBackColor = true;
            this.btnFindMachine.Click += new System.EventHandler(this.btnFindMachine_Click);
            // 
            // chkMachineFound
            // 
            this.chkMachineFound.AutoSize = true;
            this.chkMachineFound.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.chkMachineFound.FlatAppearance.BorderSize = 4;
            this.chkMachineFound.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.chkMachineFound.Location = new System.Drawing.Point(510, 30);
            this.chkMachineFound.Name = "chkMachineFound";
            this.chkMachineFound.Size = new System.Drawing.Size(71, 21);
            this.chkMachineFound.TabIndex = 2;
            this.chkMachineFound.Text = "FOUND";
            this.chkMachineFound.UseVisualStyleBackColor = true;
            this.chkMachineFound.CheckedChanged += new System.EventHandler(this.chkMachineFound_CheckedChanged);
            // 
            // btnAddMachine
            // 
            this.btnAddMachine.Enabled = false;
            this.btnAddMachine.Location = new System.Drawing.Point(595, 19);
            this.btnAddMachine.Name = "btnAddMachine";
            this.btnAddMachine.Size = new System.Drawing.Size(127, 40);
            this.btnAddMachine.TabIndex = 3;
            this.btnAddMachine.Text = "ADD MACHINE";
            this.btnAddMachine.UseVisualStyleBackColor = true;
            this.btnAddMachine.Click += new System.EventHandler(this.btnAddMachine_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "SERVERS";
            // 
            // grpManageService
            // 
            this.grpManageService.Controls.Add(this.dgvManageServices);
            this.grpManageService.Controls.Add(this.btnDeleteService);
            this.grpManageService.Controls.Add(this.txtService);
            this.grpManageService.Controls.Add(this.brnFindService);
            this.grpManageService.Enabled = false;
            this.grpManageService.Location = new System.Drawing.Point(377, 65);
            this.grpManageService.Name = "grpManageService";
            this.grpManageService.Size = new System.Drawing.Size(891, 466);
            this.grpManageService.TabIndex = 9;
            this.grpManageService.TabStop = false;
            this.grpManageService.Text = "SERVICES";
            this.grpManageService.Enter += new System.EventHandler(this.grpManageService_Enter);
            // 
            // dgvManageServices
            // 
            this.dgvManageServices.AllowUserToAddRows = false;
            this.dgvManageServices.AllowUserToDeleteRows = false;
            this.dgvManageServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManageServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvManageServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageServices.Location = new System.Drawing.Point(40, 78);
            this.dgvManageServices.Name = "dgvManageServices";
            this.dgvManageServices.ReadOnly = true;
            this.dgvManageServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManageServices.Size = new System.Drawing.Size(811, 357);
            this.dgvManageServices.TabIndex = 15;
            this.dgvManageServices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManageServices_CellContentClick);
            this.dgvManageServices.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvManageServices_DataError);
            this.dgvManageServices.SelectionChanged += new System.EventHandler(this.dgvManageServices_SelectionChanged);
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.Enabled = false;
            this.btnDeleteService.Location = new System.Drawing.Point(559, 20);
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(145, 40);
            this.btnDeleteService.TabIndex = 14;
            this.btnDeleteService.Text = "REMOVE SERVICE";
            this.btnDeleteService.UseVisualStyleBackColor = true;
            this.btnDeleteService.Click += new System.EventHandler(this.btnDeleteService_Click);
            // 
            // txtService
            // 
            this.txtService.Location = new System.Drawing.Point(6, 29);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(379, 25);
            this.txtService.TabIndex = 13;
            this.txtService.Text = "%";
            this.txtService.TextChanged += new System.EventHandler(this.txtService_TextChanged);
            // 
            // brnFindService
            // 
            this.brnFindService.Location = new System.Drawing.Point(400, 20);
            this.brnFindService.Name = "brnFindService";
            this.brnFindService.Size = new System.Drawing.Size(127, 40);
            this.brnFindService.TabIndex = 10;
            this.brnFindService.Text = "FIND SERVICE";
            this.brnFindService.UseVisualStyleBackColor = true;
            this.brnFindService.Click += new System.EventHandler(this.brnFindService_Click);
            // 
            // btnDeleteMachine
            // 
            this.btnDeleteMachine.Enabled = false;
            this.btnDeleteMachine.Location = new System.Drawing.Point(728, 19);
            this.btnDeleteMachine.Name = "btnDeleteMachine";
            this.btnDeleteMachine.Size = new System.Drawing.Size(158, 40);
            this.btnDeleteMachine.TabIndex = 10;
            this.btnDeleteMachine.Text = "REMOVE MACHINE";
            this.btnDeleteMachine.UseVisualStyleBackColor = true;
            this.btnDeleteMachine.Click += new System.EventHandler(this.btnDeleteMachine_Click);
            // 
            // chkIsWmi
            // 
            this.chkIsWmi.AutoSize = true;
            this.chkIsWmi.Checked = true;
            this.chkIsWmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsWmi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.chkIsWmi.FlatAppearance.BorderSize = 4;
            this.chkIsWmi.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.chkIsWmi.Location = new System.Drawing.Point(312, 30);
            this.chkIsWmi.Name = "chkIsWmi";
            this.chkIsWmi.Size = new System.Drawing.Size(54, 21);
            this.chkIsWmi.TabIndex = 11;
            this.chkIsWmi.Text = "WMI";
            this.chkIsWmi.UseVisualStyleBackColor = true;
            // 
            // lstServers
            // 
            this.lstServers.FormattingEnabled = true;
            this.lstServers.ItemHeight = 17;
            this.lstServers.Location = new System.Drawing.Point(24, 94);
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(326, 429);
            this.lstServers.TabIndex = 12;
            this.lstServers.SelectedIndexChanged += new System.EventHandler(this.lstServers_SelectedIndexChanged);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(892, 19);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(158, 40);
            this.btnSaveChanges.TabIndex = 13;
            this.btnSaveChanges.Text = "SAVE CHANGES";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // frmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 543);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.lstServers);
            this.Controls.Add(this.chkIsWmi);
            this.Controls.Add(this.btnDeleteMachine);
            this.Controls.Add(this.grpManageService);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddMachine);
            this.Controls.Add(this.chkMachineFound);
            this.Controls.Add(this.btnFindMachine);
            this.Controls.Add(this.txtMachine);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmManage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Servers & Services";
            this.Load += new System.EventHandler(this.frmManage_Load);
            this.grpManageService.ResumeLayout(false);
            this.grpManageService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.Button btnFindMachine;
        private System.Windows.Forms.CheckBox chkMachineFound;
        private System.Windows.Forms.Button btnAddMachine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpManageService;
        private System.Windows.Forms.Button btnDeleteService;
        private System.Windows.Forms.TextBox txtService;
        private System.Windows.Forms.Button brnFindService;
        private System.Windows.Forms.Button btnDeleteMachine;
        private System.Windows.Forms.DataGridView dgvManageServices;
        private System.Windows.Forms.CheckBox chkIsWmi;
        private System.Windows.Forms.ListBox lstServers;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}