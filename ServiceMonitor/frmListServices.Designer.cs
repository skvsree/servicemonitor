namespace ServiceMonitor
{
    partial class frmListServices
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
            this.lstServers = new System.Windows.Forms.CheckedListBox();
            this.btnFindMachine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstServers
            // 
            this.lstServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstServers.FormattingEnabled = true;
            this.lstServers.Location = new System.Drawing.Point(12, 56);
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(551, 524);
            this.lstServers.TabIndex = 7;
            this.lstServers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstServers_ItemCheck);
            // 
            // btnFindMachine
            // 
            this.btnFindMachine.Enabled = false;
            this.btnFindMachine.Location = new System.Drawing.Point(12, 10);
            this.btnFindMachine.Name = "btnFindMachine";
            this.btnFindMachine.Size = new System.Drawing.Size(213, 40);
            this.btnFindMachine.TabIndex = 8;
            this.btnFindMachine.Text = "ADD THE SERVICES";
            this.btnFindMachine.UseVisualStyleBackColor = true;
            this.btnFindMachine.Click += new System.EventHandler(this.btnFindMachine_Click);
            // 
            // frmListServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 597);
            this.Controls.Add(this.btnFindMachine);
            this.Controls.Add(this.lstServers);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListServices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Of Services";
            this.Load += new System.EventHandler(this.frmListServices_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstServers;
        private System.Windows.Forms.Button btnFindMachine;
    }
}