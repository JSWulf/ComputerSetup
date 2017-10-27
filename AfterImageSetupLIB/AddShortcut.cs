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

        Config ShortcutConfig;

        public void CreateShortcuts(string UserProfile)
        {
            foreach (var line in ShortcutConfig.Items)
            {
                var s_info = line.Split(',');

                try
                {
                    Shortcut shortcut = new Shortcut(s_info[0], s_info[1]);
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
