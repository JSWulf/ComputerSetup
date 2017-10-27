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
    public class AddShortcutTests
    {
        [TestMethod()]
        public void CreateShortcutsTest()
        {
            AddShortcut AddShortcut = new AddShortcut("Shortcuts.conf");
            AddShortcut.CreateShortcuts(@"\\localhost\C$\Users\Default");

            Assert.IsTrue(File.Exists("Output.vbs"));
        }
    }
}