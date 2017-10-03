using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB
{
    public class PinUnpin
    {
        PinUnpin()
        {
            Pin = new List<string>();
            UnPin = new List<string>();
        }

        public List<string> Pin { get; set; }
        public List<string> UnPin { get; set; }
        
        
        public string GetCommand()
        {

            return "";
        }
    }
}
