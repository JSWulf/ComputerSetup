using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLfileLaunchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = new StringBuilder();
            foreach (var arg in args)
            {
                output.AppendLine(arg);
            }

            MessageBox.Show(output.ToString());
        }
    }
}
