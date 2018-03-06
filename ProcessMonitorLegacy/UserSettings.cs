using System.Configuration;

namespace ProcessMonitor
{
    class UserSettings
    {
        public static string WhiteListLocation
        {
            get
            {
                return ConfigurationManager.AppSettings["WhiteListLocation"];
            }
            set { }
        }
    }
}
