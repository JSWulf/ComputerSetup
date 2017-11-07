using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;
using System.Diagnostics;
using System.IO;

namespace AfterImageSetupLIB
{
    public class Shortcut
    {
        /// <summary>
        /// Create a shortcut
        /// shortcut: Where to create the shortcut. Must end in .lnk
        /// target: Where the shortcut points to.
        /// </summary>
        /// <param name="shortcut">*.lnk file.</param>
        /// <param name="target">Where to point to.</param>
        public Shortcut(string shortcut, string target)
        {
            LnkFile = shortcut;
            Target = target;
            Debug.WriteLine(LnkFile);
            Debug.WriteLine(Target);
        }
        /// <summary>
        /// *.lnk file
        /// </summary>
        private string lnkFile;

        public string LnkFile
        {
            get { return lnkFile; }
            set
            {
                if (value.EndsWith(".lnk") || value.EndsWith(".url"))
                {
                    lnkFile = value;
                }
                else
                {
                    throw new Exception("shortcut file must end in .lnk");
                }
            }
        }

        public string Description { get; set; }
        public string Hotkey { get; set; }
        /// <summary>
        /// Where shortcut points to.
        /// </summary>
        public string Target { get; set; }

        public void CreateShortcut()
        {
            if (Target.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
            {
                InternetShortcut();
            }
            else
            {
                DesktopShortcut();
            }
        }

        private void InternetShortcut()
        {
            //string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            using (StreamWriter writer = new StreamWriter(LnkFile))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=" + Target);
                writer.Flush();
            }
        }

        private void DesktopShortcut()
        {
            Debug.WriteLine("Lnk: " + LnkFile);
            Debug.WriteLine("des: " + Description);
            Debug.WriteLine("hot: " + Hotkey);
            Debug.WriteLine("tar: " + Target);
            //object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            //string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Notepad.lnk";
            IWshShortcut s = (IWshShortcut)shell.CreateShortcut(LnkFile);
            //s.Description = Description;
            //s.Hotkey = Hotkey;
            if (!string.IsNullOrEmpty(Description))
            { s.Description = Description; }
            if (!string.IsNullOrEmpty(Hotkey))
            { s.Hotkey = Hotkey; }
            s.TargetPath = Target;
            s.Save();
        }
    }
}
