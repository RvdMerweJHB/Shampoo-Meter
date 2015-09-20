using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Shampoo_Meter.Classes;

namespace Shampoo_Meter
{
    class ClassTools
    {
        #region MoveFiles
        //THE SUCCESS OF THESE METHODS DEPEND ENTIRELY ON THE FACT THAT THE .dat FILE ARE IN SEQUENCE.
        //THEY HAVE TO BE IN ORDER OF DATE ACSENDING (OLD TO NEW)
        public static void CreateNewMonthDir(ClassDataFile dataFile, string newLoc)
        {
            Directory.CreateDirectory(newLoc + "\\" + dataFile.Month);
        }

        public static void CreateNewDayDir(ClassDataFile dataFile, string newLoc)
        {
            Directory.CreateDirectory(newLoc + "\\" + dataFile.Day);
        }

        public static void MoveFiles(ClassDataFile[] files)
        {
            foreach (ClassDataFile file in files)
            {
                if (Directory.Exists("C:\\NewDatLocation"))
                {
                    if (Directory.Exists("C:\\NewDatLocation" + "\\" + file.MonthName))
                    {
                        if (Directory.Exists("C:\\NewDatLocation" + "\\" + file.MonthName + " 2015\\" + file.Day))
                        {
                            File.Copy(file.Location, "C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\" + file.FileName);
                            file.NewLocation = "C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\" + file.FileName;
                        }
                        else
                        {
                            Directory.CreateDirectory("C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\");
                            File.Copy(file.Location, "C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\" + file.FileName);
                            file.NewLocation = "C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\" + file.FileName;
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory("C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\");
                        File.Copy(file.Location, "C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\" + file.FileName);
                        file.NewLocation = "C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\" + file.FileName;
                    }
                }
                else
                {
                    Directory.CreateDirectory("C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\");
                    File.Copy(file.Location, "C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\" + file.FileName);
                    file.NewLocation = "C:\\NewDATLocation\\" + file.MonthName + " 2015\\" + file.Day + "\\" + file.FileName;
                }
            }
        }
        #endregion
    }
}
