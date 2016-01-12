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
        private int intendedNumberOfLines;
        private string _Filetype;
        private string _Filename;
        private string _FileExtension;
        private string _Location;
        private string _NewLocation;
        private int _AmountOfLines;
        private string _Day;
        private string _Month;
        private string _Year;
        private string _MonthName;
        private string _FileNumber;
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
        #endregion

        #region Constructors
        public ClassDataFile()
        { }

        public ClassDataFile(string location)
        {
            int count = 0;
            string line;
            using (StreamReader sr = new StreamReader(location))
            {
                line = sr.ReadToEnd();
                sr.Close();
                for (int n = 0; n < line.Length; n++) if (line[n] == '*') count++;
            }
            this._AmountOfLines = count -1 ;
            this._Filename = location.Substring(location.Length - 12, 12);
            this._FileExtension = "dat";
            this._Location = location;
            this._Day = FileName.Substring(2, 2);
            this._Month = FileName.Substring(4, 2);
            this._MonthName = this.GetMonthName(Convert.ToInt16(this.Month));
            this.Year = "20" + line.Substring(2, 2);
            this.FileNumber = FileName.Substring(6, 2);
            this._Filetype = FileName.Substring(0, 2);
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
        #endregion
    }
}
