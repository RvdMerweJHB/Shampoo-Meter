namespace Shampoo_Meter
{
    partial class Form1
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
            this.btnFindFiles = new System.Windows.Forms.Button();
            this.btnMoveFiles = new System.Windows.Forms.Button();
            this.btnImportFiles = new System.Windows.Forms.Button();
            this.lblLocateSSISPackage = new System.Windows.Forms.Label();
            this.btnCreateFileId = new System.Windows.Forms.Button();
            this.btnCreateCMFile = new System.Windows.Forms.Button();
            this.dgSuccsessFiles = new System.Windows.Forms.DataGridView();
            this.txtBeginID = new System.Windows.Forms.TextBox();
            this.txtEndID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbApnClients = new System.Windows.Forms.ComboBox();
            this.lblApnClientName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radXlsx = new System.Windows.Forms.RadioButton();
            this.radCsv = new System.Windows.Forms.RadioButton();
            this.dlgFolderLocationBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.txtSSISTemplateLocation = new System.Windows.Forms.TextBox();
            this.btnLocateSSISTemplate = new System.Windows.Forms.Button();
            this.dlgFileLocationBrowser = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOutputLocation = new System.Windows.Forms.TextBox();
            this.txtSSISConnectionString = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLocateFileOutputLocation = new System.Windows.Forms.Button();
            this.btnLocateFilePickupLocation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgSuccsessFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFindFiles
            // 
            this.btnFindFiles.Location = new System.Drawing.Point(29, 12);
            this.btnFindFiles.Name = "btnFindFiles";
            this.btnFindFiles.Size = new System.Drawing.Size(100, 23);
            this.btnFindFiles.TabIndex = 0;
            this.btnFindFiles.Text = "Find Files";
            this.btnFindFiles.UseVisualStyleBackColor = true;
            this.btnFindFiles.Click += new System.EventHandler(this.btnFindFiles_Click);
            // 
            // btnMoveFiles
            // 
            this.btnMoveFiles.Enabled = false;
            this.btnMoveFiles.Location = new System.Drawing.Point(29, 64);
            this.btnMoveFiles.Name = "btnMoveFiles";
            this.btnMoveFiles.Size = new System.Drawing.Size(99, 23);
            this.btnMoveFiles.TabIndex = 1;
            this.btnMoveFiles.Text = "Move Files";
            this.btnMoveFiles.UseVisualStyleBackColor = true;
            this.btnMoveFiles.Click += new System.EventHandler(this.btnMoveFiles_Click);
            // 
            // btnImportFiles
            // 
            this.btnImportFiles.Enabled = false;
            this.btnImportFiles.Location = new System.Drawing.Point(29, 91);
            this.btnImportFiles.Name = "btnImportFiles";
            this.btnImportFiles.Size = new System.Drawing.Size(100, 23);
            this.btnImportFiles.TabIndex = 2;
            this.btnImportFiles.Text = "Import Files to DB";
            this.btnImportFiles.UseVisualStyleBackColor = true;
            this.btnImportFiles.Click += new System.EventHandler(this.btnImportFiles_Click);
            // 
            // lblLocateSSISPackage
            // 
            this.lblLocateSSISPackage.AutoSize = true;
            this.lblLocateSSISPackage.Location = new System.Drawing.Point(180, 124);
            this.lblLocateSSISPackage.Name = "lblLocateSSISPackage";
            this.lblLocateSSISPackage.Size = new System.Drawing.Size(125, 13);
            this.lblLocateSSISPackage.TabIndex = 4;
            this.lblLocateSSISPackage.Text = "SSIS Template Location:";
            // 
            // btnCreateFileId
            // 
            this.btnCreateFileId.Enabled = false;
            this.btnCreateFileId.Location = new System.Drawing.Point(29, 144);
            this.btnCreateFileId.Name = "btnCreateFileId";
            this.btnCreateFileId.Size = new System.Drawing.Size(100, 23);
            this.btnCreateFileId.TabIndex = 5;
            this.btnCreateFileId.Text = "Create File ID\'s";
            this.btnCreateFileId.UseVisualStyleBackColor = true;
            this.btnCreateFileId.Click += new System.EventHandler(this.btnCreateFileId_Click);
            // 
            // btnCreateCMFile
            // 
            this.btnCreateCMFile.Location = new System.Drawing.Point(29, 455);
            this.btnCreateCMFile.Name = "btnCreateCMFile";
            this.btnCreateCMFile.Size = new System.Drawing.Size(121, 23);
            this.btnCreateCMFile.TabIndex = 6;
            this.btnCreateCMFile.Text = "Create CM File";
            this.btnCreateCMFile.UseVisualStyleBackColor = true;
            this.btnCreateCMFile.Click += new System.EventHandler(this.btnCreateCMFile_Click);
            // 
            // dgSuccsessFiles
            // 
            this.dgSuccsessFiles.AllowUserToAddRows = false;
            this.dgSuccsessFiles.AllowUserToDeleteRows = false;
            this.dgSuccsessFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSuccsessFiles.Location = new System.Drawing.Point(152, 172);
            this.dgSuccsessFiles.Name = "dgSuccsessFiles";
            this.dgSuccsessFiles.ReadOnly = true;
            this.dgSuccsessFiles.Size = new System.Drawing.Size(454, 232);
            this.dgSuccsessFiles.TabIndex = 7;
            // 
            // txtBeginID
            // 
            this.txtBeginID.Location = new System.Drawing.Point(156, 429);
            this.txtBeginID.Name = "txtBeginID";
            this.txtBeginID.Size = new System.Drawing.Size(100, 20);
            this.txtBeginID.TabIndex = 8;
            // 
            // txtEndID
            // 
            this.txtEndID.Location = new System.Drawing.Point(262, 429);
            this.txtEndID.Name = "txtEndID";
            this.txtEndID.Size = new System.Drawing.Size(100, 20);
            this.txtEndID.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "BeginID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "EndID:";
            // 
            // cmbApnClients
            // 
            this.cmbApnClients.FormattingEnabled = true;
            this.cmbApnClients.Location = new System.Drawing.Point(29, 429);
            this.cmbApnClients.Name = "cmbApnClients";
            this.cmbApnClients.Size = new System.Drawing.Size(121, 21);
            this.cmbApnClients.TabIndex = 12;
            // 
            // lblApnClientName
            // 
            this.lblApnClientName.AutoSize = true;
            this.lblApnClientName.Location = new System.Drawing.Point(28, 413);
            this.lblApnClientName.Name = "lblApnClientName";
            this.lblApnClientName.Size = new System.Drawing.Size(92, 13);
            this.lblApnClientName.TabIndex = 13;
            this.lblApnClientName.Text = "APN Client Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Successful File Imports:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "1.";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Enabled = false;
            this.lbl2.Location = new System.Drawing.Point(9, 69);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(16, 13);
            this.lbl2.TabIndex = 16;
            this.lbl2.Text = "2.";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Enabled = false;
            this.lbl3.Location = new System.Drawing.Point(9, 91);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(16, 13);
            this.lbl3.TabIndex = 17;
            this.lbl3.Text = "3.";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Enabled = false;
            this.lbl4.Location = new System.Drawing.Point(9, 149);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(16, 13);
            this.lbl4.TabIndex = 18;
            this.lbl4.Text = "4.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "(This action requires connection to the Lookup DB)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Output Format:";
            // 
            // radXlsx
            // 
            this.radXlsx.AutoSize = true;
            this.radXlsx.Location = new System.Drawing.Point(363, 15);
            this.radXlsx.Name = "radXlsx";
            this.radXlsx.Size = new System.Drawing.Size(45, 17);
            this.radXlsx.TabIndex = 22;
            this.radXlsx.Text = ".xlsx";
            this.radXlsx.UseVisualStyleBackColor = true;
            // 
            // radCsv
            // 
            this.radCsv.AutoSize = true;
            this.radCsv.Checked = true;
            this.radCsv.Location = new System.Drawing.Point(310, 15);
            this.radCsv.Name = "radCsv";
            this.radCsv.Size = new System.Drawing.Size(45, 17);
            this.radCsv.TabIndex = 23;
            this.radCsv.TabStop = true;
            this.radCsv.Text = ".csv";
            this.radCsv.UseVisualStyleBackColor = true;
            // 
            // txtSSISTemplateLocation
            // 
            this.txtSSISTemplateLocation.Location = new System.Drawing.Point(310, 120);
            this.txtSSISTemplateLocation.Name = "txtSSISTemplateLocation";
            this.txtSSISTemplateLocation.Size = new System.Drawing.Size(266, 20);
            this.txtSSISTemplateLocation.TabIndex = 24;
            this.txtSSISTemplateLocation.Text = "Please select...";
            // 
            // btnLocateSSISTemplate
            // 
            this.btnLocateSSISTemplate.Location = new System.Drawing.Point(582, 120);
            this.btnLocateSSISTemplate.Name = "btnLocateSSISTemplate";
            this.btnLocateSSISTemplate.Size = new System.Drawing.Size(24, 20);
            this.btnLocateSSISTemplate.TabIndex = 25;
            this.btnLocateSSISTemplate.Text = "...";
            this.btnLocateSSISTemplate.UseVisualStyleBackColor = true;
            this.btnLocateSSISTemplate.Click += new System.EventHandler(this.btnLocateSSISTemplate_Click);
            // 
            // dlgFileLocationBrowser
            // 
            this.dlgFileLocationBrowser.FileName = "openFileDialog1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "APN DB Connection String:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(310, 146);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(296, 20);
            this.txtConnectionString.TabIndex = 27;
            this.txtConnectionString.Text = "Please supply connection string...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(202, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "File Pickup location:";
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(310, 41);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(266, 20);
            this.txtFileLocation.TabIndex = 29;
            this.txtFileLocation.Text = "C:\\MTN APN Data Files\\";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(203, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "File Output location:";
            // 
            // txtOutputLocation
            // 
            this.txtOutputLocation.Location = new System.Drawing.Point(310, 68);
            this.txtOutputLocation.Name = "txtOutputLocation";
            this.txtOutputLocation.Size = new System.Drawing.Size(266, 20);
            this.txtOutputLocation.TabIndex = 31;
            this.txtOutputLocation.Text = "C:\\NewDatLocation";
            this.txtOutputLocation.TextChanged += new System.EventHandler(this.txtOutputLocation_TextChanged);
            // 
            // txtSSISConnectionString
            // 
            this.txtSSISConnectionString.Location = new System.Drawing.Point(310, 94);
            this.txtSSISConnectionString.Name = "txtSSISConnectionString";
            this.txtSSISConnectionString.Size = new System.Drawing.Size(296, 20);
            this.txtSSISConnectionString.TabIndex = 32;
            this.txtSSISConnectionString.Text = "Data Source=VM_DEV;Initial Catalog=APN_DATA;Provider=SQLNCLI11;Integrated Securit" +
    "y=SSPI;Auto Translate=false;";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(184, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "SSIS Connection String:";
            // 
            // btnLocateFileOutputLocation
            // 
            this.btnLocateFileOutputLocation.Location = new System.Drawing.Point(582, 67);
            this.btnLocateFileOutputLocation.Name = "btnLocateFileOutputLocation";
            this.btnLocateFileOutputLocation.Size = new System.Drawing.Size(24, 21);
            this.btnLocateFileOutputLocation.TabIndex = 34;
            this.btnLocateFileOutputLocation.Text = "...";
            this.btnLocateFileOutputLocation.UseVisualStyleBackColor = true;
            this.btnLocateFileOutputLocation.Click += new System.EventHandler(this.btnLocateFileOutputLocation_Click);
            // 
            // btnLocateFilePickupLocation
            // 
            this.btnLocateFilePickupLocation.Location = new System.Drawing.Point(582, 41);
            this.btnLocateFilePickupLocation.Name = "btnLocateFilePickupLocation";
            this.btnLocateFilePickupLocation.Size = new System.Drawing.Size(24, 20);
            this.btnLocateFilePickupLocation.TabIndex = 35;
            this.btnLocateFilePickupLocation.Text = "...";
            this.btnLocateFilePickupLocation.UseVisualStyleBackColor = true;
            this.btnLocateFilePickupLocation.Click += new System.EventHandler(this.btnLocateFilePickupLocation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(618, 491);
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
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblApnClientName);
            this.Controls.Add(this.cmbApnClients);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEndID);
            this.Controls.Add(this.txtBeginID);
            this.Controls.Add(this.dgSuccsessFiles);
            this.Controls.Add(this.btnCreateCMFile);
            this.Controls.Add(this.btnCreateFileId);
            this.Controls.Add(this.lblLocateSSISPackage);
            this.Controls.Add(this.btnImportFiles);
            this.Controls.Add(this.btnMoveFiles);
            this.Controls.Add(this.btnFindFiles);
            this.Name = "Form1";
            this.Text = "Welcome to the Shampoo Meter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSuccsessFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindFiles;
        private System.Windows.Forms.Button btnMoveFiles;
        private System.Windows.Forms.Button btnImportFiles;
        private System.Windows.Forms.Label lblLocateSSISPackage;
        private System.Windows.Forms.Button btnCreateFileId;
        private System.Windows.Forms.Button btnCreateCMFile;
        private System.Windows.Forms.DataGridView dgSuccsessFiles;
        private System.Windows.Forms.TextBox txtBeginID;
        private System.Windows.Forms.TextBox txtEndID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbApnClients;
        private System.Windows.Forms.Label lblApnClientName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radXlsx;
        private System.Windows.Forms.RadioButton radCsv;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderLocationBrowser;
        private System.Windows.Forms.TextBox txtSSISTemplateLocation;
        private System.Windows.Forms.Button btnLocateSSISTemplate;
        private System.Windows.Forms.OpenFileDialog dlgFileLocationBrowser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOutputLocation;
        private System.Windows.Forms.TextBox txtSSISConnectionString;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLocateFileOutputLocation;
        private System.Windows.Forms.Button btnLocateFilePickupLocation;
    }
}

