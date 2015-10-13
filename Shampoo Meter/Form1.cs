﻿using System;
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
                apnClients = DAL.ClassSQLAccess.GetDataTable(Shampoo_Meter.Properties.Settings.Default.InitialConnectionString);
                cmbApnClients.DataSource = apnClients;
                cmbApnClients.ValueMember = "APN_Name";
                cmbApnClients.DisplayMember = "Customer_Name";
                txtConnectionString.Text = Shampoo_Meter.Properties.Settings.Default.InitialConnectionString;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Initial connection to APN DB has failed:" + Environment.NewLine + ex.Message.ToString());
            }
        }

        private void btnFindFiles_Click(object sender, EventArgs e)
        {
            //• CHECK FOR NEW .dat FILES
            int newFiles = ClassGatherInfo.CheckForNewFiles();
            string fileName = string.Empty;
            string fileExtention = (radCsv.Checked) ? radCsv.Text : radXlsx.Text;

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
                            this.FileList = ClassGatherInfo.WriteNewFilesToCSV(fileName, txtFileLocation.Text);
                            break;
                        case ".xlsx":
                            this.FileList = ClassGatherInfo.WriteNewFilesToExcel(fileName, txtFileLocation.Text);
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

        private void btnMoveFiles_Click(object sender, EventArgs e)
        {
            //• MOVE THE NEW FILE TO THE APPROPRIATE LOCATION
            Classes.ClassDataFile[] datFiles;
            datFiles = this.FileList.ToArray<Classes.ClassDataFile>();

            try
            {
                ClassTools.MoveFiles(datFiles, txtOutputLocation.Text);
                btnImportFiles.Enabled = true;
                lbl3.Enabled = true;
                MessageBox.Show("There was a total of " + this.FileList.Count.ToString() + " Moved.", "Files Move", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an Error:" + ex.Message, "Files Move", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (txtSSISTemplateLocation.Text != "Please select...")
                {
                    foreach (Classes.ClassDataFile file in this.FileList)
                    {

                        Classes.ClassSSISPackage ssisPackage = new Classes.ClassSSISPackage(txtSSISTemplateLocation.Text, txtSSISConnectionString.Text);
                        ssisPackage.ImportDataFile(file);
                    }
                    lbl4.Enabled = true;
                    btnCreateFileId.Enabled = true;

                    //TODO: Update excel file with status
                    MessageBox.Show("Data has been imported in the db");
                }
                else
                {
                    MessageBox.Show("SSIS Template location not Supplied");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                resultTable = DAL.ClassSQLAccess.InsertNewFileId(datFiles, txtConnectionString.Text);
                foreach (DataRow dr in resultTable.Rows)
                {
                    try
                    {
                        int count = DAL.ClassSQLAccess.ImportRawData(dr[0].ToString(), dr[1].ToString(), txtConnectionString.Text);
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

            MessageBox.Show("There has been " + successfullImports + " files imported");
        }

        private void btnCreateCMFile_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.ClassSQLAccess.CreateCMFile(cmbApnClients.SelectedValue.ToString(), Convert.ToUInt16(txtBeginID.Text), Convert.ToUInt16(txtEndID.Text), txtConnectionString.Text);
                MessageBox.Show("Data file has been created for:" + cmbApnClients.SelectedValue.ToString() + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been an error creating Data file for:" + cmbApnClients.SelectedValue.ToString() + Environment.NewLine + "Message:" + ex.Message + "");
            }
        }

        private void btnLocateSSISTemplate_Click(object sender, EventArgs e)
        {
            dlgFileLocationBrowser.ShowDialog();
            txtSSISTemplateLocation.Text = dlgFileLocationBrowser.FileName.ToString();
        }

        private void txtOutputLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLocateFilePickupLocation_Click(object sender, EventArgs e)
        {
            dlgFolderLocationBrowser.ShowDialog();
            txtFileLocation.Text = dlgFolderLocationBrowser.SelectedPath.ToString();
        }

        private void btnLocateFileOutputLocation_Click(object sender, EventArgs e)
        {
            dlgFolderLocationBrowser.ShowDialog();
            txtOutputLocation.Text = dlgFolderLocationBrowser.SelectedPath.ToString();
        }
    }
}
