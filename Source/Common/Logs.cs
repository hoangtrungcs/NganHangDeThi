using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Logs
    {
        public static void WriteLog(string log)
        {
            string path = "Log.txt";

            if (!File.Exists(path))
            {
                var logFile = File.Create(path);
                logFile.Close();
            }

            TextWriter tw = new StreamWriter(path);
            tw.WriteLine(log);
            tw.Close();
        }
    }
}
