using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB
{
    public class AddShortcut
    {
        public AddShortcut(string ConfigFile)
        {
            ShortcutConfig = new Config(ConfigFile);
        }
        public AddShortcut(string ConfigFile, string HostName, string UserName)
        {
            ShortcutConfig = new Config(ConfigFile);
            Host = HostName;
            User = UserName;
        }

        public string Host { get; set; }
        public string User { get; set; }

        Config ShortcutConfig;

        public void CreateShortcuts(string UserProfile)
        {
            foreach (var line in ShortcutConfig.Items)
            {
                var s_info = line.Split(',');

                try
                {
                    Shortcut shortcut = new Shortcut(UserProfile + @"\" + s_info[0].Trim(), s_info[1].Trim());
                    shortcut.CreateShortcut();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Problem with " + line + Environment.NewLine +
                        e.Message);
                }
            }
        }
    }
}
