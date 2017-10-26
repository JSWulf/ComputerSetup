using Microsoft.VisualStudio.TestTools.UnitTesting;
using AfterImageSetupLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB.Tests
{
    [TestClass()]
    public class ConfigTests
    {
        [TestMethod()]
        public void ConfigTest()
        {
            Config printerConf = new Config("Printers.conf");

            foreach (var line in printerConf.Items)
            {
                Console.WriteLine(line);
            }
            Assert.IsTrue(printerConf.Items.Count == 3);
        }
    }
}