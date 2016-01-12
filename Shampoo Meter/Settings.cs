using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shampoo_Meter
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtFileLocation.Text = Properties.Settings.Default.FileLocation;
            txtOutputLocation.Text = Properties.Settings.Default.OutputLocation;
            txtSSISConnectionString.Text = Properties.Settings.Default.SSISConnectionString;
            txtSSISTemplateLocation.Text = Properties.Settings.Default.SSISTemplateLocation;
            txtConnectionString.Text = Properties.Settings.Default.ConnectionString;

            txtAuditFileLocation.Text = Properties.Settings.Default.AuditFileLocation;
            txtLogFileLocation.Text = Properties.Settings.Default.LogFileDir;
            string fileExtention = Properties.Settings.Default.LogFileExt;

            switch(fileExtention)
            {
                case ".csv":
                    radCsv.Checked = true;
                    break;
                case ".xlsx":
                    radXlsx.Checked = true;
                    break;
            }
        }

        private void btnLocateFilePickupLocation_Click(object sender, EventArgs e)
        {
            dlgFolderLocationBrowser.ShowDialog();
            Properties.Settings.Default.FileLocation = dlgFolderLocationBrowser.SelectedPath.ToString();
            txtFileLocation.Text = dlgFolderLocationBrowser.SelectedPath.ToString();
        }

        private void btnLocateFileOutputLocation_Click(object sender, EventArgs e)
        {
            dlgFolderLocationBrowser.ShowDialog();
            Properties.Settings.Default.OutputLocation = dlgFolderLocationBrowser.SelectedPath.ToString();
            txtOutputLocation.Text = dlgFolderLocationBrowser.SelectedPath.ToString();
        }

        private void btnLocateSSISTemplate_Click(object sender, EventArgs e)
        {
            dlgFileLocationBrowser.ShowDialog();
            Properties.Settings.Default.SSISTemplateLocation = dlgFileLocationBrowser.FileName.ToString();
            txtSSISTemplateLocation.Text = dlgFileLocationBrowser.FileName.ToString();
        }

        private void btnLocateAuditFile_Click(object sender, EventArgs e)
        {
            dlgFileLocationBrowser.ShowDialog();
            Properties.Settings.Default.AuditFileLocation = dlgFileLocationBrowser.FileName.ToString();
            txtAuditFileLocation.Text = dlgFileLocationBrowser.FileName.ToString();
        }

        private void btnLocateLogFileDir_Click(object sender, EventArgs e)
        {
            dlgFolderLocationBrowser.ShowDialog();
            Properties.Settings.Default.LogFileDir = dlgFolderLocationBrowser.SelectedPath.ToString();
            txtLogFileLocation.Text = dlgFolderLocationBrowser.SelectedPath.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FileLocation = txtFileLocation.Text;
            Properties.Settings.Default.OutputLocation = txtOutputLocation.Text;
            Properties.Settings.Default.SSISConnectionString = txtSSISConnectionString.Text;
            Properties.Settings.Default.SSISTemplateLocation = txtSSISTemplateLocation.Text; 
            Properties.Settings.Default.ConnectionString = txtConnectionString.Text;

            Properties.Settings.Default.AuditFileLocation = txtAuditFileLocation.Text;
            Properties.Settings.Default.LogFileDir = txtLogFileLocation.Text;
            Properties.Settings.Default.LogFileExt = (radCsv.Checked == true) ? ".csv" : ".xlsx";
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
