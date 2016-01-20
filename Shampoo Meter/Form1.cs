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
                CheckFileStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Initial connection to APN DB has failed:" + Environment.NewLine + ex.Message.ToString());
            }
        }

        private void btnAuditExisting_Click(object sender, EventArgs e)
        {
            string logFileDir = Properties.Settings.Default.LogFileDir;
            string auditFileLocation = Properties.Settings.Default.AuditFileLocation;
            string messageBoxText = string.Empty;

            if (logFileDir == string.Empty || logFileDir == "")
            {
                MessageBox.Show("No Log File Location supplied!");
            }
            else
            {
                ClassLogFile logFile = new ClassLogFile(logFileDir);

                if (auditFileLocation == string.Empty || auditFileLocation == "")
                {
                    MessageBox.Show("No Audit File Location supplied!");
                }
                else
                { 
                    ClassAuditFile auditFile = new ClassAuditFile(auditFileLocation);
                    DataTables.ClassAuditEntriesDataTable auditEntriesTable = new DataTables.ClassAuditEntriesDataTable();
                    auditEntriesTable = DataTables.ClassAuditEntriesDataTable.FillEntriesTable(auditFile);

                    ClassImportInfoDataTable infoTable = new ClassImportInfoDataTable();
                    DataTable updatedAuditEntries = new DataTable();

                    try
                    {
                        //• CHECK FOR FILES THAT WAS ONLY RAN ON SELF CHECK IN THE PAST, AND CAN NOW BE FULLY AUDITED USING A NEW AUDIT FILE
                        updatedAuditEntries = ClassAuditing.CheckForInCompleteAudits(Shampoo_Meter.Properties.Settings.Default.ConnectionString, auditEntriesTable, ref infoTable);

                        if (updatedAuditEntries.Rows.Count >= 1)
                            messageBoxText += "There's been " + updatedAuditEntries.Rows.Count + " Audit Entries updated." + Environment.NewLine;
                        else
                            messageBoxText += "No Entries could be Updated using audit File: " + auditFile.location + "";

                        if (infoTable.infoTable.Rows.Count >= 1)
                            ClassCSVTools.SaveTableToCSV(infoTable, logFile.Location, logFile.Name);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                CheckFileStatus();
                MessageBox.Show(messageBoxText, "Find Files", MessageBoxButtons.OK, MessageBoxIcon.Information);           
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
                    ClassLogFile logFile = new ClassLogFile(Properties.Settings.Default.LogFileDir);

                    string auditType = Properties.Settings.Default.AuditType;

                    switch (auditType)
                    {
                        case "Self Check Only":
                            this.FileList = ClassGatherInfo.CompileFileList(pickUpPath, ref infoTable, false);
                            break;
                        case "Full (Use Audit File, and Self Check)":
                            this.FileList = ClassGatherInfo.CompileFileList(pickUpPath, ref infoTable, true);
                            break;
                    }

                    //• COMPOSE MESSAGEBOX TEXT
                    if (this.FileList.Count >= 1)
                        messageBoxText = "There's been " + this.FileList.Count.ToString() + " files found that's passed Audit." + Environment.NewLine;
                    else
                        messageBoxText = "There's been no files that passed Audit, are you using the correct PickUp Location?" + Environment.NewLine;

                    //• WRITE ALL RESULTS TO LOG FILE
                    if (infoTable.infoTable.Rows.Count >= 1)
                    {
                        ClassCSVTools.SaveTableToCSV(infoTable, logFile.Location, logFile.Name);
                        messageBoxText += "For more information see LogFile: " + logFile.Name + "";
                    }

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
            prgStatus.Refresh();
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

                    //Update StatusControl
                    CheckFileStatus();
                    //TODO: Update excel file with status
                    MessageBox.Show(this.FileList.Count() + " has been succesfully imported to the Database", "Import Files", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("SSIS Template location or SSIS Connection String not Supplied", "Import Files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCreateFileId_Click(object sender, EventArgs e)
        {
            prgStatus.Value = 0;
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
                    //Update Controls
                    CheckFileStatus();
                    dgSuccsessFiles.DataSource = resultTable;
                }
                else
                {
                    MessageBox.Show("No DAT Files loaded yet. Make sure steps 1 to 3 ran successfully");
                }
                MessageBox.Show("There has been " + successfullImports + " tables imported into MTN_APN_DATA table", "Create File ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (this.FileList != null)
                this.FileList.Clear();

            dgSuccsessFiles.DataSource = new DataTable();
            prgStatus.Refresh();
            prgStatus.Value = 0;

            btnMoveFiles.Enabled = false;
            lbl2.Enabled = false;
            btnImportFiles.Enabled = false;
            lbl3.Enabled = false;
            btnCreateFileId.Enabled = false;
            lbl4.Enabled = false;
        }

        private void CheckFileStatus()
        {
            try
            {
                int fileStatus = DAL.ClassSQLAccess.GetFileStatus(Shampoo_Meter.Properties.Settings.Default.ConnectionString);

                if (Convert.ToInt16(fileStatus) >= 1)
                {
                    txtFileStatus.BackColor = System.Drawing.Color.Tomato;
                    txtFileStatus.Text = "There are " + fileStatus + " un-Audited Files";
                }
                else
                {
                    txtFileStatus.BackColor = System.Drawing.Color.YellowGreen;
                    txtFileStatus.Text = "All Files Audited Up to Date";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
