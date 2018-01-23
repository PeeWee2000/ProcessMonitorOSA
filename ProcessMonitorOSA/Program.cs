//Libraries used (DLLs)
using System;
using System.IO;


//Name of the program
namespace ProcessMonitor
{
    class Program
    {
        //Main segment of the program
        static void Main(string[] args)
        {
            //UserSettings Waef = new UserSettings();
            //Waef.WhiteListLocation = "1";
            //Console.WriteLine(Waef.WhiteListLocation);
            File.Delete("C:\\Temp\\SafeProccesses.txt");
            //Check to see if there is a safe list, if not create one
            if (File.Exists("C:\\Temp\\SafeProccesses.txt") == false)
            {
                Baseline.GenerateInitialBaseline();
            }
            else
            {
                Baseline.AppendToBaseline();
            }
            //else
            //{
            //    foreach (string line in File.ReadAllLines(@"C:\Temp\SafeProccesses.txt"))
            //    {
            //        Index = line.IndexOf("~");
            //        Trimmed = (Index > 0 ? line.Substring(0, Index) : "");
            //        SafeList.Add(Trimmed);
            //    }
            //}

            //Run the second section of the program
            Monitor.MonitorLoop();
        }

    }
}
