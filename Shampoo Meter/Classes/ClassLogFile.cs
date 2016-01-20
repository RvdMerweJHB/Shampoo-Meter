using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shampoo_Meter.Classes
{
    class ClassLogFile
    {
        #region Private Variables
        private string _Name;
        private string _Extention;
        private string _Location;
        #endregion

        #region Prpperties
        public string Name 
        {
            get { return _Name;}
            set { _Name = value;} 
        }

        public string Extention 
        {
            get { return _Extention;}
            set { _Extention = value;}
        }

        public string Location 
        {
            get { return _Location;}
            set { _Location = value;} 
        }
        #endregion

        #region Constructor
        public ClassLogFile()
        { }

        public ClassLogFile(string logFileLocation)
        {
            this.Location = logFileLocation;
            this.Extention = Shampoo_Meter.Properties.Settings.Default.LogFileExt;
            this.Name = DetermineFileName(this.Extention);
        }
        #endregion

        #region Public Methods
        public static string DetermineFileName(string fileExtention)
        {
            string resultName = string.Empty;
            DateTime date = new DateTime();
            date = DateTime.Now;

            resultName = date.ToString("HHmm") + "_" + date.ToString("dd") + "_" + date.ToString("MMMMMM") + "_" + date.ToString("yyyy");
            return resultName + fileExtention;
        }
        #endregion

    }
}
