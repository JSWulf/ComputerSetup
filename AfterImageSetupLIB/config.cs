using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB
{
    public class Config
    {
        public Config(string file)
        {
            ConfigFile = file;
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private string ConfigFile { get; set; }
        public List<string> Items { get;  private set; }

        private void ReadConfigFile()
        {
            foreach (var line in File.ReadAllLines(ConfigFile))
            {
                if (!line.StartsWith("#"))
                {
                    Items.Add(line);
                }
            }
        }

        


    }
    
}
