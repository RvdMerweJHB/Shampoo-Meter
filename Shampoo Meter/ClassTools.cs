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
        public static void CreateNewMonthDir(ClassDataFile dataFile, string newLoc)
        {
            Directory.CreateDirectory(newLoc + "\\" + dataFile.Month);
        }

        public static void CreateNewDayDir(ClassDataFile dataFile, string newLoc)
        {
            Directory.CreateDirectory(newLoc + "\\" + dataFile.Day);
        }

        public static void MoveFiles(ClassDataFile[] files, string outputLoaction)
        {
            foreach (ClassDataFile file in files)
            {
                string yearNumber = file.Year;
                if (Directory.Exists(outputLoaction))
                {
                    if (Directory.Exists(outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\"))
                    {
                        if (Directory.Exists(outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day))
                        {
                            File.Copy(file.Location, outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\" + file.FileName);
                            file.NewLocation = outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\" + file.FileName;
                        }
                        else
                        {
                            Directory.CreateDirectory(outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\");
                            File.Copy(file.Location, outputLoaction + " \\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\" + file.FileName);
                            file.NewLocation = outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\" + file.FileName;
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\");
                        File.Copy(file.Location, outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\" + file.FileName);
                        file.NewLocation = outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\" + file.FileName;
                    }
                }
                else
                {
                    Directory.CreateDirectory(outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\");
                    File.Copy(file.Location, outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\" + file.FileName);
                    file.NewLocation = outputLoaction + "\\" + file.MonthName + " " + yearNumber + "\\" + file.Day + "\\" + file.FileName;
                }
                File.Delete(file.Location);
            }
        }
        #endregion
    }
}
