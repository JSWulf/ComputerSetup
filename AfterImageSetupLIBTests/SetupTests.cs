﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using AfterImageSetupLIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AfterImageSetupLIB.Tests
{
    [TestClass()]
    public class SetupTests
    {
        [TestMethod()]
        public void readFileTest()
        {
            try
            {
                Setup.readFile(@"..\..\..\PinUnpin.vbs");

                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void RunTest()
        {
            Setup.HostName = "Localhost";
            Setup.Printer = new Printer("Printers.conf");
            Setup.Printer.printer = Setup.Printer.GetPrinters()[0];
            Setup.PowerOptions = new PowerOptions(0, 0);
            Console.WriteLine(Setup.Run());

            Assert.IsTrue(File.Exists("Output.vbs"));
        }

        [TestMethod()]
        public void writeFileTest()
        {
            File.WriteAllLines("Output.vbs", Setup.readFile(@"..\..\..\PinUnpin.vbs"));

            Assert.IsTrue(File.Exists("Output.vbs"));
        }
    }
}