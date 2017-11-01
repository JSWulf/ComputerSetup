using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaptopSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSetup.Tests
{
    [TestClass()]
    public class SettingsTests
    {
        [TestMethod()]
        public void SettingCheckTest()
        {
            var result = Settings.Check("TimeZones");

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void SettingCheckTestfalse()
        {
            var result = Settings.Check("someone");

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Settings.Update("test", "me");

            Assert.Inconclusive();
        }

        [TestMethod()]
        public void ReadBoolTest()
        {
            Settings.ReadBool(new object());

            Assert.Inconclusive();
        }
    }
}