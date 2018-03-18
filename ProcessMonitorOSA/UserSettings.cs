using System;
using System.IO;

namespace ProcessMonitorOSA
{
    class UserSettings
    {
        public static string WhiteListLocation
        {
            get
            {
                if (OS.WhatIs() == "win")
                { return TextReader.GetText(@"(?<=WindowsWhiteList=).*$", "Settings.txt"); }
                else if (OS.WhatIs() == "gnu")
                { return TextReader.GetText(@"(?<=LinuxWhiteList=).*$", "Settings.txt"); }
                else return ("Unknown OS detected");
            }
            set { }
        }
        public static bool AppendMode
        { get
            { if (TextReader.GetText(@"(?<=AppendMode=).*$", "Settings.txt") == "True")
                { return true; }
                else { return false; }
            }
        }
        
    }
}

