using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB
{
    public class Printer
    {
        public Printer(string configFile)
        {
            printerConfig = new Config(configFile);
            printers = printerConfig.Items;
        }

        private Config printerConfig;
        private List<string> printers = new List<string>();

        public string printer { get; set; }

        public List<string> GetPrinters()
        {
            return printers;
        }
        
        public override string ToString()
        {
            if (printer == null)
            {
                throw new Exception("Printer was declared but not set or selected");
            }

            if (!printers.Contains(printer))
            {
                printerConfig.Add(printer);
            }

            return "call SetPrinter(\"" + printer + "\")";
        }
    }
}
