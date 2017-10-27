using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;

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
                if (value.EndsWith(".lnk"))
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
        //object shDesktop = (object)"Desktop";
        WshShell shell = new WshShell();
        //string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Notepad.lnk";
        IWshShortcut s = (IWshShortcut)shell.CreateShortcut(LnkFile);
            s.Description = Description;
            s.Hotkey = Hotkey;
            s.TargetPath = Target;
            s.Save();
        }

    }
}
