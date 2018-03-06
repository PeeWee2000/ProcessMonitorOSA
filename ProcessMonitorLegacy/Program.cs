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
                        
            
            if (UserSettings.WhiteListLocation == "")
            {
                Console.WriteLine("No whitelist specified in the appconfig, please specify the location of the White List: ");
                UserSettings.WhiteListLocation = Console.ReadLine();
                Console.WriteLine(UserSettings.WhiteListLocation);
            }
            //Check to see if there is a safe list, if not create one
            if (File.Exists(UserSettings.WhiteListLocation) == false)
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
