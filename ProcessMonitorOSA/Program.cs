//Libraries used (DLLs)
using System;
using System.IO;
using System.Text.RegularExpressions;


//Name of the program
namespace ProcessMonitorOSA
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
            }

            //Check to see if there is a safe list, if not create one
            if (File.Exists(UserSettings.WhiteListLocation) == false)
            {
                Baseline.GenerateInitialBaseline();
            }
            else if (UserSettings.AppendMode == false)
                
            {
                Console.WriteLine("Whitelist, detected in settings program starting");
                Monitor.MonitorLoop(); }
            else
            {
                Baseline.AppendToBaseline();
            }

            Monitor.MonitorLoop();
        }

    }
}
