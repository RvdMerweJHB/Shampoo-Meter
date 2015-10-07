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
    public partial class Form1 : Form
    {
        private List<Classes.ClassDataFile> _FileList;
        public List<Classes.ClassDataFile> FileList
        {
            get { return _FileList; }
            set { _FileList = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("TODO:ClassSSISPackage line:55 is not working");
            DataTable apnClients = new DataTable();
            apnClients = DAL.ClassSQLAccess.GetDataTable();
            cmbApnClients.DataSource = apnClients;
            cmbApnClients.ValueMember = "APN_Name";
            cmbApnClients.DisplayMember = "Customer_Name";
        }

        private void btnFindFiles_Click(object sender, EventArgs e)
        {
            //• CHECK FOR NEW .dat FILES
            int newFiles = ClassGatherInfo.CheckForNewFiles();
            string fileName = string.Empty;
            string fileExtention = (radCsv.Checked) ? radCsv.Text : radXlsx.Text;
            //TODO: Update user with how may files have been found.
            //THEN: User should be informed if all the new files are intact.

            //• WRITE NEW .dat FILE INFO TO EXCEL
            try
            {
                fileName = ClassGatherInfo.DetermineFileName(fileExtention);
                if (newFiles >= 1)
                {
                    switch (fileExtention)
                    {
                        case ".csv":
                            this.FileList = ClassGatherInfo.WriteNewFilesToCSV(fileName);
                            break;
                        case ".xlsx":
                            this.FileList = ClassGatherInfo.WriteNewFilesToExcel(fileName);
                            break;
                    }
                }
                lbl2.Enabled = true;
                btnMoveFiles.Enabled = true;
                MessageBox.Show("There was a total of " + this.FileList.Count.ToString() + " found.", "Files Lookup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an Error:" + ex.InnerException.Message, "Files Lookup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMoveFiles_Click(object sender, EventArgs e)
        {
            //• MOVE THE NEW FILE TO THE APPROPRIATE LOCATION
            Classes.ClassDataFile[] datFiles;
            datFiles = this.FileList.ToArray<Classes.ClassDataFile>();

            try
            {
                ClassTools.MoveFiles(datFiles);
                btnImportFiles.Enabled = true;
                lbl3.Enabled = true;
                MessageBox.Show("There was a total of " + this.FileList.Count.ToString() + " Moved.", "Files Move", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an Error:" + ex.InnerException.Message, "Files Move", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportFiles_Click(object sender, EventArgs e)
        {
            //TODO:CREATE INSTANCE OF THE SSIS PACKAGE HERE
            //AND USE ITS METHODS/PROPERTIES TO:
            //1.CHECK IF .dtsx FILE EXISTS
            //2.UPDATE THE .dtsx FILE WITH NEW FILE NAME AND DIR IF REQUIRED
            //3.RUN THE SSIS PACKAGE
            //4.CHECT THE RESULT MESSAGE IF IMPORT HAS BEEN SUCCESSFULL

            if (txtSSISTemplateLocation.Text != "Please select...")
            {
                foreach (Classes.ClassDataFile file in this.FileList)
                {

                    Classes.ClassSSISPackage ssisPackage = new Classes.ClassSSISPackage(txtSSISTemplateLocation.Text);
                    ssisPackage.ImportDataFile(file);
                }
                lbl4.Enabled = true;
                btnCreateFileId.Enabled = true;

                //TODO: Update excel file with status
                MessageBox.Show("Data has been importer in the db");
            }
            else
            {
                MessageBox.Show("SSIS Template location not Supplied");
            }

        }

        private void btnCreateFileId_Click(object sender, EventArgs e)
        {
            Classes.ClassDataFile[] datFiles;
            datFiles = this.FileList.ToArray<Classes.ClassDataFile>();
            DataTable resultTable = new DataTable();
            int successfullImports = 0;
            if (datFiles.Length >= 1)
            {
                resultTable = DAL.ClassSQLAccess.InsertNewFileId(datFiles);
            }

            foreach (DataRow dr in resultTable.Rows)
            {
                try
                {
                    int count = DAL.ClassSQLAccess.ImportRawData(dr[0].ToString(), dr[1].ToString());
                    successfullImports++;
                }
                catch
                {
                    MessageBox.Show("Error importing Row:" + dr[1].ToString());
                }
            }

            //TODO: Check the amount returned with the line amounts to make sure import was successfull.
            //TODO: Update excel file with status 

            MessageBox.Show("There has been " + successfullImports + " files imported");
            dgSuccsessFiles.DataSource = resultTable;
        }

        private void btnCreateCMFile_Click(object sender, EventArgs e)
        {
            DAL.ClassSQLAccess.CreateCMFile(cmbApnClients.SelectedValue.ToString(), Convert.ToUInt16(txtBeginID.Text), Convert.ToUInt16(txtEndID.Text));
        }

        private void btnLocateSSISTemplate_Click(object sender, EventArgs e)
        {
            dlgFileLocationBrowser.ShowDialog();
            txtSSISTemplateLocation.Text = dlgFileLocationBrowser.FileName.ToString();
        }

    }
}
