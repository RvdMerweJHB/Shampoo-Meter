namespace Shampoo_Meter
{
    partial class Settings
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
            this.btnLocateFilePickupLocation = new System.Windows.Forms.Button();
            this.btnLocateFileOutputLocation = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSSISConnectionString = new System.Windows.Forms.TextBox();
            this.txtOutputLocation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLocateSSISTemplate = new System.Windows.Forms.Button();
            this.txtSSISTemplateLocation = new System.Windows.Forms.TextBox();
            this.radCsv = new System.Windows.Forms.RadioButton();
            this.radXlsx = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLocateSSISPackage = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dlgFolderLocationBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgFileLocationBrowser = new System.Windows.Forms.OpenFileDialog();
            this.grpAuditSettings = new System.Windows.Forms.GroupBox();
            this.cmbAuditType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocateLogFileDir = new System.Windows.Forms.Button();
            this.txtLogFileLocation = new System.Windows.Forms.TextBox();
            this.lblLogFileLocation = new System.Windows.Forms.Label();
            this.btnLocateAuditFile = new System.Windows.Forms.Button();
            this.txtAuditFileLocation = new System.Windows.Forms.TextBox();
            this.lblAuditFIleLocation = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpAuditSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLocateFilePickupLocation
            // 
            this.btnLocateFilePickupLocation.Location = new System.Drawing.Point(520, 18);
            this.btnLocateFilePickupLocation.Name = "btnLocateFilePickupLocation";
            this.btnLocateFilePickupLocation.Size = new System.Drawing.Size(24, 20);
            this.btnLocateFilePickupLocation.TabIndex = 51;
            this.btnLocateFilePickupLocation.Text = "...";
            this.btnLocateFilePickupLocation.UseVisualStyleBackColor = true;
            this.btnLocateFilePickupLocation.Click += new System.EventHandler(this.btnLocateFilePickupLocation_Click);
            // 
            // btnLocateFileOutputLocation
            // 
            this.btnLocateFileOutputLocation.Location = new System.Drawing.Point(520, 42);
            this.btnLocateFileOutputLocation.Name = "btnLocateFileOutputLocation";
            this.btnLocateFileOutputLocation.Size = new System.Drawing.Size(24, 21);
            this.btnLocateFileOutputLocation.TabIndex = 50;
            this.btnLocateFileOutputLocation.Text = "...";
            this.btnLocateFileOutputLocation.UseVisualStyleBackColor = true;
            this.btnLocateFileOutputLocation.Click += new System.EventHandler(this.btnLocateFileOutputLocation_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "SSIS Connection String:";
            // 
            // txtSSISConnectionString
            // 
            this.txtSSISConnectionString.Location = new System.Drawing.Point(147, 71);
            this.txtSSISConnectionString.Name = "txtSSISConnectionString";
            this.txtSSISConnectionString.Size = new System.Drawing.Size(397, 20);
            this.txtSSISConnectionString.TabIndex = 48;
            this.txtSSISConnectionString.Text = "Please Supply...";
            // 
            // txtOutputLocation
            // 
            this.txtOutputLocation.Location = new System.Drawing.Point(147, 43);
            this.txtOutputLocation.Name = "txtOutputLocation";
            this.txtOutputLocation.Size = new System.Drawing.Size(367, 20);
            this.txtOutputLocation.TabIndex = 47;
            this.txtOutputLocation.Text = "Please Supply...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = ".dat File Output location:";
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(147, 18);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(367, 20);
            this.txtFileLocation.TabIndex = 45;
            this.txtFileLocation.Text = "Please Supply...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = ".dat File Pickup location:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(147, 124);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(397, 20);
            this.txtConnectionString.TabIndex = 43;
            this.txtConnectionString.Text = "Please Supply...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "APN DB Connection String:";
            // 
            // btnLocateSSISTemplate
            // 
            this.btnLocateSSISTemplate.Location = new System.Drawing.Point(520, 98);
            this.btnLocateSSISTemplate.Name = "btnLocateSSISTemplate";
            this.btnLocateSSISTemplate.Size = new System.Drawing.Size(24, 20);
            this.btnLocateSSISTemplate.TabIndex = 41;
            this.btnLocateSSISTemplate.Text = "...";
            this.btnLocateSSISTemplate.UseVisualStyleBackColor = true;
            this.btnLocateSSISTemplate.Click += new System.EventHandler(this.btnLocateSSISTemplate_Click);
            // 
            // txtSSISTemplateLocation
            // 
            this.txtSSISTemplateLocation.Location = new System.Drawing.Point(147, 98);
            this.txtSSISTemplateLocation.Name = "txtSSISTemplateLocation";
            this.txtSSISTemplateLocation.Size = new System.Drawing.Size(367, 20);
            this.txtSSISTemplateLocation.TabIndex = 40;
            this.txtSSISTemplateLocation.Text = "Please Supply...";
            // 
            // radCsv
            // 
            this.radCsv.AutoSize = true;
            this.radCsv.Checked = true;
            this.radCsv.Location = new System.Drawing.Point(147, 104);
            this.radCsv.Name = "radCsv";
            this.radCsv.Size = new System.Drawing.Size(45, 17);
            this.radCsv.TabIndex = 39;
            this.radCsv.TabStop = true;
            this.radCsv.Text = ".csv";
            this.radCsv.UseVisualStyleBackColor = true;
            // 
            // radXlsx
            // 
            this.radXlsx.AutoSize = true;
            this.radXlsx.Enabled = false;
            this.radXlsx.Location = new System.Drawing.Point(198, 104);
            this.radXlsx.Name = "radXlsx";
            this.radXlsx.Size = new System.Drawing.Size(45, 17);
            this.radXlsx.TabIndex = 38;
            this.radXlsx.Text = ".xlsx";
            this.radXlsx.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Output Format:";
            // 
            // lblLocateSSISPackage
            // 
            this.lblLocateSSISPackage.AutoSize = true;
            this.lblLocateSSISPackage.Location = new System.Drawing.Point(16, 101);
            this.lblLocateSSISPackage.Name = "lblLocateSSISPackage";
            this.lblLocateSSISPackage.Size = new System.Drawing.Size(125, 13);
            this.lblLocateSSISPackage.TabIndex = 36;
            this.lblLocateSSISPackage.Text = "SSIS Template Location:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(489, 315);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 52;
            this.btnUpdate.Text = "Update Settings";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dlgFileLocationBrowser
            // 
            this.dlgFileLocationBrowser.FileName = "openFileDialog1";
            // 
            // grpAuditSettings
            // 
            this.grpAuditSettings.Controls.Add(this.cmbAuditType);
            this.grpAuditSettings.Controls.Add(this.label1);
            this.grpAuditSettings.Controls.Add(this.btnLocateLogFileDir);
            this.grpAuditSettings.Controls.Add(this.txtLogFileLocation);
            this.grpAuditSettings.Controls.Add(this.lblLogFileLocation);
            this.grpAuditSettings.Controls.Add(this.btnLocateAuditFile);
            this.grpAuditSettings.Controls.Add(this.txtAuditFileLocation);
            this.grpAuditSettings.Controls.Add(this.lblAuditFIleLocation);
            this.grpAuditSettings.Controls.Add(this.radCsv);
            this.grpAuditSettings.Controls.Add(this.radXlsx);
            this.grpAuditSettings.Controls.Add(this.label6);
            this.grpAuditSettings.Location = new System.Drawing.Point(12, 172);
            this.grpAuditSettings.Name = "grpAuditSettings";
            this.grpAuditSettings.Size = new System.Drawing.Size(550, 134);
            this.grpAuditSettings.TabIndex = 53;
            this.grpAuditSettings.TabStop = false;
            this.grpAuditSettings.Text = "Audit Settings";
            // 
            // cmbAuditType
            // 
            this.cmbAuditType.FormattingEnabled = true;
            this.cmbAuditType.Items.AddRange(new object[] {
            "Full (Use Audit File, and Self Check)",
            "Self Check Only"});
            this.cmbAuditType.Location = new System.Drawing.Point(147, 25);
            this.cmbAuditType.Name = "cmbAuditType";
            this.cmbAuditType.Size = new System.Drawing.Size(397, 21);
            this.cmbAuditType.TabIndex = 57;
            this.cmbAuditType.SelectedIndexChanged += new System.EventHandler(this.cmbAuditType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Audit Type:";
            // 
            // btnLocateLogFileDir
            // 
            this.btnLocateLogFileDir.Location = new System.Drawing.Point(520, 78);
            this.btnLocateLogFileDir.Name = "btnLocateLogFileDir";
            this.btnLocateLogFileDir.Size = new System.Drawing.Size(24, 20);
            this.btnLocateLogFileDir.TabIndex = 55;
            this.btnLocateLogFileDir.Text = "...";
            this.btnLocateLogFileDir.UseVisualStyleBackColor = true;
            this.btnLocateLogFileDir.Click += new System.EventHandler(this.btnLocateLogFileDir_Click);
            // 
            // txtLogFileLocation
            // 
            this.txtLogFileLocation.Location = new System.Drawing.Point(147, 78);
            this.txtLogFileLocation.Name = "txtLogFileLocation";
            this.txtLogFileLocation.Size = new System.Drawing.Size(367, 20);
            this.txtLogFileLocation.TabIndex = 54;
            this.txtLogFileLocation.Text = "Please Supply...";
            // 
            // lblLogFileLocation
            // 
            this.lblLogFileLocation.AutoSize = true;
            this.lblLogFileLocation.Location = new System.Drawing.Point(57, 81);
            this.lblLogFileLocation.Name = "lblLogFileLocation";
            this.lblLogFileLocation.Size = new System.Drawing.Size(87, 13);
            this.lblLogFileLocation.TabIndex = 53;
            this.lblLogFileLocation.Text = "Log File location:";
            // 
            // btnLocateAuditFile
            // 
            this.btnLocateAuditFile.Location = new System.Drawing.Point(520, 52);
            this.btnLocateAuditFile.Name = "btnLocateAuditFile";
            this.btnLocateAuditFile.Size = new System.Drawing.Size(24, 20);
            this.btnLocateAuditFile.TabIndex = 52;
            this.btnLocateAuditFile.Text = "...";
            this.btnLocateAuditFile.UseVisualStyleBackColor = true;
            this.btnLocateAuditFile.Click += new System.EventHandler(this.btnLocateAuditFile_Click);
            // 
            // txtAuditFileLocation
            // 
            this.txtAuditFileLocation.Location = new System.Drawing.Point(147, 52);
            this.txtAuditFileLocation.Name = "txtAuditFileLocation";
            this.txtAuditFileLocation.Size = new System.Drawing.Size(367, 20);
            this.txtAuditFileLocation.TabIndex = 48;
            this.txtAuditFileLocation.Text = "Please Supply...";
            // 
            // lblAuditFIleLocation
            // 
            this.lblAuditFIleLocation.AutoSize = true;
            this.lblAuditFIleLocation.Location = new System.Drawing.Point(54, 56);
            this.lblAuditFIleLocation.Name = "lblAuditFIleLocation";
            this.lblAuditFIleLocation.Size = new System.Drawing.Size(90, 13);
            this.lblAuditFIleLocation.TabIndex = 45;
            this.lblAuditFIleLocation.Text = "AuditFile location:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtFileLocation);
            this.groupBox2.Controls.Add(this.txtConnectionString);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnLocateFilePickupLocation);
            this.groupBox2.Controls.Add(this.btnLocateFileOutputLocation);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblLocateSSISPackage);
            this.groupBox2.Controls.Add(this.txtSSISTemplateLocation);
            this.groupBox2.Controls.Add(this.btnLocateSSISTemplate);
            this.groupBox2.Controls.Add(this.txtOutputLocation);
            this.groupBox2.Controls.Add(this.txtSSISConnectionString);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 154);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Settings";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 347);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpAuditSettings);
            this.Controls.Add(this.btnUpdate);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.grpAuditSettings.ResumeLayout(false);
            this.grpAuditSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLocateFilePickupLocation;
        private System.Windows.Forms.Button btnLocateFileOutputLocation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSSISConnectionString;
        private System.Windows.Forms.TextBox txtOutputLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLocateSSISTemplate;
        private System.Windows.Forms.TextBox txtSSISTemplateLocation;
        private System.Windows.Forms.RadioButton radCsv;
        private System.Windows.Forms.RadioButton radXlsx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLocateSSISPackage;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderLocationBrowser;
        private System.Windows.Forms.OpenFileDialog dlgFileLocationBrowser;
        private System.Windows.Forms.GroupBox grpAuditSettings;
        private System.Windows.Forms.Button btnLocateLogFileDir;
        private System.Windows.Forms.TextBox txtLogFileLocation;
        private System.Windows.Forms.Label lblLogFileLocation;
        private System.Windows.Forms.Button btnLocateAuditFile;
        private System.Windows.Forms.TextBox txtAuditFileLocation;
        private System.Windows.Forms.Label lblAuditFIleLocation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAuditType;
    }
}