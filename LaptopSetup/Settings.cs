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
        
        public static void LoadSettings(FormMain Main)
        {
            var test = Properties.Settings.Default;

            Main.checkBoxAllUsers.Checked = test.AllUsers;

            Main.checkBoxPrinter.Checked = test.Printer;
            Main.comboBoxPrinter.Enabled = test.Printer;
            Main.comboBoxPrinter.SelectedIndex = test.PrinterSelect;

            Main.checkBoxTimeZone.Checked = test.TimeZone;
            Main.comboBoxTimeZone.Enabled = test.TimeZone;
            Main.comboBoxTimeZone.SelectedIndex = test.TimeZoneSelect;

            Main.checkBoxPowerOptions.Checked = test.SetPower;
            Main.comboBoxPlugged.Enabled = test.SetPower;
            Main.comboBoxBattery.Enabled = test.SetPower;
            Main.comboBoxPlugged.SelectedIndex = test.PowerPluggedSelect;
            Main.comboBoxBattery.SelectedIndex = test.PowerBattSelect;

            Main.checkBoxPinUnpin.Checked = test.PinUnpin;
            Main.checkBoxManuals.Checked = test.Manuals;
            Main.checkBoxShortcuts.Checked = test.Shortcuts;
            Main.checkBoxInternetZones.Checked = test.InternetZone;
        }
    }
}
