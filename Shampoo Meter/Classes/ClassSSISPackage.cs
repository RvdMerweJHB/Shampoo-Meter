using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dts.Runtime;

namespace Shampoo_Meter.Classes
{
    class ClassSSISPackage
    {
        //1. For each data file, take ssis tmeplate, and update tags.
        //2. Then save in to temp location, and hand location to be used in the ImportDatafile Method.
        //3. Execute ssis package
        //4. delete ssis package from temp location.
        //5. Indicate to user that package has comleted successfully, thus data in DB.

        #region Private Variables
        private string _TemplateLocation;
        private string _TemplateName;
        private string _ConnectionString;
        #endregion

        #region Properties
        public string connectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        public string templateLocation
        {
            get { return _TemplateLocation; }
            set { _TemplateLocation = value; }
        }

        public string templateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }
        #endregion

        #region Constructors
        public ClassSSISPackage()
        { }

        public ClassSSISPackage(string path, string connstring)
        {
            this.templateLocation = path;
            int startIndex = path.IndexOf("MTN APN");
            this.templateName = path.Substring(startIndex, path.Length - startIndex);
            this.connectionString = connstring;
        }
        #endregion

        #region Private Methods
        private string UpdateTemplate(ClassDataFile file)
        {
            string line;
            using (StreamReader sr = new StreamReader(this.templateLocation))
            {
                line = sr.ReadToEnd();
                sr.Close();
            }
            line = this.TagReplace(file, line);
            string path;
            path = file.NewLocation.Replace(file.FileName, this.templateName);
            System.IO.File.WriteAllText(path, line);
            return path;
        }
        #endregion

        #region Public Methods
        public string TagReplace(ClassDataFile file, string line)
        {
            line = line.Replace("{ConnectionString}", this.connectionString);
            line = line.Replace("{FileLocation}", file.NewLocation);
            line = line.Replace("{FileName}", file.FileType + file.Day + file.Month + file.FileNumber);
            return line;
        }

        public void ImportDataFile(ClassDataFile file)
        {
            try
            {
                string newFileLoc = this.UpdateTemplate(file);
                Application app = new Application();
                Package package = null;
                //Load the SSIS Package which will be executed
                package = app.LoadPackage(newFileLoc, null);
                //Pass the varibles into SSIS Package

                //Execute the SSIS Package and store the Execution Result
                Microsoft.SqlServer.Dts.Runtime.DTSExecResult results = package.Execute();
                //Check the results for Failure and Success
                if (results == Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure)
                {
                    string err = "";
                    foreach (Microsoft.SqlServer.Dts.Runtime.DtsError local_DtsError in package.Errors)
                    {
                        string error = local_DtsError.Description.ToString();
                        err = err + error;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
