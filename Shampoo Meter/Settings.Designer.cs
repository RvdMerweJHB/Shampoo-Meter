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
            this.SuspendLayout();
            // 
            // btnLocateFilePickupLocation
            // 
            this.btnLocateFilePickupLocation.Location = new System.Drawing.Point(419, 36);
            this.btnLocateFilePickupLocation.Name = "btnLocateFilePickupLocation";
            this.btnLocateFilePickupLocation.Size = new System.Drawing.Size(24, 20);
            this.btnLocateFilePickupLocation.TabIndex = 51;
            this.btnLocateFilePickupLocation.Text = "...";
            this.btnLocateFilePickupLocation.UseVisualStyleBackColor = true;
            this.btnLocateFilePickupLocation.Click += new System.EventHandler(this.btnLocateFilePickupLocation_Click);
            // 
            // btnLocateFileOutputLocation
            // 
            this.btnLocateFileOutputLocation.Location = new System.Drawing.Point(419, 62);
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
            this.label10.Location = new System.Drawing.Point(21, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "SSIS Connection String:";
            // 
            // txtSSISConnectionString
            // 
            this.txtSSISConnectionString.Location = new System.Drawing.Point(147, 89);
            this.txtSSISConnectionString.Name = "txtSSISConnectionString";
            this.txtSSISConnectionString.Size = new System.Drawing.Size(296, 20);
            this.txtSSISConnectionString.TabIndex = 48;
            this.txtSSISConnectionString.Text = "Please Supply...";
            // 
            // txtOutputLocation
            // 
            this.txtOutputLocation.Location = new System.Drawing.Point(147, 63);
            this.txtOutputLocation.Name = "txtOutputLocation";
            this.txtOutputLocation.Size = new System.Drawing.Size(266, 20);
            this.txtOutputLocation.TabIndex = 47;
            this.txtOutputLocation.Text = "Please Supply...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "File Output location:";
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(147, 36);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(266, 20);
            this.txtFileLocation.TabIndex = 45;
            this.txtFileLocation.Text = "Please Supply...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "File Pickup location:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(147, 141);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(296, 20);
            this.txtConnectionString.TabIndex = 43;
            this.txtConnectionString.Text = "Please Supply...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "APN DB Connection String:";
            // 
            // btnLocateSSISTemplate
            // 
            this.btnLocateSSISTemplate.Location = new System.Drawing.Point(419, 115);
            this.btnLocateSSISTemplate.Name = "btnLocateSSISTemplate";
            this.btnLocateSSISTemplate.Size = new System.Drawing.Size(24, 20);
            this.btnLocateSSISTemplate.TabIndex = 41;
            this.btnLocateSSISTemplate.Text = "...";
            this.btnLocateSSISTemplate.UseVisualStyleBackColor = true;
            this.btnLocateSSISTemplate.Click += new System.EventHandler(this.btnLocateSSISTemplate_Click);
            // 
            // txtSSISTemplateLocation
            // 
            this.txtSSISTemplateLocation.Location = new System.Drawing.Point(147, 115);
            this.txtSSISTemplateLocation.Name = "txtSSISTemplateLocation";
            this.txtSSISTemplateLocation.Size = new System.Drawing.Size(266, 20);
            this.txtSSISTemplateLocation.TabIndex = 40;
            this.txtSSISTemplateLocation.Text = "Please Supply...";
            // 
            // radCsv
            // 
            this.radCsv.AutoSize = true;
            this.radCsv.Checked = true;
            this.radCsv.Location = new System.Drawing.Point(147, 10);
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
            this.radXlsx.Location = new System.Drawing.Point(200, 10);
            this.radXlsx.Name = "radXlsx";
            this.radXlsx.Size = new System.Drawing.Size(45, 17);
            this.radXlsx.TabIndex = 38;
            this.radXlsx.Text = ".xlsx";
            this.radXlsx.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Output Format:";
            // 
            // lblLocateSSISPackage
            // 
            this.lblLocateSSISPackage.AutoSize = true;
            this.lblLocateSSISPackage.Location = new System.Drawing.Point(17, 119);
            this.lblLocateSSISPackage.Name = "lblLocateSSISPackage";
            this.lblLocateSSISPackage.Size = new System.Drawing.Size(125, 13);
            this.lblLocateSSISPackage.TabIndex = 36;
            this.lblLocateSSISPackage.Text = "SSIS Template Location:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(368, 167);
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
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 208);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnLocateFilePickupLocation);
            this.Controls.Add(this.btnLocateFileOutputLocation);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSSISConnectionString);
            this.Controls.Add(this.txtOutputLocation);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFileLocation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLocateSSISTemplate);
            this.Controls.Add(this.txtSSISTemplateLocation);
            this.Controls.Add(this.radCsv);
            this.Controls.Add(this.radXlsx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLocateSSISPackage);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}