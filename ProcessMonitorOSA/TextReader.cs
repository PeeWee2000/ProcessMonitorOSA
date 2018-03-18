using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ProcessMonitorOSA
{
    class TextReader
    {
        public static string GetText(string SearchString, string File)
        {
            string Match = "";
            using (StreamReader r = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, File)))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    // 
                    // Try to match each line against the Regex.
                    Match m = Regex.Match(line, SearchString);
                    if (m.Success)
                    {
                        // Y.
                        // Write original line and the value.
                        string v = m.Groups[1].Value;
                        Match = Regex.Match(line, SearchString).ToString();
                    }
                }
            }
            return Match;
        }
    }
}
