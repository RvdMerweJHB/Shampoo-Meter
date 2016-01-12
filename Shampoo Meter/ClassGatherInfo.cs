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

            resultName = date.ToString("MMMMMM");
            return resultName + fileExtention;
        }

        public static List<ClassDataFile> CompileBatchFileList(string pickUpLocation, ClassAuditEntriesDataTable auditEntries, ref DataTables.ClassImportInfoDataTable infoTable)
        {
            List<ClassDataFile> fileList = new List<ClassDataFile>();

            String[] filePaths = Directory.GetFiles(pickUpLocation);
            ClassDataFile[] datFiles = new ClassDataFile[filePaths.Count()];
            int count = 0;

            foreach (String fileLoc in filePaths)
            {
                ClassDataFile file = new ClassDataFile(fileLoc);
                datFiles[count] = new ClassDataFile(filePaths[count]);

                string message = VerifyFileIntact(datFiles[count], auditEntries);
                if (message == "Successful")
                {
                    fileList.Add(datFiles[count]);
                }
                infoTable.AddNewRow(datFiles[count], message, ref infoTable);
                count++;
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

        private static string VerifyFileIntact(ClassDataFile datFile, ClassAuditEntriesDataTable auditEntries)
        {
            string message = "Not successful. No Audit entry found for this file";
            foreach (DataRow dr in auditEntries.entriesTable.Rows)
            {
                if (dr["FileName"].ToString() == datFile.FileName.Substring(0, 8))
                {
                    if (Convert.ToInt16(dr["CDR_Count"]) == datFile.AmountOfLines)
                    {
                        message = "Successful";
                        break;
                    }
                    else
                    {
                        message = "Not Successful. File is not intact -CDR's do not match-";
                        break;
                    }
                }
            }
            return message;
        }
        #endregion
    }
}
