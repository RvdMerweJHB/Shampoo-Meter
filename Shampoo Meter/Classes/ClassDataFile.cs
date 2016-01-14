using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Shampoo_Meter.Classes
{
    public class ClassDataFile
    {
        #region Private variables
        private string _Filetype;
        private string _Filename;
        private string _FileExtension;
        private string _Location;
        private string _NewLocation;
        private int _AmountOfLines;
        private int _IntendedAmountOfLines;
        private string _Day;
        private string _Month;
        private string _Year;
        private string _MonthName;
        private string _FileNumber;
        private int _MTN_APN_Data_File_ID;
        private bool _passedSelfCheck;
        private bool _passedAuditFileCheck;
        private int _AuditFileEntryAmount;
        #endregion

        #region Properties

        public string FileType
        {
            get { return _Filetype; }
            set { _Filetype = value; }
        }
        public string FileName
        {
            get { return _Filename; }
            set { _Filename = value; }
        }
        public string FileExtension
        {
            get { return _FileExtension; }
            set { _FileExtension = value; }
        }
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
        public string NewLocation
        {
            get { return _NewLocation; }
            set { _NewLocation = value; }
        }
        public int AmountOfLines
        {
            get { return _AmountOfLines; }
            set { _AmountOfLines = value; }
        }
        public int IntendedAmountOfLines
        {
            get { return _IntendedAmountOfLines; }
            set { _IntendedAmountOfLines = value; }
        }
        public string Day
        {
            get { return _Day; }
            set { _Day = value; }
        }
        public string Month
        {
            get { return _Month; }
            set { _Month = value; }
        }
        public string MonthName
        {
            get { return _MonthName; }
            set { _MonthName = value; }
        }
        public string Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        public string FileNumber
        {
            get { return _FileNumber; }
            set { _FileNumber = value; }
        }
        public int MTN_APN_Data_File_ID 
        {
            get { return _MTN_APN_Data_File_ID; }
            set { _MTN_APN_Data_File_ID = value; } 
        }
        public bool PassedSelfCheck {
            get { return _passedSelfCheck;}
            set { _passedSelfCheck = value;} 
        }
        public bool PassedAuditFileCheck 
        {
            get { return _passedAuditFileCheck;}
            set { _passedAuditFileCheck = value;} 
        }
        public int AuditFileEntryAmount 
            {
                get { return _AuditFileEntryAmount;}
                set { _AuditFileEntryAmount = value;}
            }
        #endregion

        #region Constructors
        public ClassDataFile()
        { }

        //Constuctor using file location string
        public ClassDataFile(string location)
        {
            this.AmountOfLines = this.CountAmountOfLinesAndSetIntend(location);
            this.FileName = location.Substring(location.Length - 12, 12);
            this.FileExtension = "dat";
            this.Location = location;
            this.Day = FileName.Substring(2, 2);
            this.Month = FileName.Substring(4, 2);
            this.MonthName = this.GetMonthName(Convert.ToInt16(this.Month));
            this.Year = this.GetYear(location);       
            this.FileNumber = FileName.Substring(6, 2);
            this.FileType = FileName.Substring(0, 2);
        }

        //Constuctor using a datarow
        public ClassDataFile(System.Data.DataRow dataRow)
        {
            this.AmountOfLines = Convert.ToInt32(dataRow["Actual_CDR_Amount"]);
            this.FileName = dataRow["File_Name"].ToString();
            this.FileExtension = "dat";
            this.Day = FileName.Substring(2, 2);
            this.Month = FileName.Substring(4, 2);
            this.MonthName = this.GetMonthName(Convert.ToInt16(this.Month));
            this.FileNumber = FileName.Substring(6, 2);
            this.FileType = FileName.Substring(0, 2);
            this.MTN_APN_Data_File_ID = Convert.ToInt32(dataRow["ID"]);
        }
        #endregion

        #region Public Methods
        public static ClassDataFile ReturnDataFileByID(int ID, List<ClassDataFile> dataFileList)
        {
            ClassDataFile selectedDataFile = new ClassDataFile();

            foreach(ClassDataFile currentFile in dataFileList)
            {
                if (currentFile.MTN_APN_Data_File_ID == ID)
                    selectedDataFile = currentFile;
            }

            return selectedDataFile;
        }

        public static ClassDataFile ReturnDataFileByNameAndActualAmount(string fileName, int actualAmount, List<ClassDataFile> dataFileList)
        {
            ClassDataFile selectedDataFile = new ClassDataFile();

            foreach(ClassDataFile currentFile in dataFileList)
            {
                if ((currentFile.FileName == fileName) && (currentFile.AmountOfLines == actualAmount))
                    selectedDataFile = currentFile;
            }

            return selectedDataFile;
        }
        #endregion

        #region Private Methods

        private string GetMonthName(int monthNumber)
        {
            string name = string.Empty;
            switch (monthNumber)
            {
                case 1:
                    name = "Jan";
                    break;
                case 2:
                    name = "Feb";
                    break;
                case 3:
                    name = "Mar";
                    break;
                case 4:
                    name = "Apr";
                    break;
                case 5:
                    name = "May";
                    break;
                case 6:
                    name = "Jun";
                    break;
                case 7:
                    name = "Jul";
                    break;
                case 8:
                    name = "Aug";
                    break;
                case 9:
                    name = "Sep";
                    break;
                case 10:
                    name = "Oct";
                    break;
                case 11:
                    name = "Nov";
                    break;
                case 12:
                    name = "Dec";
                    break;
                default:
                    name = "Unknown Month";
                    break;
            }

            return name;
        }

        private string GetYear(string location)
        {
            string _result;

            _result = System.IO.File.ReadLines(location).First();

            return "20" + _result.Substring(2, 2);
        }

        private int CountAmountOfLinesAndSetIntend(string location)
        {
            int count = 0;
            using (StreamReader sr = new StreamReader(location))
            {
                String line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Substring(0, 2).ToString() == "TR")
                        this.IntendedAmountOfLines = Convert.ToInt32(line.Substring(2, 8));

                    count++;
                }
                sr.Close();
            }
            return count - 1;
        }
        #endregion
    }
}
