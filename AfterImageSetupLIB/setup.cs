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
        public static AddShortcut AddShortcut { get; set; }

        private static List<string> Output = new List<string>();


        public static string Run()
        {
            if (string.IsNullOrEmpty(HostName))
            {
                return "Error -- no hostname received";
            }
            if (string.IsNullOrEmpty(UserName) || !UserExists(UserName))
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
                try
                {
                    PostRunCopyFiles();
                }
                catch (Exception)
                {
                    throw;
                }

                if (AddShortcut != null)
                {
                    //create shortcuts
                    Debug.WriteLine("Create shortcuts");
                    var TargetUser = @"\\" + HostName + @"\C$\Users\" + UserName + @"\";
                    AddShortcut.CreateShortcuts(TargetUser);
                }

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

        private static void PostRunCopyFiles()
        {
            var TargetDesktop = @"\\" + HostName + @"\C$\Users\" + UserName + @"\Desktop\";
            Debug.WriteLine(TargetDesktop);
            var TargetUser = @"\\" + HostName + @"\C$\Users\" + UserName + @"\";
            Debug.WriteLine(TargetUser);
            var StartupPath = @"AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\";
            Debug.WriteLine(TargetUser + StartupPath);
            if (!Directory.Exists(TargetDesktop))
            {
                throw new Exception("Can't find target machine or user");
            }
            if (Manuals == true)
            {
                //copy manuals
                Debug.WriteLine("Manuals true");

                
                //copy manuals to target desktop
                Common.CopyDirectory("IT Information", TargetDesktop + "IT Information");
            }

            if (!Directory.Exists(TargetUser + StartupPath))
            {
                Directory.CreateDirectory(TargetUser + StartupPath);
            }

            File.Copy("Output.vbs", TargetUser + StartupPath + "RunOnce.vbs", true);
        }
        

    }
}
