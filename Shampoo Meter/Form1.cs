using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shampoo_Meter.Classes;
using Shampoo_Meter.DataTables;

namespace Shampoo_Meter
{
    public partial class Form1 : Form
    {
        private List<ClassDataFile> _FileList;
        public List<ClassDataFile> FileList
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
            DataTables.ClassImportInfoDataTable infoTable = new DataTables.ClassImportInfoDataTable();

            if (pickUpPath == string.Empty || pickUpPath == "")
            {
                MessageBox.Show("Pick Up Location not Supplied");
            }
            else
            {
                try
                {
                    string messageBoxText;
                    string logFileLocation = Properties.Settings.Default.LogFileDir;
                    string logFileExtention = Shampoo_Meter.Properties.Settings.Default.LogFileExt;
                    string logFileName = ClassGatherInfo.DetermineFileName(logFileExtention);
                    string auditType = Properties.Settings.Default.AuditType;

                    DataTable updatedAuditEntries = new DataTable();//This table is only for displaying updated Audit Entries info, back to the user.

                    switch (auditType)
                    {
                        case "Self Check Only":
                            this.FileList = ClassGatherInfo.CompileFileList(pickUpPath, ref infoTable, false, ref updatedAuditEntries);
                            break;
                        case "Full (Use Audit File, and Self Check)":
                            this.FileList = ClassGatherInfo.CompileFileList(pickUpPath, ref infoTable, true, ref updatedAuditEntries);
                            break;
                    }

                    //• WRITE ALL RESULTS TO LOG FILE
                    ClassCSVTools.SaveTableToCSV(infoTable, logFileLocation, logFileName);

                    //• COMPOSE MESSAGEBOX TEXT
                    if (this.FileList.Count >= 1)
                        messageBoxText = "Theres been " + this.FileList.Count.ToString() + " files found that's passed Audit." + Environment.NewLine;
                    else
                        messageBoxText = "There has been no files that passed Audit, are you using the correct PickUp Location?" + Environment.NewLine;

                    if (updatedAuditEntries.Rows.Count >= 1)
                        messageBoxText += "Also, Theres been " + updatedAuditEntries.Rows.Count + " Audit Entries updated." + Environment.NewLine;

                    messageBoxText  += "For more information see LogFile: " + logFileName + "";

                    MessageBox.Show(messageBoxText, "Find Files", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //• ACTIVATE NEXT CONTROL
                    if (this.FileList.Count >= 1)
                    {
                        lbl2.Enabled = true;
                        btnMoveFiles.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an Error:" + ex.Message, "Find Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //• MOVE THE FILE TO THE NEW LOCATION 
                Classes.ClassDataFile[] datFiles;
                datFiles = this.FileList.ToArray<Classes.ClassDataFile>();

                try
                {
                    ClassTools.MoveFiles(datFiles, outputPath);
                    btnImportFiles.Enabled = true;
                    lbl3.Enabled = true;
                    MessageBox.Show("There was a total of " + this.FileList.Count.ToString() + " Files Moved.", "Files Move", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There has been an Error:" + ex.Message, "Files Move", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportFiles_Click(object sender, EventArgs e)
        {
            prgStatus.Maximum = this.FileList.Count();
            prgStatus.Step = 1;
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
                        prgStatus.PerformStep();
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
            prgStatus.Maximum = this.FileList.Count();
            prgStatus.Step = 1;
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
                            ClassDataFile datFile = new ClassDataFile();
                            datFile = ClassDataFile.ReturnDataFileByNameAndActualAmount(dr["FILE_NAME"].ToString(), Convert.ToInt16(dr["Actual_CDR_Amount"]), this.FileList);
                            datFile.MTN_APN_Data_File_ID = Convert.ToInt16(dr["ID"]);

                            if (datFile.PassedAuditFileCheck)
                                DAL.ClassSQLAccess.UpdateIncompleteAudit(datFile, connectionString);

                            int count = DAL.ClassSQLAccess.ImportRawData(datFile.MTN_APN_Data_File_ID.ToString(), dr[1].ToString(), connectionString);
                            bool updated = DAL.ClassSQLAccess.UpdateDataFile(dr[0].ToString(), connectionString);
                            successfullImports++;
                            prgStatus.PerformStep();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.FileList.Clear();
            dgSuccsessFiles.DataSource = new DataTable();
            prgStatus.Refresh();

            btnMoveFiles.Enabled = false;
            lbl2.Enabled = false;
            btnImportFiles.Enabled = false;
            lbl3.Enabled = false;
            btnCreateFileId.Enabled = false;
            lbl4.Enabled = false;
        }
    }
}
