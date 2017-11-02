using AfterImageSetupLIB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaptopSetup
{
    public partial class FormMain : Form
    {

        Properties.Settings DefSet = Properties.Settings.Default;

        string Cdir = @"Conf\";

        public FormMain()
        {
            InitializeComponent();

            var args = Environment.GetCommandLineArgs();

            if (args.Length > 2)
            {
                HostName = args[1];
                UserName = args[2];
            }
            else
            {
                HostName = "localhost";
                UserName = Environment.UserName;
            }

            label1.Text = $"Target: {HostName}, User: {UserName}";

            

            Setup.HostName = HostName;
            Setup.Printer = new Printer(Cdir + "Printers.conf");
            //Setup.Printer.printer = Setup.Printer.GetPrinters()[0];
            Setup.PowerOptions = new PowerOptions(0, 0);
            Setup.PinUnpin = new PinUnpin(Cdir + "PinUnpin.conf");
            Setup.TimeZoneConfig = new TimeZoneConfig();
            //Setup.TimeZoneConfig.TimeZone = Setup.TimeZoneConfig.TimeZones[0];
            //Setup.Manuals = true;
            Setup.AddShortcut = new AddShortcut(Cdir + "Shortcuts.conf");

            Setup.InternetZone = new InternetZone(Cdir + "InternetZone.conf");

            comboBoxPrinter.Items.AddRange(Setup.Printer.GetPrinters().ToArray());
            comboBoxTimeZone.Items.AddRange(Setup.TimeZoneConfig.TimeZones.ToArray());

            var po = new string[] { "Do Nothing", "Sleep" };
            comboBoxPlugged.Items.AddRange(po);
            comboBoxBattery.Items.AddRange(po);

            Settings.LoadSettings(this);

        }

        public string HostName { get; set; }
        public string UserName { get; set; }

        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxPowerOptions_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxPlugged.Enabled = checkBoxPowerOptions.Checked;
            comboBoxBattery.Enabled = checkBoxPowerOptions.Checked;

            DefSet.SetPower = checkBoxPowerOptions.Checked;
            DefSet.Save();
        }

        private void checkBoxPrinter_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxPrinter.Enabled = checkBoxPrinter.Checked;

            DefSet.Printer = checkBoxPrinter.Checked;
            DefSet.Save();
        }

        private void checkBoxTimeZone_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxTimeZone.Enabled = checkBoxTimeZone.Checked;

            DefSet.TimeZone = checkBoxTimeZone.Checked;
            DefSet.Save();
        }

        private void comboBoxPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefSet.PrinterSelect = comboBoxPrinter.SelectedIndex;
            DefSet.Save();
        }

        private void comboBoxTimeZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefSet.TimeZoneSelect = comboBoxTimeZone.SelectedIndex;
            DefSet.Save();
        }

        private void comboBoxPlugged_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefSet.PowerPluggedSelect = comboBoxPlugged.SelectedIndex;
            DefSet.Save();
        }

        private void comboBoxBattery_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefSet.PowerBattSelect = comboBoxBattery.SelectedIndex;
            DefSet.Save();
        }

        private void checkBoxPinUnpin_CheckedChanged(object sender, EventArgs e)
        {
            DefSet.PinUnpin = checkBoxPinUnpin.Checked;
            DefSet.Save();
        }

        private void checkBoxManuals_CheckedChanged(object sender, EventArgs e)
        {
            DefSet.Manuals = checkBoxManuals.Checked;
            DefSet.Save();
        }

        private void checkBoxShortcuts_CheckedChanged(object sender, EventArgs e)
        {
            DefSet.Shortcuts = checkBoxShortcuts.Checked;
            DefSet.Save();
        }

        private void checkBoxInternetZones_CheckedChanged(object sender, EventArgs e)
        {
            DefSet.InternetZone = checkBoxInternetZones.Checked;
            DefSet.Save();
        }

        private void buttonDetailClick(object sender, EventArgs e)
        {

        }

        private void buttonRun_Click(object sender, EventArgs e)
        {

        }
    }
}
