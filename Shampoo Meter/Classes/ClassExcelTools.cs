using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shampoo_Meter.Classes;
using Shampoo_Meter.DataTables;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace Shampoo_Meter.Classes
{
    //Thid class should contain methods that can:
    //Retrieve the exel file
    //Write information to the excel file
    //Create it if it doesnt exists or if new month
    //Add each day as new sheet.
    class ClassExcelTools
    {
        //Private variables
        
        //Porperties

        //Constructors
        public ClassExcelTools()
        {

        }

        //Methods
        //Check if file exists:
        //Check if should be new worksheet:
        //Open existing file:
        //Write to existing file:
        //New Sheet Name:

        public string ReadTableFromExcel(string fileName)
        {
            Excel.Application exApp;
            exApp = new Excel.Application();
            Excel.Workbook exWorkBook;
            exWorkBook = exApp.Workbooks.Open(fileName);

            // get all sheets in workbook
            Excel.Sheets excelSheets = exWorkBook.Worksheets;

            // get some sheet
            string currentSheet = "October.xlsx";
            Excel.Worksheet exWorkSheet =
                (Excel.Worksheet)excelSheets.get_Item(currentSheet);

            Excel.Range excelCell = (Excel.Range)exWorkSheet.get_Range("A1", "A1");
            string test = excelCell.get_Item("A1","A1");
            exWorkBook.Close();
            exApp.Quit();
            return "saved";
            //DataTable tbContainer = new DataTable();
            //string strConn = string.Empty;
            //if (string.IsNullOrEmpty(sheetName)) { sheetName = "Sheet1"; }
            //FileInfo file = new FileInfo(pathName);
            //if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
            //string extension = file.Extension;
            //switch (extension)
            //{
            //    case ".xls":
            //        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            //        break;
            //    case ".xlsx":
            //        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
            //        break;
            //    default:
            //        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            //        break;
            //}
            //OleDbConnection cnnxls = new OleDbConnection(strConn);
            //OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
            //DataSet ds = new DataSet();
            //oda.Fill(tbContainer);
            //DataTable test = new DataTable();
            //test = tbContainer;
            //return "read";
        }

        public string SaveTableToExcel(ClassImportInfoDataTable infoTable, string ExcelFilePath, string fileName)
        {
            Excel.Application exApp;
            exApp = new Excel.Application();

            Excel.Workbook exWorkBook;
            exWorkBook = exApp.Workbooks.Add(Type.Missing);

            Excel.Worksheet exWorkSheet;
            exWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)exWorkBook.ActiveSheet;
            exWorkSheet.Name = fileName;

            int columns = infoTable.infoTable.Columns.Count;
            int rows = infoTable.infoTable.Rows.Count;

            // column headings
            for (int i = 0; i < columns; i++)
            {
                exWorkSheet.Cells[1, (i + 1)] = infoTable.infoTable.Columns[i].ColumnName;
            }

            // rows
            for (int i = 0; i < rows; i++)
            {
                // to do: format datetime values before printing
                for (int j = 0; j < columns; j++)
                {
                    exWorkSheet.Cells[(i + 2), (j + 1)] = infoTable.infoTable.Rows[i][j];
                }
            }

            if (ExcelFilePath != null && ExcelFilePath != "")
            {
                try
                {
                    exWorkSheet.SaveAs(ExcelFilePath + fileName);
                    exApp.Quit();
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                        + ex.Message);
                }
            }
            else    // no filepath is given
            {
                exApp.Visible = true;
            }
            return "Saved";
        }

        public string NewSheetName(int day)
        {
            string _sheetName = day.ToString();
            switch(day)
            {
                case 1:
                case 21:
                case 31:
                    _sheetName = _sheetName + "st";
                    break;
                case 2:
                case 22:
                    _sheetName = _sheetName + "nd";
                    break;
                default:
                    _sheetName = _sheetName + "th";
                    break;
            }
            return _sheetName;            
        }
    }
}
