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
            //MessageBox.Show("TODO:Update Filename table when importraw data has fininshed. DAL?? Then also problem of moving files if they already exist. Relook at classtools move files");
            try
            {
                DataTable apnClients = new DataTable();
                apnClients = DAL.ClassSQLAccess.GetDataTable(Shampoo_Meter.Properties.Settings.Default.ConnectionString);
                cmbApnClients.DataSource = apnClients;
                cmbApnClients.ValueMember = "APN_Name";
                cmbApnClients.DisplayMember = "Customer_Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Initial connection to APN DB has failed:" + Environment.NewLine + ex.Message.ToString());
            }
        }

        private void btnFindFiles_Click(object sender, EventArgs e)
        {
            string pickUpPath = Properties.Settings.Default.FileLocation;

            if (pickUpPath == string.Empty || pickUpPath == "")
            {
                MessageBox.Show("Pick Up Location not Supplied");
            }
            else
            {
                //• CHECK FOR NEW .dat FILES
                int newFiles = ClassGatherInfo.CheckForNewFiles();
                string fileName = string.Empty;
                string fileExtention = Shampoo_Meter.Properties.Settings.Default.LogFileExt;

                //TODO: User should be informed if all the new files are intact.

                //• WRITE NEW .dat FILE INFO TO EXCEL
                try
                {
                    fileName = ClassGatherInfo.DetermineFileName(fileExtention);
                    if (newFiles >= 1)
                    {
                        switch (fileExtention)
                        {
                            case ".csv":
                                this.FileList = ClassGatherInfo.WriteNewFilesToCSV(fileName, pickUpPath);
                                break;
                            case ".xlsx":
                                this.FileList = ClassGatherInfo.WriteNewFilesToExcel(fileName, pickUpPath);
                                break;
                        }
                    }
                    lbl2.Enabled = true;
                    btnMoveFiles.Enabled = true;
                    MessageBox.Show("There was a total of " + this.FileList.Count.ToString() + " found.", "Files Lookup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an Error:" + ex.Message, "Files Lookup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMoveFiles_Click(object sender, EventArgs e)
        {
            string outputPath = Properties.Settings.Default.OutputLocation;

            if (outputPath == string.Empty || outputPath == "")
            {
                MessageBox.Show("Connection String not Supplied");
            }
            else
            {
                //• MOVE THE NEW FILE TO THE NEW LOCATION 
                Classes.ClassDataFile[] datFiles;
                datFiles = this.FileList.ToArray<Classes.ClassDataFile>();

                try
                {
                    ClassTools.MoveFiles(datFiles, outputPath);
                    btnImportFiles.Enabled = true;
                    lbl3.Enabled = true;
                    MessageBox.Show("There was a total of " + this.FileList.Count.ToString() + " Moved.", "Files Move", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an Error:" + ex.Message, "Files Move", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportFiles_Click(object sender, EventArgs e)
        {
            string SSISTemplateLocation = Properties.Settings.Default.SSISTemplateLocation;
            string SSISConnectionString = Properties.Settings.Default.SSISConnectionString;

            //TODO:
            //1.CHECK IF .dtsx FILE EXISTS
            try
            {
                if ((SSISTemplateLocation != string.Empty || SSISTemplateLocation == "") || (SSISConnectionString != string.Empty || SSISConnectionString == ""))
                {
                    foreach (Classes.ClassDataFile file in this.FileList)
                    {
                        Classes.ClassSSISPackage ssisPackage = new Classes.ClassSSISPackage(SSISTemplateLocation, SSISConnectionString);
                        ssisPackage.ImportDataFile(file);
                    }
                    lbl4.Enabled = true;
                    btnCreateFileId.Enabled = true;

                    //TODO: Update excel file with status
                    MessageBox.Show("Data has been imported in the db");
                }
                else
                {
                    MessageBox.Show("SSIS Template location or SSIS Connection String not Supplied");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCreateFileId_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.ConnectionString;

            if (connectionString == string.Empty || connectionString == "")
            {
                MessageBox.Show("Connection String not Supplied");
            }
            else
            {
                Classes.ClassDataFile[] datFiles;
                datFiles = this.FileList.ToArray<Classes.ClassDataFile>();
                DataTable resultTable = new DataTable();
                int successfullImports = 0;
                if (datFiles.Length >= 1)
                {
                    resultTable = DAL.ClassSQLAccess.InsertNewFileId(datFiles, connectionString);
                    foreach (DataRow dr in resultTable.Rows)
                    {
                        try
                        {
                            int count = DAL.ClassSQLAccess.ImportRawData(dr[0].ToString(), dr[1].ToString(), connectionString);
                            bool updated = DAL.ClassSQLAccess.UpdateDataFile(dr[0].ToString(), connectionString);
                            successfullImports++;
                            //TODO: Check the amount returned with the line amounts to make sure import was successfull.
                        }
                        catch
                        {
                            MessageBox.Show("Error importing Row:" + dr[1].ToString());
                        }
                    }
                    dgSuccsessFiles.DataSource = resultTable;
                }
                else
                {
                    MessageBox.Show("No DAT Files loaded yet. Make sure steps 1 to 3 ran successfully");
                }
                //TODO: Update excel file with status 

                MessageBox.Show("There has been " + successfullImports + " tables imported into MTN_APN_DATA table");
            }
        }

        private void btnCreateCMFile_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.ConnectionString;

            if (connectionString == string.Empty || connectionString == "")
            {
                MessageBox.Show("Connection String not Supplied");
            }
            else
            {
                try
                {
                    DAL.ClassSQLAccess.CreateCMFile(cmbApnClients.SelectedValue.ToString(), Convert.ToUInt16(txtBeginID.Text), Convert.ToUInt16(txtEndID.Text), connectionString);
                    MessageBox.Show("Data file has been created for:" + cmbApnClients.SelectedValue.ToString() + "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an error creating Data file for:" + cmbApnClients.SelectedValue.ToString() + Environment.NewLine + "Message:" + ex.Message + "");
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.ShowDialog();
        }
    }
}
