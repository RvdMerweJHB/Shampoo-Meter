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
            this.btnSettings = new System.Windows.Forms.Button();
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabProcessDatFiles = new System.Windows.Forms.TabPage();
            this.tabCMFilesCreate = new System.Windows.Forms.TabPage();
            this.prgStatus = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSuccsessFiles)).BeginInit();
            this.tabOptions.SuspendLayout();
            this.tabProcessDatFiles.SuspendLayout();
            this.tabCMFilesCreate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFindFiles
            // 
            this.btnFindFiles.Location = new System.Drawing.Point(20, 6);
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
            this.btnMoveFiles.Location = new System.Drawing.Point(21, 35);
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
            this.btnImportFiles.Location = new System.Drawing.Point(20, 64);
            this.btnImportFiles.Name = "btnImportFiles";
            this.btnImportFiles.Size = new System.Drawing.Size(100, 23);
            this.btnImportFiles.TabIndex = 2;
            this.btnImportFiles.Text = "Import Files to DB";
            this.btnImportFiles.UseVisualStyleBackColor = true;
            this.btnImportFiles.Click += new System.EventHandler(this.btnImportFiles_Click);
            // 
            // btnCreateFileId
            // 
            this.btnCreateFileId.Enabled = false;
            this.btnCreateFileId.Location = new System.Drawing.Point(21, 93);
            this.btnCreateFileId.Name = "btnCreateFileId";
            this.btnCreateFileId.Size = new System.Drawing.Size(100, 23);
            this.btnCreateFileId.TabIndex = 5;
            this.btnCreateFileId.Text = "Create File ID\'s";
            this.btnCreateFileId.UseVisualStyleBackColor = true;
            this.btnCreateFileId.Click += new System.EventHandler(this.btnCreateFileId_Click);
            // 
            // btnCreateCMFile
            // 
            this.btnCreateCMFile.Location = new System.Drawing.Point(7, 56);
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
            this.dgSuccsessFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSuccsessFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSuccsessFiles.Location = new System.Drawing.Point(9, 144);
            this.dgSuccsessFiles.Name = "dgSuccsessFiles";
            this.dgSuccsessFiles.ReadOnly = true;
            this.dgSuccsessFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgSuccsessFiles.Size = new System.Drawing.Size(588, 266);
            this.dgSuccsessFiles.TabIndex = 7;
            // 
            // txtBeginID
            // 
            this.txtBeginID.Location = new System.Drawing.Point(131, 29);
            this.txtBeginID.Name = "txtBeginID";
            this.txtBeginID.Size = new System.Drawing.Size(100, 20);
            this.txtBeginID.TabIndex = 8;
            // 
            // txtEndID
            // 
            this.txtEndID.Location = new System.Drawing.Point(237, 29);
            this.txtEndID.Name = "txtEndID";
            this.txtEndID.Size = new System.Drawing.Size(100, 20);
            this.txtEndID.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "BeginID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "EndID:";
            // 
            // cmbApnClients
            // 
            this.cmbApnClients.FormattingEnabled = true;
            this.cmbApnClients.Location = new System.Drawing.Point(6, 29);
            this.cmbApnClients.Name = "cmbApnClients";
            this.cmbApnClients.Size = new System.Drawing.Size(121, 21);
            this.cmbApnClients.TabIndex = 12;
            // 
            // lblApnClientName
            // 
            this.lblApnClientName.AutoSize = true;
            this.lblApnClientName.Location = new System.Drawing.Point(7, 14);
            this.lblApnClientName.Name = "lblApnClientName";
            this.lblApnClientName.Size = new System.Drawing.Size(92, 13);
            this.lblApnClientName.TabIndex = 13;
            this.lblApnClientName.Text = "APN Client Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Successful File Imports:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "1.";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Enabled = false;
            this.lbl2.Location = new System.Drawing.Point(6, 40);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(16, 13);
            this.lbl2.TabIndex = 16;
            this.lbl2.Text = "2.";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Enabled = false;
            this.lbl3.Location = new System.Drawing.Point(5, 69);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(16, 13);
            this.lbl3.TabIndex = 17;
            this.lbl3.Text = "3.";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Enabled = false;
            this.lbl4.Location = new System.Drawing.Point(6, 98);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(16, 13);
            this.lbl4.TabIndex = 18;
            this.lbl4.Text = "4.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "(This action requires connection to the Lookup DB)";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(537, 462);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 20;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tabProcessDatFiles);
            this.tabOptions.Controls.Add(this.tabCMFilesCreate);
            this.tabOptions.Location = new System.Drawing.Point(1, 12);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(615, 445);
            this.tabOptions.TabIndex = 21;
            // 
            // tabProcessDatFiles
            // 
            this.tabProcessDatFiles.Controls.Add(this.btnFindFiles);
            this.tabProcessDatFiles.Controls.Add(this.label4);
            this.tabProcessDatFiles.Controls.Add(this.btnMoveFiles);
            this.tabProcessDatFiles.Controls.Add(this.dgSuccsessFiles);
            this.tabProcessDatFiles.Controls.Add(this.label3);
            this.tabProcessDatFiles.Controls.Add(this.lbl4);
            this.tabProcessDatFiles.Controls.Add(this.lbl2);
            this.tabProcessDatFiles.Controls.Add(this.lbl3);
            this.tabProcessDatFiles.Controls.Add(this.btnImportFiles);
            this.tabProcessDatFiles.Controls.Add(this.btnCreateFileId);
            this.tabProcessDatFiles.Location = new System.Drawing.Point(4, 22);
            this.tabProcessDatFiles.Name = "tabProcessDatFiles";
            this.tabProcessDatFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcessDatFiles.Size = new System.Drawing.Size(607, 419);
            this.tabProcessDatFiles.TabIndex = 0;
            this.tabProcessDatFiles.Text = "Process New .dat Files";
            this.tabProcessDatFiles.UseVisualStyleBackColor = true;
            // 
            // tabCMFilesCreate
            // 
            this.tabCMFilesCreate.Controls.Add(this.lblApnClientName);
            this.tabCMFilesCreate.Controls.Add(this.label1);
            this.tabCMFilesCreate.Controls.Add(this.label5);
            this.tabCMFilesCreate.Controls.Add(this.label2);
            this.tabCMFilesCreate.Controls.Add(this.cmbApnClients);
            this.tabCMFilesCreate.Controls.Add(this.txtBeginID);
            this.tabCMFilesCreate.Controls.Add(this.txtEndID);
            this.tabCMFilesCreate.Controls.Add(this.btnCreateCMFile);
            this.tabCMFilesCreate.Location = new System.Drawing.Point(4, 22);
            this.tabCMFilesCreate.Name = "tabCMFilesCreate";
            this.tabCMFilesCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tabCMFilesCreate.Size = new System.Drawing.Size(607, 419);
            this.tabCMFilesCreate.TabIndex = 1;
            this.tabCMFilesCreate.Text = "Create CM Files";
            this.tabCMFilesCreate.UseVisualStyleBackColor = true;
            // 
            // prgStatus
            // 
            this.prgStatus.Location = new System.Drawing.Point(56, 462);
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(475, 23);
            this.prgStatus.TabIndex = 19;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 467);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(618, 491);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.prgStatus);
            this.Controls.Add(this.tabOptions);
            this.Controls.Add(this.btnSettings);
            this.Name = "Form1";
            this.Text = "Welcome to the Shampoo Meter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSuccsessFiles)).EndInit();
            this.tabOptions.ResumeLayout(false);
            this.tabProcessDatFiles.ResumeLayout(false);
            this.tabProcessDatFiles.PerformLayout();
            this.tabCMFilesCreate.ResumeLayout(false);
            this.tabCMFilesCreate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindFiles;
        private System.Windows.Forms.Button btnMoveFiles;
        private System.Windows.Forms.Button btnImportFiles;
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
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabProcessDatFiles;
        private System.Windows.Forms.TabPage tabCMFilesCreate;
        private System.Windows.Forms.ProgressBar prgStatus;
        private System.Windows.Forms.Label lblStatus;
    }
}

