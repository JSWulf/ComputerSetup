using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB
{
    public class PinUnpin
    {
        public PinUnpin(string configFile)
        {
            pinConfig = new Config(configFile);
        }

        private Config pinConfig;


        public override string ToString()
        {
            var output = new StringBuilder();
            foreach (var line in pinConfig.Items)
            {
                output.Append("     Call pinToTaskbar(" + line + ")" + Environment.NewLine);
            }
            return output.ToString();
        }
    }
}
