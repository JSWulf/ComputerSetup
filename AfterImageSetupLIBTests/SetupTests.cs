using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        //[TestMethod()]
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
            try
            {
                Setup.HostName = "Localhost";
            }
            catch (Exception er)
            {
                Console.WriteLine(er.ToString());
            }
            //Setup.StartPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            Setup.Template = "Template.vbs";
            Setup.Printer = new Printer("Printers.conf");
            Setup.Printer.printer = Setup.Printer.GetPrinters()[0];
            Setup.PowerOptions = new PowerOptions(0, 0);
            Setup.PinUnpin = new PinUnpin("PinUnpin.conf");
            Setup.TimeZoneConfig = new TimeZoneConfig();
            Setup.TimeZoneConfig.TimeZone = Setup.TimeZoneConfig.TimeZones[0];
            Setup.Manuals = true;
            Setup.AddShortcut = new AddShortcut("Shortcuts.conf");

            Setup.InternetZone = new InternetZone("InternetZone.conf");

            Console.WriteLine(Setup.Run());

            Assert.IsTrue(File.Exists("Output.vbs"));
        }

        //[TestMethod()]
        public void writeFileTest()
        {
            File.WriteAllLines("Output.vbs", Setup.readFile(@"..\..\..\PinUnpin.vbs"));

            Assert.IsTrue(File.Exists("Output.vbs"));
        }
    }
}