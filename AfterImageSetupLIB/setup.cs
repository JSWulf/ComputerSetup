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
        public static TimeZoneConfig TimeZone { get; set; }
        public static PinUnpin PinFiles { get; set; }
        public static Manuals Manuals { get; set; }
        public static PowerOptions PowerSettings { get; set; }
        public static Printer Printer { get; set; }

        private static List<string> Output = new List<string>();


        public static string Run()
        {
            if (string.IsNullOrEmpty(HostName))
            {
                return "Error -- no hostname received";
            }
            if (string.IsNullOrEmpty(UserName) && !UserExists(UserName))
            {
                UserName = "Default";
            }
            Output.Clear();
            addFunctions();

            if (TimeZone != null)
            {
                //set timezone
            }

            if (PinFiles != null)
            {
                //set PinFiles
            }

            if (Manuals != null)
            {
                //set PinFiles
            }

            if (PowerSettings != null)
            {
                //set PinFiles
            }

            if (Printer != null)
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

        public static bool writeFile(List<string> contents)
        {
            //var ConToArray = contents.
            Console.WriteLine("write file");
            File.WriteAllLines("Output.vbs", contents);
            Console.WriteLine("Success");

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

        public static List<string> readFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException();
            }

            var fileLines = File.ReadAllLines(file);
            var newOutput = new List<string>();

            foreach (var line in fileLines)
            {
                //Console.WriteLine(line);
                newOutput.Add(line);
            }

            return newOutput;

        }

        private static void addFunctions()
        {
            var getCode = readFile(@"..\..\..\PinUnpin.vbs");
            
            Output.AddRange(getCode);
        }
        

    }
}
