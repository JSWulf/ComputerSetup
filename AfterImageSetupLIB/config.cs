using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AfterImageSetupLIB
{
    public class Config
    {
        public Config(string file)
        {
            ConfigFile = file;
            Items = new List<string>();
            try
            {
                Debug.WriteLine("read file");
                ReadConfigFile();
                Debug.WriteLine("read file complete");
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
            Debug.WriteLine("Reading " + ConfigFile);
            
            foreach (var line in File.ReadAllLines(ConfigFile))
            {
                
                if (!IsComment(line))
                {
                    Items.Add(line.Trim());
                }
                Debug.WriteLine(line);
            }
        }

        
        private bool IsComment(string line)
        {
            if (line.Trim().StartsWith("#"))
            {
                Debug.WriteLine("Is a comment: " + line.Trim());
                return true;
            }
            return false;
        }

        public void Add(string line)
        {
            var newItems = new List<string>();

            foreach (var confLine in File.ReadAllLines(ConfigFile))
            {
                newItems.Add(confLine);
            }
            newItems.Add(line);

            File.WriteAllLines(ConfigFile, newItems);
        }

    }
    
}
