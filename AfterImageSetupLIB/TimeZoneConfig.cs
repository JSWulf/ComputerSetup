using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB
{
    public class TimeZoneConfig
    {
        //public TimeZoneConfig()
        //{
            
        //}
        public string TimeZone { get; set; }
        
        private List<string> timeZones = new List<string>() {
                "Pacific Standard Time",
                "Mountain Daylight Time",
                "Central Standard Time",
                "Eastern Standard Time",
                "W. Europe Standard Time"
            };
        public List<string> TimeZones
        {
            get { return timeZones; }
            private set { timeZones = value; }
        }




        //private List<string> ListTimeZones()
        //{
        //    return Time
        //}


        public override string ToString()
        {
            if (string.IsNullOrEmpty(TimeZone))
            {
                throw new Exception("TimeZone not selected");
            }
            return "     Call run(\"cmd.exe /C TZUTIL /s \"\"" + TimeZone + "\"\" \")" + Environment.NewLine;
        }

    }
}
