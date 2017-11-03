using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaptopSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LaptopSetup.Tests
{
    [TestClass()]
    public class SettingsTests
    {

        [TestMethod]
        public void ReadUsers()
        {
            foreach (var dir in Directory.GetDirectories(@"\\localhost\C$\Users\"))
            {
                var dirname = Path.GetFileName(dir);
                if (dirname != "Default User" &&
                    dirname != "nimda" &&
                    dirname != "All Users" &&
                    dirname != "Public")
                {
                    Console.WriteLine(dirname);
                }
            }

            Assert.Inconclusive();
        }
        
    }
}