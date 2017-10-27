using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AfterImageSetupLIB
{
    public static class Setup
    {
        public static string HostName { get; set; }
        public static string UserName { get; set; }
        public static TimeZoneConfig TimeZoneConfig { get; set; }
        public static PinUnpin PinUnpin { get; set; }
        public static bool? Manuals { get; set; }
        public static PowerOptions PowerOptions { get; set; }
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
            Output.Add("     Call run(\"cmd.exe / C gpupdate / force\")");
            if (TimeZoneConfig != null)
            {
                //set timezone
                Debug.WriteLine("TimeZone not null");
                Output.Add("' *** set timezone");
                Output.Add(TimeZoneConfig.ToString());
            }

            if (PinUnpin != null)
            {
                //set PinFiles
                Debug.WriteLine("PinUnpin not null");
                Output.Add("' *** set pins");
                Output.Add(PinUnpin.ToString());
            }

            if (Manuals == true)
            {
                //copy manuals
                Debug.WriteLine("Manuals true");
                //tell something to copy when files are copied later.
                //nah, just move this to wherever the copy function takes place.
            }

            if (PowerOptions != null)
            {
                //set power settings
                Debug.WriteLine("Power Options not null");
                Output.Add("' *** set Power");
                Output.Add(PowerOptions.ToString());
            }

            if (Printer != null)
            {
                //set printer
                Debug.WriteLine("Printer not null");
                Output.Add("' *** set Printer");
                Output.Add("     " + Printer);
            }

            Output.Add(Environment.NewLine + "     call cleanup()");

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
            var getCode = readFile(@"Template.vbs");
            
            Output.AddRange(getCode);
        }
        

    }
}
