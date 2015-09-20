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
            ((System.ComponentModel.ISupportInitialize)(this.dgSuccsessFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFindFiles
            // 
            this.btnFindFiles.Location = new System.Drawing.Point(12, 12);
            this.btnFindFiles.Name = "btnFindFiles";
            this.btnFindFiles.Size = new System.Drawing.Size(75, 23);
            this.btnFindFiles.TabIndex = 0;
            this.btnFindFiles.Text = "Find Files";
            this.btnFindFiles.UseVisualStyleBackColor = true;
            this.btnFindFiles.Click += new System.EventHandler(this.btnFindFiles_Click);
            // 
            // btnMoveFiles
            // 
            this.btnMoveFiles.Enabled = false;
            this.btnMoveFiles.Location = new System.Drawing.Point(12, 50);
            this.btnMoveFiles.Name = "btnMoveFiles";
            this.btnMoveFiles.Size = new System.Drawing.Size(75, 23);
            this.btnMoveFiles.TabIndex = 1;
            this.btnMoveFiles.Text = "Move Files to loc";
            this.btnMoveFiles.UseVisualStyleBackColor = true;
            this.btnMoveFiles.Click += new System.EventHandler(this.btnMoveFiles_Click);
            // 
            // btnImportFiles
            // 
            this.btnImportFiles.Location = new System.Drawing.Point(12, 88);
            this.btnImportFiles.Name = "btnImportFiles";
            this.btnImportFiles.Size = new System.Drawing.Size(75, 23);
            this.btnImportFiles.TabIndex = 2;
            this.btnImportFiles.Text = "Import Files tio DB";
            this.btnImportFiles.UseVisualStyleBackColor = true;
            this.btnImportFiles.Click += new System.EventHandler(this.btnImportFiles_Click);
            // 
            // lblLocateSSISPackage
            // 
            this.lblLocateSSISPackage.AutoSize = true;
            this.lblLocateSSISPackage.Location = new System.Drawing.Point(103, 22);
            this.lblLocateSSISPackage.Name = "lblLocateSSISPackage";
            this.lblLocateSSISPackage.Size = new System.Drawing.Size(125, 13);
            this.lblLocateSSISPackage.TabIndex = 4;
            this.lblLocateSSISPackage.Text = "SSIS Template Location:";
            // 
            // btnCreateFileId
            // 
            this.btnCreateFileId.Location = new System.Drawing.Point(12, 129);
            this.btnCreateFileId.Name = "btnCreateFileId";
            this.btnCreateFileId.Size = new System.Drawing.Size(75, 23);
            this.btnCreateFileId.TabIndex = 5;
            this.btnCreateFileId.Text = "Create File ID\'s";
            this.btnCreateFileId.UseVisualStyleBackColor = true;
            this.btnCreateFileId.Click += new System.EventHandler(this.btnCreateFileId_Click);
            // 
            // btnCreateCMFile
            // 
            this.btnCreateCMFile.Location = new System.Drawing.Point(271, 236);
            this.btnCreateCMFile.Name = "btnCreateCMFile";
            this.btnCreateCMFile.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCMFile.TabIndex = 6;
            this.btnCreateCMFile.Text = "Create CM File";
            this.btnCreateCMFile.UseVisualStyleBackColor = true;
            this.btnCreateCMFile.Click += new System.EventHandler(this.btnCreateCMFile_Click);
            // 
            // dgSuccsessFiles
            // 
            this.dgSuccsessFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSuccsessFiles.Location = new System.Drawing.Point(106, 50);
            this.dgSuccsessFiles.Name = "dgSuccsessFiles";
            this.dgSuccsessFiles.Size = new System.Drawing.Size(240, 150);
            this.dgSuccsessFiles.TabIndex = 7;
            // 
            // txtBeginID
            // 
            this.txtBeginID.Location = new System.Drawing.Point(12, 236);
            this.txtBeginID.Name = "txtBeginID";
            this.txtBeginID.Size = new System.Drawing.Size(100, 20);
            this.txtBeginID.TabIndex = 8;
            this.txtBeginID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtEndID
            // 
            this.txtEndID.Location = new System.Drawing.Point(151, 236);
            this.txtEndID.Name = "txtEndID";
            this.txtEndID.Size = new System.Drawing.Size(100, 20);
            this.txtEndID.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "BeginID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "EndID:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 375);
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
            this.Text = "Form1";
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
    }
}

