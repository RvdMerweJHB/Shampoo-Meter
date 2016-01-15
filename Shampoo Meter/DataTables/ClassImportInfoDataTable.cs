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
            DataColumn selfCheckResultCol = new DataColumn();
            DataColumn auditFileCheckResultCol = new DataColumn();

            nameCol.ColumnName = "File_Name";
            selfCheckResultCol.ColumnName = "Self_Check_Result";
            auditFileCheckResultCol.ColumnName = "AuditFile_Check_Result";

            infoTable.Columns.Add(nameCol);
            infoTable.Columns.Add(selfCheckResultCol);
            infoTable.Columns.Add(auditFileCheckResultCol);

            this._InfoTable = infoTable;
        }
        
        //Methods
        public void AddNewRow(ClassDataFile dataFile, ref ClassImportInfoDataTable infoTable)
        {
            DataRow newRow = infoTable.infoTable.NewRow();
            newRow["File_Name"] = dataFile.FileName;
            newRow["Self_Check_Result"] = "";
            newRow["AuditFile_Check_Result"] = "Not Checked Yet";
            infoTable.infoTable.Rows.Add(newRow);
            infoTable.infoTable.AcceptChanges();
        }

        public void UpdateRow(ClassDataFile dataFile, string resultType, string resultMessage, ref ClassImportInfoDataTable infoTable)
        {
            DataRow row = infoTable.infoTable.Select("File_Name = '" + dataFile.FileName + "'").FirstOrDefault();
            row[resultType] = resultMessage.ToString();
            infoTable.infoTable.AcceptChanges();
        }
    }
}
