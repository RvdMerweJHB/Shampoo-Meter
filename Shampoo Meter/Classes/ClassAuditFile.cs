using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shampoo_Meter.Classes
{
    class ClassAuditFile
    {
        #region Private variables
        string _name = string.Empty;
        string _location = string.Empty;
        int _entries = 0;
        #endregion 

        #region Properties

        public string name 
        {
            get { return _name;}
            set { _name = value;} 
        }

        public string location 
        {
            get { return _location;}
            set { _location = value;} 
        }

        public int entries 
        {
            get { return _entries;}
            set { _entries = value;} 
        }

        #endregion

        #region Constructors
        //New
        public ClassAuditFile()
        {}

        //With file path
        public ClassAuditFile(string fileLocation)
        {
            this.location = fileLocation;
            this.name = fileLocation.Substring(fileLocation.Length - 17, 17);
            this.entries = countEntries(fileLocation);
        }

        #endregion

        #region Public Methods
        public static DataTable FillAuditEntries(ClassAuditFile auditFile)
        {
            DataTable _dt = new DataTable();
            return _dt;
        }

        #endregion

        #region Private Methods
        private int countEntries(string location)
        {
            int count = 0;
            string line;
            using (StreamReader sr = new StreamReader(location))
            {
                line = sr.ReadToEnd();
                sr.Close();
                for (int n = 0; n < line.Length; n++) if (line[n] == '.') count++;
            }
            return count;
        }
        #endregion
    }
}
