using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;



namespace ProcessMonitor
{
    class Monitor
    {
        public static void MonitorLoop()
        {
            //Declare variables to be used
            List<string> ProcessList = new List<string>();
            List<string> SafeList = new List<string>();
            int Index;
            String Trimmed;

            //Run through the running processlist and compare it to the safe list
            foreach (string line in File.ReadAllLines(@"C:\Temp\SafeProccesses.txt"))
            {
                Index = line.IndexOf("~");
                Trimmed = (Index > 0 ? line.Substring(0, Index) : "");
                SafeList.Add(Trimmed);
            }
            while (0 == 0)
            {
                //Get a list called localAll of all running processes and do something for each one
                Process[] localAll = Process.GetProcesses();
                foreach (Process IndividualProcess in localAll)
                {
                    //If a running process is not in the safelist attempt to kill it
                    if (SafeList.Contains(IndividualProcess.ProcessName) == false)
                    {

                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Illegal process detected: " + IndividualProcess.ProcessName);
                            Console.WriteLine(IndividualProcess.MainModule.FileVersionInfo);
                            Console.WriteLine("Entry Point: " + IndividualProcess.MainModule.EntryPointAddress);
                            //IndividualProcess.Kill();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Process terminated");
                        }
                        catch { };

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Continuing to monitor....");

                    }

                }
            }
        }
    }
}
