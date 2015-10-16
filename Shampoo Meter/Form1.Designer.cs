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
            this.btnMoveFiles.Location = new System.Drawing.Point(30, 41);
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
            this.btnImportFiles.Location = new System.Drawing.Point(29, 70);
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
            this.btnCreateFileId.Location = new System.Drawing.Point(29, 99);
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
            this.dgSuccsessFiles.Location = new System.Drawing.Point(29, 141);
            this.dgSuccsessFiles.Name = "dgSuccsessFiles";
            this.dgSuccsessFiles.ReadOnly = true;
            this.dgSuccsessFiles.Size = new System.Drawing.Size(196, 232);
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
            this.label3.Location = new System.Drawing.Point(26, 125);
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
            this.lbl2.Location = new System.Drawing.Point(9, 46);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(16, 13);
            this.lbl2.TabIndex = 16;
            this.lbl2.Text = "2.";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Enabled = false;
            this.lbl3.Location = new System.Drawing.Point(9, 75);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(16, 13);
            this.lbl3.TabIndex = 17;
            this.lbl3.Text = "3.";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Enabled = false;
            this.lbl4.Location = new System.Drawing.Point(9, 104);
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
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(531, 455);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 20;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(618, 491);
            this.Controls.Add(this.btnSettings);
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
    }
}

