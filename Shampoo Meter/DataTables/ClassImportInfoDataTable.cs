using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Shampoo_Meter.Classes;

namespace Shampoo_Meter.DataTables
{
    class ClassImportInfoDataTable
    {
        //Private variables
        private DataTable _InfoTable;

        //Porperties
        public DataTable infoTable 
        {
            get { return _InfoTable;}
            set { _InfoTable = value;} 
        }

        //Constructors
        public ClassImportInfoDataTable()
        {
            DataTable infoTable = new DataTable();

            DataColumn nameCol = new DataColumn();
            DataColumn resultCol = new DataColumn();

            nameCol.ColumnName = "File_Name";
            resultCol.ColumnName = "Result";

            infoTable.Columns.Add(nameCol);
            infoTable.Columns.Add(resultCol);

            this._InfoTable = infoTable;
        }
        
        //Methods
        public void AddNewRow(ClassDataFile dataFile, string result, ref ClassImportInfoDataTable infoTable)
        {
            DataRow newRow = infoTable.infoTable.NewRow();
            newRow["File_Name"] = dataFile.FileName;
            newRow["Result"] = result;
            infoTable.infoTable.Rows.Add(newRow);
            infoTable.infoTable.AcceptChanges();
        }
    }
}
