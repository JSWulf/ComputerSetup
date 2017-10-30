using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB
{
    public class InternetZone
    {
        public InternetZone(string ConfigFile)
        {
            if (!ConfigFile.EndsWith(".conf"))
            {
                Domains.Add("     call AddZone(\"" + ConfigFile + "\")");
            } else
            {
                ZoneConfig = new Config(ConfigFile);
                AddDomains();
            }
        }

        private Config ZoneConfig;

        private List<string> Domains = new List<string>();

        private StringBuilder Output = new StringBuilder();

        private void AddDomains()
        {
            foreach (var line in ZoneConfig.Items)
            {
                Output.Append("     call AddZone(\"" + line + "\")" + Environment.NewLine);
            }
        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
