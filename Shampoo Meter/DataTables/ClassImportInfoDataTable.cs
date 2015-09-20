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
            DataColumn linesCol = new DataColumn();
            DataColumn afterSSISCol = new DataColumn();
            DataColumn tableIdCol = new DataColumn();
            DataColumn finalStatudCol = new DataColumn();

            nameCol.ColumnName = "File Name";
            linesCol.ColumnName = "Lines";
            afterSSISCol.ColumnName = "Status after SSIS package";
            tableIdCol.ColumnName = "Table Id";
            finalStatudCol.ColumnName = "Final Status";

            infoTable.Columns.Add(nameCol);
            infoTable.Columns.Add(linesCol);
            infoTable.Columns.Add(afterSSISCol);
            infoTable.Columns.Add(tableIdCol);
            infoTable.Columns.Add(finalStatudCol);

            this._InfoTable = infoTable;
        }
        
        //Methods
        public void AddNewRow(ClassDataFile dataFile, ref ClassImportInfoDataTable infoTable)
        {
            DataRow newRow = infoTable.infoTable.NewRow();
            newRow["File Name"] = dataFile.FileName;
            newRow["Lines"] = dataFile.AmountOfLines;
            infoTable.infoTable.Rows.Add(newRow);
            infoTable.infoTable.AcceptChanges();
        }
    }
}
