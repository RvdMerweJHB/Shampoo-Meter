using System;
using System.IO;
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

        //Private variables


        //Porperties


        //Constructors

        //Methods
        #region Private Methods
        private string LatestExistingFile()
        {
            
            string previousFileName = string.Empty;
            //TODO: Locate the latest file name from Database
            return previousFileName;
        }
        #endregion

        #region Public Methods
        public static int CheckForNewFiles()
        { 
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

        public static List<ClassDataFile> WriteNewFilesToExcel(string fileName, string pickUpLocation)
        {
            var myList = new List<ClassDataFile>();
            ClassImportInfoDataTable infoTable = new ClassImportInfoDataTable();
            //TODO: Use path speciefied in settings to find new .dat files:
            //1.Call latestExistingFile method to find out latest name in db.
            //2.Cycle through files in directory, and write the file info to a datatable, wich is then handed to the excel file.
            String[] filePaths = Directory.GetFiles(pickUpLocation);
            ClassDataFile[] datFiles = new ClassDataFile[filePaths.Count()];
            int count = 0;
            
            foreach(String fileLoc in filePaths)
            {
                ClassDataFile file = new ClassDataFile(fileLoc);
                infoTable.AddNewRow(file, ref infoTable);
                datFiles[count] = new ClassDataFile(filePaths[count]);
                myList.Add(datFiles[count]);
                count++;
            }

            //Now that we have a datatable we can use the Exceltools class to write to new worksheet:
            //ClassExcelTools excelObj = new ClassExcelTools();
            //string message = excelObj.SaveTableToExcel(infoTable, pickUpLocation, fileName);
            //string testMessage = excelObj.ReadTableFromExcel(pickUpLocation + fileName);
            return myList;
        }
        

        internal static List<ClassDataFile> WriteNewFilesToCSV(string fileName, string pickUpLocation)
        {
            var myList = new List<ClassDataFile>();
            ClassImportInfoDataTable infoTable = new ClassImportInfoDataTable();
            //TODO: Use path speciefied in settings to find new .dat files:
            //1.Call latestExistingFile method to find out latest name in db.
            //2.Cycle through files in directory, and write the file info to a datatable, wich is then handed to the csv file.
            String[] filePaths = Directory.GetFiles(pickUpLocation);
            ClassDataFile[] datFiles = new ClassDataFile[filePaths.Count()];
            int count = 0;

            foreach (String fileLoc in filePaths)
            {
                ClassDataFile file = new ClassDataFile(fileLoc);
                infoTable.AddNewRow(file, ref infoTable);
                datFiles[count] = new ClassDataFile(filePaths[count]);
                myList.Add(datFiles[count]);
                count++;
            }

            //Now that we have a datatable we can use the Exceltools class to write to new worksheet:
            //ClassCSVTools CSVObj = new ClassCSVTools();
            //string message = CSVObj.SaveTableToCSV(infoTable, pickUpLocation, fileName);

            return myList;
        }
        #endregion
    }
}
