using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB
{
    public class MassPrinter
    {
        public MassPrinter(string PrinterConf)
        {
            Printer = new Printer(PrinterConf);
            Printer.printer = Printer.GetPrinters()[0];

            AddShortcut = new AddShortcut("Shortcuts.conf");
        }

        public string HostName { get; set; }
        public Printer Printer { get; set; }
        public AddShortcut AddShortcut { get; set; }

        private static List<string> Output = new List<string>();
        
        public static string Template = "Template.vbs";


        public string Run()
        {
            

            Output.Clear();
            addFunctions();
            Output.Add("     Call run(\"cmd.exe /C gpupdate /force\")");

            if (Printer != null)
            {
                //set printer
                //Debug.WriteLine("Printer not null");
                Output.Add("' *** set Printer");
                Output.Add("     " + Printer);
            }
            

            Output.Add(Environment.NewLine + "     call cleanup()");

            if (writeFile(Output))
            {
                foreach (var user in GetUsers(HostName))
                {
                    Console.Write(user + "	");
                    try
                    {
                        PostRunCopyFiles(user);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    if (AddShortcut != null)
                    {
                        //create shortcuts
                        //Debug.WriteLine("Create shortcuts");
                        var TargetUser = @"\\" + HostName + @"\C$\Users\" + user + @"\";
                        AddShortcut.CreateShortcuts(TargetUser);
                    }
                }

                //Console.WriteLine("test Complete");
                return "Run Complete...";
            }
            else
            {
                return "Error Writing file.";
            }
        }

        public void CheckAndRun()
        {
            if(Directory.Exists(@"\\" + HostName + @"\C$\"))
            {
                try
                {
                    Console.Write(HostName + "	");
                    Console.WriteLine(Run());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } else
            {
                Console.WriteLine(HostName + "    " + "Connection failed.");
            }

        }

        private bool UserExists(string User)
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

        public string[] GetUsers(string host)
        {
            string UsersPath = @"\\" + host + @"\C$\Users";
            var UsersList = new List<string>();
            if (Directory.Exists(UsersPath))
            {
                foreach (var folder in Directory.GetDirectories(UsersPath))
                {
                    if (!folder.EndsWith("Default User", StringComparison.InvariantCultureIgnoreCase) &&
                        !folder.EndsWith("All Users", StringComparison.InvariantCultureIgnoreCase) &&
                        !folder.EndsWith("nimda", StringComparison.InvariantCultureIgnoreCase) &&
                        !folder.EndsWith("Public", StringComparison.InvariantCultureIgnoreCase))
                    {
                        UsersList.Add(Path.GetFileName(folder));
                        //Console.WriteLine(Path.GetFileName(folder));
                    }
                }

                return UsersList.ToArray();
            }
            else
            {
                return new string[] { "" };
            }
        }

        private void PostRunCopyFiles(string tarUser)
        {
            var TargetDesktop = @"\\" + HostName + @"\C$\Users\" + tarUser + @"\Desktop\";
            //Debug.WriteLine(TargetDesktop);
            var TargetUser = @"\\" + HostName + @"\C$\Users\" + tarUser + @"\";
            //Debug.WriteLine(TargetUser);
            var StartupPath = @"AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\";
            //Debug.WriteLine(TargetUser + StartupPath);
            if (!Directory.Exists(TargetDesktop))
            {
                throw new Exception("Can't find target machine or user");
            }

            if (!Directory.Exists(TargetUser + StartupPath))
            {
                Directory.CreateDirectory(TargetUser + StartupPath);
            }

            File.Copy("Output.vbs", TargetUser + StartupPath + "RunOnce.vbs", true);
        }

        public static bool writeFile(List<string> contents)
        {
            //var ConToArray = contents.
            //Console.WriteLine("write file");
            File.WriteAllLines("Output.vbs", contents);
            //Console.WriteLine("Success");

            return true;
        }
        private static void addFunctions()
        {
            //var getCode = readFile(StartPath + @"\Template.vbs");
            var getCode = readFile(Template);

            Output.AddRange(getCode);
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
                newOutput.Add(line.Trim());
            }

            return newOutput;

        }
    }
}
