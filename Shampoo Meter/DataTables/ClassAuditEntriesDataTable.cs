using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shampoo_Meter.DataTables
{
    class ClassAuditEntriesDataTable
    {
        //Private variables
        private DataTable _EntriesTable;

        //Properties
        public DataTable entriesTable
        {
            get { return _EntriesTable;}
            set { _EntriesTable = value; } 
        }

        //Constructors
        public ClassAuditEntriesDataTable()
        {
            DataTable entriesTable = new DataTable();

            DataColumn billMonthCol = new DataColumn();
            DataColumn dateCol = new DataColumn();
            DataColumn fileNameCol = new DataColumn();
            DataColumn cdrCountCol = new DataColumn();
            DataColumn combinedUsageCol = new DataColumn();

            billMonthCol.ColumnName = "Billing_Month";
            dateCol.ColumnName = "Date";
            fileNameCol.ColumnName = "FileName";
            cdrCountCol.ColumnName = "CDR_Count";
            combinedUsageCol.ColumnName = "Combined_Usage";

            entriesTable.Columns.Add(billMonthCol);
            entriesTable.Columns.Add(dateCol);
            entriesTable.Columns.Add(fileNameCol);
            entriesTable.Columns.Add(cdrCountCol);
            entriesTable.Columns.Add(combinedUsageCol);

            this.entriesTable = entriesTable;
        }
        //Private Methods

        //Public Methods
        private static void AddNewEntry(string line, ref ClassAuditEntriesDataTable entriesTable)
        {
            DataRow newEntry = entriesTable.entriesTable.NewRow();
            newEntry["Billing_Month"] = line.Substring(0, 4);
            newEntry["Date"] = line.Substring(4, 8);
            newEntry["FileName"] = line.Substring(12, 8);
            newEntry["CDR_Count"] = line.Substring(20, 12);
            newEntry["Combined_Usage"] = line.Substring(32, line.Length - 32);
            entriesTable.entriesTable.Rows.Add(newEntry);
            entriesTable.entriesTable.AcceptChanges();
        }

        public static ClassAuditEntriesDataTable FillEntriesTable(Classes.ClassAuditFile auditFile)
        {
            ClassAuditEntriesDataTable result = new ClassAuditEntriesDataTable();

            using (StreamReader sr = new StreamReader(auditFile.location))
            {
                String line;

                while ((line = sr.ReadLine()) != null)
                {
                    AddNewEntry(line, ref result);
                }
                sr.Close();
            }

            return result;
        }
    }
}
