﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Shampoo_Meter.Classes;
using System.IO;

namespace Shampoo_Meter.DAL
{
    class ClassSQLAccess
    {
        #region Public Methods
        public static DataTable GetDataTable(string connectionString)
        {
            DataTable resultTable = new DataTable();

            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlConnection.ConnectionString = connectionString;
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendLine("USE [APN_DATA]");
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("SELECT ");
            sqlQuery.AppendLine("	[Customer_Name],");
            sqlQuery.AppendLine("   [APN_Name]");
            sqlQuery.AppendLine("FROM");
            sqlQuery.AppendLine("	[APN_DATA].[dbo].[MTN_APN_Name]");

            sqlCommand.CommandText = sqlQuery.ToString();
            sqlConnection.Open();
            using (SqlDataAdapter sqlAdaptor = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection))
            {
                sqlAdaptor.Fill(resultTable);
            }
            sqlConnection.Close();

            return resultTable;
        }

        public static int GetFileStatus(string connectionString)
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlConnection.ConnectionString = connectionString;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = BuildUpdateFileStatusQuery();
            sqlConnection.Open();
            var count = sqlCommand.ExecuteScalar();
            sqlConnection.Close();

            return Convert.ToInt16(count);
        }

        public static bool UpdateDataFile(string tableName, string connectionString)
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlConnection.ConnectionString = connectionString;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = BuildUpdateDataFileQuery(tableName);
            sqlConnection.Open();
            int count = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            bool _result = (count >=1) ? true : false;

            return _result;
        }

        public static int ImportRawData(string fileId, string tableName, string connectionString)
        {
            tableName = tableName.Remove(8, tableName.Length - 8);
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlConnection.ConnectionString = connectionString;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = BuildImportRawdataQuery(fileId, tableName);
            sqlConnection.Open();
            int count = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return count;
        }

        public static DataTable SelectInCompletesAudits(string connectionString, DataTables.ClassAuditEntriesDataTable entriesTable)
        {
            DataTable _resultTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();
            
            sqlConnection.ConnectionString = connectionString;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = BuildSelectInCompleteAuditsQuery(entriesTable);
            sqlConnection.Open();
            using (SqlDataAdapter sqlAdaptor = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection))
            {
                sqlAdaptor.Fill(_resultTable);
            }
            sqlConnection.Close();

            return _resultTable;
        }

        public static bool UpdateIncompleteAudit(ClassDataFile datFile, string connectionString)
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlConnection.ConnectionString = connectionString;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = BuildUpdateInCompleteAuditsQuery(datFile);
            sqlConnection.Open();
            int count = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            bool _result = (count >= 1) ? true : false;

            return _result;

        }

        public static DataTable InsertNewFileId(ClassDataFile[] dataFiles, string connectionString)
        {
            DataTable pTable = new DataTable();
            int fileCount = 1;
            DataTable resultTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlConnection.ConnectionString = connectionString;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendLine("USE [APN_DATA]");
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("INSERT INTO ");
            sqlQuery.AppendLine("	MTN_APN_Data_File(File_Name,Date_Uploaded,Actual_CDR_Amount, Self_Check_CDR_Amount)");
            sqlQuery.AppendLine("   VALUES");

            foreach (ClassDataFile newDataFile in dataFiles)
            {
                sqlQuery.AppendLine("('" + newDataFile.FileName + "',GETDATE()," + newDataFile.AmountOfLines.ToString() + "," + newDataFile.IntendedAmountOfLines.ToString() + "),");
                if (fileCount == (dataFiles.Count()))
                    sqlQuery = sqlQuery.Remove(sqlQuery.Length - 3, 1);
                else
                    fileCount++;
            }

            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("SELECT TOP " + fileCount + "");
            sqlQuery.AppendLine("	[ID],");
            sqlQuery.AppendLine("	[FILE_NAME],");
            sqlQuery.AppendLine("   [Actual_CDR_Amount],");
            sqlQuery.AppendLine("   [Self_Check_CDR_Amount]");
            sqlQuery.AppendLine("FROM");
            sqlQuery.AppendLine("	MTN_APN_Data_File");
            sqlQuery.AppendLine("ORDER BY");
            sqlQuery.AppendLine("	ID DESC");

            sqlCommand.CommandText = sqlQuery.ToString();
            sqlCommand.Connection = sqlConnection;

            using (SqlDataAdapter sqlAdaptor = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection))
            {
                sqlAdaptor.Fill(pTable);
            }
            sqlConnection.Close();

            return pTable;
        }

        public static void CreateCMFile(string apnName, int beginFileId, int endFileId, string connectionString)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                DataTable pTable = new DataTable();

                sqlConnection.ConnectionString = connectionString;
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = BuildAPNDataFileForCMQuery(apnName, beginFileId, endFileId);
                sqlConnection.Open();
                using (SqlDataAdapter sqlAdaptor = new SqlDataAdapter(sqlCommand.CommandText, sqlConnection))
                {
                    sqlAdaptor.Fill(pTable);
                }
                sqlConnection.Close();

                //• TODO alter the file location to be writen to:
                using (StreamWriter sw = File.CreateText("C:\\New CM Data files\\MTN_APN_BON.txt"))
                {
                    foreach (DataRow CDRrow in pTable.Rows)
                    {
                        foreach (var field in CDRrow.ItemArray)
                        {
                            sw.Write(field.ToString() + "\t");
                        }
                        sw.WriteLine();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Private Methods
        private static string BuildImportRawdataQuery(string fileId, string tableName)
        {
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendLine("USE [APN_DATA]");
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("INSERT INTO");
            sqlQuery.AppendLine("	MTN_APN_Data");
            sqlQuery.AppendLine("		(");
            sqlQuery.AppendLine("           Data_File_ID,");
            sqlQuery.AppendLine("           Rec_Type,");
            sqlQuery.AppendLine("           Billing_Year,");
            sqlQuery.AppendLine("           Billing_Month,");
            sqlQuery.AppendLine("           Billing_Cycle,");
            sqlQuery.AppendLine("           Rec_Line_No,");
            sqlQuery.AppendLine("           Acc_Number,");
            sqlQuery.AppendLine("           Contract_Number,");
            sqlQuery.AppendLine("           Serial_Number,");
            sqlQuery.AppendLine("           Calling_Number,");
            sqlQuery.AppendLine("           Call_Date,");
            sqlQuery.AppendLine("           Call_Time,");
            sqlQuery.AppendLine("           Call_Sequence,");
            sqlQuery.AppendLine("           Called_Number,");
            sqlQuery.AppendLine("           Target_Network,");
            sqlQuery.AppendLine("           GEO_Source,");
            sqlQuery.AppendLine("           GEO_Destination,");
            sqlQuery.AppendLine("           Call_Cost,");
            sqlQuery.AppendLine("           Call_Charge_Units,");
            sqlQuery.AppendLine("           Call_Adjusted_Cost,");
            sqlQuery.AppendLine("           Call_Type,");
            sqlQuery.AppendLine("           Call_Product_Code,");
            sqlQuery.AppendLine("           Call_Duration,");
            sqlQuery.AppendLine("           Orginating_Call,");
            sqlQuery.AppendLine("           Call_Event,");
            sqlQuery.AppendLine("           Call_Direction,");
            sqlQuery.AppendLine("           TAP_Related,");
            sqlQuery.AppendLine("           TAP_MOC_Surcharge,");
            sqlQuery.AppendLine("           GSM_Code,");
            sqlQuery.AppendLine("           Distance_Related,");
            sqlQuery.AppendLine("           Price_Plan,");
            sqlQuery.AppendLine("           IMEI,");
            sqlQuery.AppendLine("           VAS_Description,");
            sqlQuery.AppendLine("           GPRS_Used,");
            sqlQuery.AppendLine("           Information_Flag,");
            sqlQuery.AppendLine("           VPN_Short_Dial,");
            sqlQuery.AppendLine("           VAS_Partner_Id,");
            sqlQuery.AppendLine("           VAS_Content_Id,");
            sqlQuery.AppendLine("           VAS_Content_TO_Id");
            sqlQuery.AppendLine("		)");
            sqlQuery.AppendLine("	SELECT");
            sqlQuery.AppendLine("		    " + fileId + " AS 'Data_File_ID',");
            sqlQuery.AppendLine("           [Column 0] AS 'Rec_Type',");
            sqlQuery.AppendLine("           [Column 1] AS 'Billing_Year',");
            sqlQuery.AppendLine("           [Column 2] AS 'Billing_Month',");
            sqlQuery.AppendLine("           [Column 3] AS 'Billing_Cycle',");
            sqlQuery.AppendLine("           [Column 4] AS 'Rec_Line_No',");
            sqlQuery.AppendLine("           [Column 5] AS 'Acc_Number',");
            sqlQuery.AppendLine("           [Column 6] AS 'Contract_Number',");
            sqlQuery.AppendLine("           [Column 7] AS 'Serial_Number',");
            sqlQuery.AppendLine("           [Column 8] AS 'Calling_Number',");
            sqlQuery.AppendLine("           [Column 9] AS 'Call_Date',");
            sqlQuery.AppendLine("           [Column 10] AS 'Call_Time',");
            sqlQuery.AppendLine("           [Column 11] AS 'Call_Sequence',");
            sqlQuery.AppendLine("           [Column 12] AS 'Called_Number',");
            sqlQuery.AppendLine("           [Column 13] AS 'Target_Network',");
            sqlQuery.AppendLine("--         [Column 14] AS 'Filler_1',");
            sqlQuery.AppendLine("           [Column 15] AS 'GEO_Source',");
            sqlQuery.AppendLine("           [Column 16] AS 'GEO_Destination',");
            sqlQuery.AppendLine("           [Column 17] AS 'Call_Cost',");
            sqlQuery.AppendLine("           [Column 18] AS 'Call_Charge_Units',");
            sqlQuery.AppendLine("           [Column 19] AS 'Call_Adjusted_Cost',");
            sqlQuery.AppendLine("           [Column 20] AS 'Call_Type',");
            sqlQuery.AppendLine("           [Column 21] AS 'Call_Product_Code',");
            sqlQuery.AppendLine("           [Column 22] AS 'Call_Duration',");
            sqlQuery.AppendLine("           [Column 23] AS 'Orginating_Call',");
            sqlQuery.AppendLine("           [Column 24] AS 'Call_Event',");
            sqlQuery.AppendLine("           [Column 25] AS 'Call_Direction',");
            sqlQuery.AppendLine("           [Column 26] AS 'TAP_Related',");
            sqlQuery.AppendLine("           [Column 27] AS 'TAP_MOC_Surcharge',");
            sqlQuery.AppendLine("           [Column 28] AS 'GSM_Code',");
            sqlQuery.AppendLine("           [Column 29] AS 'Distance_Related',");
            sqlQuery.AppendLine("--         [Column 30] AS 'Filler_2',");
            sqlQuery.AppendLine("           [Column 31] AS 'Price_Plan',");
            sqlQuery.AppendLine("           [Column 32] AS 'IMEI',");
            sqlQuery.AppendLine("           [Column 33] AS 'VAS_Description',");
            sqlQuery.AppendLine("           [Column 34] AS 'GPRS_Used',");
            sqlQuery.AppendLine("           [Column 35] AS 'Information_Flag',");
            sqlQuery.AppendLine("           [Column 36] AS 'VPN_Short_Dial',");
            sqlQuery.AppendLine("           [Column 37] AS 'VAS_Partner_Id',");
            sqlQuery.AppendLine("           [Column 38] AS 'VAS_Content_Id',");
            sqlQuery.AppendLine("           [Column 39] AS 'VAS_Content_TO_Id'--,");
            sqlQuery.AppendLine("--		    [Column 40] AS 'Filler_3',");
            sqlQuery.AppendLine("--		    [Column 41] AS 'End_Marker'");
            sqlQuery.AppendLine("	FROM");
            sqlQuery.AppendLine("   		dbo.[" + tableName + "]");

            return sqlQuery.ToString();
        }

        private static string BuildSelectInCompleteAuditsQuery(DataTables.ClassAuditEntriesDataTable entriesTable)
        {
            StringBuilder sqlQuery = new StringBuilder();
            int entriesCount = 1;

            sqlQuery.AppendLine("USE [APN_DATA]");
            sqlQuery.AppendLine("SELECT ");
            sqlQuery.AppendLine("	   [ID],");
            sqlQuery.AppendLine("      [File_Name],");
            sqlQuery.AppendLine("      [Date_Uploaded],");
            sqlQuery.AppendLine("      [Date_Completed],");
            sqlQuery.AppendLine("      [Actual_CDR_Amount],");
            sqlQuery.AppendLine("      [Self_Check_CDR_Amount]");
            sqlQuery.AppendLine("FROM");
            sqlQuery.AppendLine("	[dbo].[MTN_APN_Data_File]");
            sqlQuery.AppendLine("WHERE");
            sqlQuery.AppendLine("	Audit_File_CDR_Amount IS NULL");
            sqlQuery.AppendLine("	AND [File_Name] IN");
            sqlQuery.AppendLine("	(");

            foreach (DataRow dr in entriesTable.entriesTable.Rows)
            {
                sqlQuery.AppendLine("   '" + dr["FileName"] + "' + '.dat',");
                if (entriesCount == entriesTable.entriesTable.Rows.Count)
                {
                    sqlQuery = sqlQuery.Remove(sqlQuery.Length - 3, 1);
                }
                else
                    entriesCount++;
            }

            sqlQuery.AppendLine("	)");
            return sqlQuery.ToString();
        }

        private static string BuildUpdateInCompleteAuditsQuery(ClassDataFile datFile)
        {
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendLine("USE [APN_DATA]");
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("UPDATE [MTN_APN_Data_File]");
            sqlQuery.AppendLine("SET Audit_File_CDR_Amount = " + datFile.AuditFileEntryAmount.ToString());
            sqlQuery.AppendLine("WHERE");
            sqlQuery.AppendLine("   ID =" + datFile.MTN_APN_Data_File_ID.ToString());

            return sqlQuery.ToString();
        }

        private static string BuildUpdateDataFileQuery(string fileId)
        {
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendLine("USE [APN_DATA]");
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("UPDATE [dbo].[MTN_APN_Data_File]");
            sqlQuery.AppendLine("SET Date_Completed = GETDATE()");
            sqlQuery.AppendLine("WHERE ID = " + fileId);

            return sqlQuery.ToString();
        }

        private static string BuildAPNDataFileForCMQuery(string apnName, int beginFileId, int endFileId)
        {
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendLine("USE [APN_DATA]");
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("SELECT");
            sqlQuery.AppendLine("	AN.APN_Name,");
            sqlQuery.AppendLine("	RTRIM(CASE WHEN SUBSTRING(AD.Calling_Number, 1, 2) = '27' THEN '0' + SUBSTRING(AD.Calling_Number, 3, 20) ELSE AD.Calling_Number END) AS 'Calling_Number',");
            sqlQuery.AppendLine("	'20' + SUBSTRING(AD.Call_Date, 5, 6) + '-' + SUBSTRING(AD.Call_Date, 3, 2) + '-' + SUBSTRING(AD.Call_Date, 1, 2) + ' ' + SUBSTRING(AD.Call_Time, 1, 2) + ':' + SUBSTRING(AD.Call_Time, 3, 2) + ':' + SUBSTRING(AD.Call_Time, 5, 2) AS 'Call_Date',");
            sqlQuery.AppendLine("	RTRIM(CASE WHEN SUBSTRING(AD.Called_Number, 1, 2) = '27' THEN '0' + SUBSTRING(AD.Called_Number, 3, 20) ELSE AD.Called_Number END) AS 'Called_Number',");
            sqlQuery.AppendLine("	CAST(AD.Call_Cost AS MONEY) / 100 AS 'Call_Cost',");
            sqlQuery.AppendLine("	CASE WHEN SUBSTRING(AD.GPRS_Used, 1, 1) = 'B' THEN CAST(SUBSTRING(AD.GPRS_Used, 2, 10) AS bigint) ELSE CAST(SUBSTRING(AD.GPRS_Used, 2, 10) AS bigint) * 1000 END AS 'Data_Used',");
            sqlQuery.AppendLine("	DATENAME(MONTH, DATEADD(MONTH, CAST(AD.Billing_Month AS int) - 1, 0)) + ' 20' + AD.Billing_Year AS 'Billing_Period'");
            sqlQuery.AppendLine("FROM");
            sqlQuery.AppendLine("	dbo.MTN_APN_Data AS AD");
            sqlQuery.AppendLine("	JOIN dbo.MTN_APN_Name AS AN ON AN.Dummy_No = AD.Calling_Number");
            sqlQuery.AppendLine("WHERE");
            sqlQuery.AppendLine("   AN.APN_Name = '" + apnName + "'");
            sqlQuery.AppendLine("	AND AD.Data_File_ID BETWEEN " + beginFileId.ToString() + " AND " + endFileId.ToString() + "");
            sqlQuery.AppendLine("ORDER BY");
            sqlQuery.AppendLine("   '20' + SUBSTRING(AD.Call_Date, 5, 6) + '-' + SUBSTRING(AD.Call_Date, 3, 2) + '-' + SUBSTRING(AD.Call_Date, 1, 2) + ' ' + SUBSTRING(AD.Call_Time, 1, 2) + ':' + SUBSTRING(AD.Call_Time, 3, 2) + ':' + SUBSTRING(AD.Call_Time, 5, 2)");

            return sqlQuery.ToString();
        }

        private static string BuildUpdateFileStatusQuery()
        {
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.AppendLine("USE [APN_DATA]");
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("SELECT");
            sqlQuery.AppendLine("	COUNT(*)");
            sqlQuery.AppendLine("FROM ");
            sqlQuery.AppendLine("	[APN_DATA].[dbo].[MTN_APN_Data_File]");
            sqlQuery.AppendLine("WHERE");
            sqlQuery.AppendLine("	Audit_File_CDR_Amount is NULL");

            return sqlQuery.ToString();
        }
        #endregion
    }
}
