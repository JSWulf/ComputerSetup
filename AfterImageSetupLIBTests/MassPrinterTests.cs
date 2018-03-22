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
    public class MassPrinterTests
    {
        [TestMethod()]
        public void RunTest()
        {
            MassPrinter massPrinter = new MassPrinter("Printers.conf");

            foreach (var host in MassPrinter.readFile("HMI.txt"))
            {
                massPrinter.HostName = host;
                massPrinter.CheckAndRun();
            }
            

            Assert.Inconclusive();
        }
    }
}