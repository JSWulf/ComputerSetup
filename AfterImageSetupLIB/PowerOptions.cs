using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterImageSetupLIB
{
    public class PowerOptions
    {
        /// <summary>
        /// Do Nothing = 0, Sleep = 1
        /// </summary>
        /// <param name="PluggedIn"></param>
        /// <param name="Battery"></param>
        public PowerOptions(int PluggedIn, int Battery)
        {
            powerSettings = new int[] { PluggedIn, Battery };
        }
        private int[] powerSettings;

        public int[] PowerSettings
        {
            get { return powerSettings; }
            set { powerSettings = value; }
        }


        public override string ToString()
        {
            if (powerSettings == null)
            {
                throw new Exception("Power Options declared but not set");
            }
            return "     Call run(\"cmd.exe /C powercfg -SETACVALUEINDEX 381b4222-f694-41f0-9685-ff5bb260df2e 4f971e89-eebd-4455-a8de-9e59040e7347 5ca83367-6e45-459f-a27b-476b1d01c936 " + 
                   powerSettings[0] + "\")" + Environment.NewLine + //Plugged in
                   "     Call run(\"cmd.exe /C powercfg -SETDCVALUEINDEX 381b4222-f694-41f0-9685-ff5bb260df2e 4f971e89-eebd-4455-a8de-9e59040e7347 5ca83367-6e45-459f-a27b-476b1d01c936 " +
                   powerSettings[1] + "\")" + Environment.NewLine; //battery
        }
    }
}
