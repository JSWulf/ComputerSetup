using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB
{
    public static class Setup
    {
        public static string HostName { get; set; }
        public static string UserName { get; set; }
        public static string TimeZone { get; set; }
        public static bool PinFiles { get; set; }
        public static bool Manuals { get; set; }
        public static string PowerSettings { get; set; }
        public static string Printer { get; set; }
        private static StringBuilder Output = new StringBuilder();


        public static string Run()
        {
            if (string.IsNullOrEmpty(HostName))
            {
                return "Error -- not hostname received";
            }
            if (string.IsNullOrEmpty(UserName) && !UserExists(UserName))
            {
                UserName = "Default";
            }
            Output.Clear();

            if (!string.IsNullOrEmpty(TimeZone))
            {
                //set timezone
            }

            if (PinFiles)
            {
                //set PinFiles
            }

            if (Manuals)
            {
                //set PinFiles
            }

            if (!string.IsNullOrEmpty(PowerSettings))
            {
                //set PinFiles
            }

            if (!string.IsNullOrEmpty(Printer))
            {
                //set PinFiles
            }

            if (writeFile(Output))
            {
                return "Run Complete...";
            }
            else
            {
                return "Error Writing file.";
            }
        }

        private static bool writeFile(StringBuilder contents)
        {

            return true;
        }

        private static bool UserExists(string User)
        {
            if (Directory.Exists(@"\\" + HostName + @"\C$\Users\" + User))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
    }
}
