using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shampoo_Meter.Classes;
using Shampoo_Meter.DataTables;
using Excel = Microsoft.Office.Interop.Excel;

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
