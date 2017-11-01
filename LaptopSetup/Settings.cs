using AfterImageSetupLIB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSetup
{
    public static class Settings
    {
        static private List<string> StringList = new List<string>();
        static private List<bool> BoolList = new List<bool>();

        //static public Config SettingConf = new Config(@"Conf\Settings.conf");

        public static void Update<T>(object toSave, T value)
        {
            var ItemToSave = nameof(toSave);
            var TypeToSave = typeof(T);

            if (typeof(T) == typeof(bool))
            {
                Console.WriteLine("we got Bool");
            }
            else if(typeof(T) == typeof(string))
            {
                Console.WriteLine("we got stringy");
            }

        }

        public static bool ReadBool(object sender)
        {
            if (BoolList.Count == 0)
            {
                Console.WriteLine("empty list... read conf");
            }
            return false;
        }

        public static string ReadString(object sender)
        {
            if (StringList.Count == 0)
            {
                Console.WriteLine("empty list... read conf");
            }
            return "";
        }






        public static bool Check(string Setting)
        {
            return false;
            
        }
        public static void Create<T>(string Setting, T value)
        {

            
        }
    }

    public class Vari<T>
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public T Value { get; set; }
    }
}
