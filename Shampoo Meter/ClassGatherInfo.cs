using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shampoo_Meter.Classes;
using Shampoo_Meter.DataTables;

namespace Shampoo_Meter
{
    class ClassGatherInfo
    {
        //Class description:
        //1.Locate files in directory and check to see how many new files are there.
        //2.Write each file name to Importinfo excel file.
        //3.Open each file to check how many lines there are.
        //4.Verify that the amount of lines correspond with the amount indicated in last line.
        //5.Write this number to the ImportInfo file.

        //Methods
        #region Public Methods
        public static int CheckForNewFiles()
        {
            //TODO: Current code returns number larger than zero, so that application can continue
            //Still need to add the code that actually checks for new files.
            int count = 0;
            count++;
            return count;
        }

        public static string DetermineFileName(string fileExtention)
        {
            string resultName = string.Empty;
            DateTime date = new DateTime();
            date = DateTime.Now;

            resultName = date.ToString("HHmm") + "_" + date.ToString("dd") + "_" + date.ToString("MMMMMM") + "_" + date.ToString("yyyy");
            return resultName + fileExtention;
        }

        public static List<ClassDataFile> CompileFileList(string pickUpLocation, ref ClassImportInfoDataTable infoTable, bool useAuditFile, ref DataTable updatedAuditEntries)
        {
            List<ClassDataFile> fileList = new List<ClassDataFile>();
            String[] filePaths = Directory.GetFiles(pickUpLocation);
            ClassDataFile[] datFiles = new ClassDataFile[filePaths.Count()];
            int count = 0;

            if (useAuditFile)
            {
                string auditFileLocation = Properties.Settings.Default.AuditFileLocation;
                ClassAuditFile auditFile = new ClassAuditFile(auditFileLocation);
                DataTables.ClassAuditEntriesDataTable auditEntriesTable = new DataTables.ClassAuditEntriesDataTable();
                auditEntriesTable = DataTables.ClassAuditEntriesDataTable.FillEntriesTable(auditFile);

                if (auditEntriesTable.entriesTable.Rows.Count >= 1)
                {
                    foreach (String fileLoc in filePaths)
                    {
                        datFiles[count] = new ClassDataFile(filePaths[count]);
                        infoTable.AddNewRow(datFiles[count], ref infoTable);
                        string message = string.Empty;

                        message = ClassAuditing.SelfCheck(datFiles[count]);
                        infoTable.UpdateRow(datFiles[count], "Self_Check_Result", message, ref infoTable);

                        message = ClassAuditing.AuditFileCheck(datFiles[count], auditEntriesTable);
                        infoTable.UpdateRow(datFiles[count], "AuditFile_Check_Result", message, ref infoTable);

                        //• ONLY ADD FILE TO LIST IF AUDIT PASSED
                        if ((datFiles[count].PassedSelfCheck == true) && (datFiles[count].PassedAuditFileCheck == true))
                            fileList.Add(datFiles[count]);

                        count++;
                    }

                    //• CHECK FOR FILES THAT WAS ONLY RAN ON SELF CHECK IN THE PAST, AND CAN NOW BE FULLY AUDITED USING THE NEW AUDIT FILE
                    updatedAuditEntries = ClassAuditing.CheckForInCompleteAudits(Shampoo_Meter.Properties.Settings.Default.ConnectionString, auditEntriesTable, ref infoTable);
                }
            }
            else
            {
                foreach (String fileLoc in filePaths)
                {
                    datFiles[count] = new ClassDataFile(filePaths[count]);
                    infoTable.AddNewRow(datFiles[count], ref infoTable);
                    string message = string.Empty;

                    message = ClassAuditing.SelfCheck(datFiles[count]);
                    infoTable.UpdateRow(datFiles[count], "Self_Check_Result", message, ref infoTable);

                    //• ONLY ADD FILE TO LIST IF AUDIT PASSED
                    if (datFiles[count].PassedSelfCheck == true)
                        fileList.Add(datFiles[count]);

                    count++;
                }
            }
            return fileList;
        }

        #endregion

        #region Private methods
        private string LatestExistingFile()
        {

            string previousFileName = string.Empty;
            //TODO: Locate the latest file name from Database
            return previousFileName;
        }

        public static string VerifyFileIntact(ClassDataFile datFile, ClassAuditEntriesDataTable auditEntries = null)
        {
            string message = "Not successful. No Audit entry found for this file";

            //• Audit Type depends on if the auditEntries table has been supplied or not
            if (auditEntries == null)
            {
                if (datFile.AmountOfLines == datFile.IntendedAmountOfLines)
                    message = "Self Check Successful";
                else
                    message = "Self Check Not Successful. File is not complete:CDR MISMATCH";
            }
            else
            {
                foreach (DataRow dr in auditEntries.entriesTable.Rows)
                {
                    if (dr["FileName"].ToString() == datFile.FileName.Substring(0, 8))
                    {
                        if (Convert.ToInt16(dr["CDR_Count"]) == datFile.AmountOfLines)
                        {
                            message = "AuditFile Check Successful";
                            break;
                        }
                        else
                        {
                            message = "AuditFile Check Not Successful. File is not complete:CDR MISMATCH";
                            break;
                        }
                    }
                }
            }
            return message;
        }
        #endregion
    }
}
