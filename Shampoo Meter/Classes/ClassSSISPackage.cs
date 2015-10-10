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
        private string _TemplateLocation;
        private string _TemplateName;

        public string templateLocation 
        {
            get { return _TemplateLocation;}
            set {  _TemplateLocation = value;} 
        }

        public string templateName 
        {
            get { return _TemplateName;}
            set { _TemplateName = value;} 
        }

        #region Constructors
        public ClassSSISPackage()
        { }

        public ClassSSISPackage(string path)
        {
            this.templateLocation = path;
            int startIndex = path.IndexOf("MTN APN");
            this.templateName = path.Substring(startIndex, path.Length - startIndex);
        }
        #endregion


        private string UpdateTemplate(ClassDataFile file)
        {
            string line;
            using (StreamReader sr = new StreamReader(this.templateLocation))
            {
                line = sr.ReadToEnd();
                sr.Close();
            }
            line = this.TagReplace(file,line);
            string path;
            path = file.NewLocation.Replace(file.FileName, this.templateName);
            System.IO.File.WriteAllText(path, line);
            return path;
        }

        public string TagReplace(ClassDataFile file, string line)
        {
            line = line.Replace("{ConnectionString}", "Data Source=VM_DEV;Initial Catalog=APN_DATA;Provider=SQLNCLI11;Integrated Security=SSPI;Auto Translate=false;");
            line = line.Replace("{FileLocation}",file.NewLocation);
            line = line.Replace("{FileName}","02"+file.Day+file.Month+file.FileNumber);
            return line;
        }

        public void ImportDataFile(ClassDataFile file)
        {
            string newFileLoc =  this.UpdateTemplate(file);
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
            if (results == Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success)
            {
                string message = "Package Executed Successfully....";
            }
            //You can also return the error or Execution Result
            //return Error;
        }
    }
}
