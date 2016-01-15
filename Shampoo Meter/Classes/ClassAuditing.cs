using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shampoo_Meter.Classes;
using Shampoo_Meter.DataTables;
using Shampoo_Meter.DAL;
using System.Data;

namespace Shampoo_Meter.Classes
{
    class ClassAuditing
    {
        //This class sould contain the static methods for the two types of Auditing, als use static properties for the messages.
        public static DataTable CheckForInCompleteAudits(string connectionString, ClassAuditEntriesDataTable entriesTable, ref ClassImportInfoDataTable infoTable)
        {
            DataTable _resultTable = new DataTable();
            _resultTable = ClassSQLAccess.SelectInCompletesAudits(connectionString, entriesTable);

            if (_resultTable.Rows.Count >= 1)
                UpdateInCompleteAudits(_resultTable, entriesTable, ref infoTable, connectionString);

            return _resultTable;
        }

        public static void UpdateInCompleteAudits(DataTable table, ClassAuditEntriesDataTable entriesTable, ref ClassImportInfoDataTable infoTable, string connectionString)
        {
            string message;
            foreach (DataRow dataRow in table.Rows)
            {
                ClassDataFile datFile = new ClassDataFile(dataRow);
                infoTable.AddNewRow(datFile, ref infoTable);
                message = ClassGatherInfo.VerifyFileIntact(datFile, entriesTable);

                message = AuditFileCheck(datFile, entriesTable);
                infoTable.UpdateRow(datFile, "AuditFile_Check_Result", message, ref infoTable);

                //• ONLY UPDATE THE ENTRY IF AUDIT PASSED
                if (datFile.PassedAuditFileCheck)
                    ClassSQLAccess.UpdateIncompleteAudit(datFile, connectionString);
            }
        }

        public static string SelfCheck(ClassDataFile datFile)
        {
            string message;

            if (datFile.AmountOfLines == datFile.IntendedAmountOfLines)
            {
                message = "Self Check Successful"; 
                datFile.PassedSelfCheck = true;
            }
            else
            { 
                message = "Self Check Not Successful. File is not complete:CDR MISMATCH";
                datFile.PassedSelfCheck = false;
            }
            return message;
        }

        public static string AuditFileCheck(ClassDataFile datFile, ClassAuditEntriesDataTable auditEntries)
        {
            string message = "Not successful. No Audit entry found for this file";
            foreach (DataRow dr in auditEntries.entriesTable.Rows)
            {
                if (dr["FileName"].ToString() == datFile.FileName.Substring(0, 8))
                {
                    if (Convert.ToInt16(dr["CDR_Count"]) == datFile.AmountOfLines)
                    {
                        message = "AuditFile Check Successful";
                        datFile.PassedAuditFileCheck = true;
                        datFile.AuditFileEntryAmount = Convert.ToInt16(dr["CDR_Count"]);
                        break;
                    }
                    else
                    {
                        message = "AuditFile Check Not Successful. File is not complete:CDR MISMATCH";
                        datFile.PassedAuditFileCheck = false;
                        break;
                    }
                }
            }
            return message;
        }
    }
}
