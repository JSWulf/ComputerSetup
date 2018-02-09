using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassPrinterPush
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter input file name or confirm: ");
            var TargetListFile = Console.ReadLine();

            var TargetList = new List<string>();

            TargetList.AddRange(File.ReadAllLines(TargetListFile));
            

        }
    }
}
