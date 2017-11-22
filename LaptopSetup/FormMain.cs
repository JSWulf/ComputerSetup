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

        string StartPath;
        string Cdir;

        public FormMain()
        {
            InitializeComponent();
            
            var args = Environment.GetCommandLineArgs();

            if (args.Length > 2)
            {
                //HostName = args[1];
                //UserName = args[2];
                if (args.Length > 3)
                {
                    MessageBox.Show("Hide!");
                }

                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].Contains(':'))
                    {
                        var argSplit = args[i].Split(':');
                        ShowSection(argSplit[1]);
                        //MessageBox.Show(args[i]);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(HostName))
                        {
                            HostName = args[i];
                        }
                        else if (string.IsNullOrEmpty(UserName))
                        {
                            UserName = args[i];
                        }
                    }
                }
            }
            else
            {
                HostName = "localhost";
                UserName = Environment.UserName;
            }

            label1.Text = $"Target: {HostName}, User: {UserName}";

            StartPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            Cdir = StartPath + @"\Conf\";

            try
            {
                Setup.Printer = new Printer(Cdir + "Printers.conf");
                Setup.PinUnpin = new PinUnpin(Cdir + "PinUnpin.conf");
                Setup.TimeZoneConfig = new TimeZoneConfig();
            } catch { MessageBox.Show("Cannot get to conf files -- exiting"); Application.Exit(); }

            comboBoxPrinter.Items.AddRange(Setup.Printer.GetPrinters().ToArray());
            comboBoxTimeZone.Items.AddRange(Setup.TimeZoneConfig.TimeZones.ToArray());

            var po = new string[] { "Do Nothing", "Sleep" };
            comboBoxPlugged.Items.AddRange(po);
            comboBoxBattery.Items.AddRange(po);

            Settings.LoadSettings(this);

            buttonDPinUnpin.Click += new EventHandler(buttonDetailClick);
            buttonDManuals.Click += new EventHandler(buttonDetailClick);
            buttonDShortcuts.Click += new EventHandler(buttonDetailClick);
            buttonDInternetZones.Click += new EventHandler(buttonDetailClick);

        }

        private void ShowSection(string v)
        {
            throw new NotImplementedException();
        }

        public string HostName { get; set; }
        public string UserName { get; set; }

        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

#region basic events
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
        private void checkBoxAllUsers_CheckedChanged(object sender, EventArgs e)
        {
            DefSet.AllUsers = checkBoxAllUsers.Checked;
            DefSet.Save();
        }

        #endregion

        private void buttonDetailClick(object sender, EventArgs e)
        {
            var name = ((Button)sender).Name;

            MessageBox.Show(GetInfo(name));
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("" + comboBoxPlugged.SelectedIndex);

            try
            {
                run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void run()
        {
            if (SetTheSetup())
            {
                if (checkBoxAllUsers.Checked)
                {
                    MessageBox.Show(RunAllUsers());
                }
                else
                {
                    Setup.UserName = UserName;

                    MessageBox.Show(Setup.Run());
                }
            }
            else
            {
                MessageBox.Show("Something went wrong with configuring the setup");
            }

            
        }

        private string RunAllUsers()
        {
            var output = new StringBuilder();

            foreach (var dir in Directory.GetDirectories(@"\\" + HostName + @"\C$\Users\"))
            {
                var dirname = Path.GetFileName(dir);
                if (dirname != "Default User" &&
                    dirname != "nimda" &&
                    dirname != "All Users" &&
                    dirname != "Public")
                {
                    Setup.UserName = dirname;
                    output.AppendLine("For " + dirname + ": " + Setup.Run());
                }
            }

            return output.ToString();
        }

        private bool SetTheSetup()
        {
            Setup.HostName = HostName;
            Setup.Template = StartPath + @"\Template.vbs";
            Setup.ManualsPath = StartPath + @"\IT Guides";

            if (checkBoxPrinter.Checked)
            {
                Setup.Printer.printer = comboBoxPrinter.Text;
            } else { Setup.Printer = null; }
            if (checkBoxTimeZone.Checked)
            {
                Setup.TimeZoneConfig.TimeZone = comboBoxTimeZone.Text;
            }
            else { Setup.TimeZoneConfig = null; }
            if (checkBoxPowerOptions.Checked)
            {
                var plug = comboBoxPlugged.SelectedIndex;
                var batt = comboBoxBattery.SelectedIndex;
                Setup.PowerOptions = new PowerOptions(plug, batt);
            }
            if (!checkBoxPinUnpin.Checked)
            {
                Setup.PinUnpin = null;
            }
            if (checkBoxManuals.Checked)
            {
                Setup.Manuals = true;
            }
            if (checkBoxShortcuts.Checked)
            {
                Setup.AddShortcut = new AddShortcut(Cdir + "Shortcuts.conf");
            }
            if (checkBoxInternetZones.Checked)
            {
                Setup.InternetZone = new InternetZone(Cdir + "InternetZone.conf");
            }

            return true;
        }

        private string GetInfo(string name)
        {
            switch (name)
            {
                case "buttonDPinUnpin":
                    return ReadConf(Cdir + "PinUnpin.conf");
                case "buttonDManuals":
                    return "Copies a folder of manuals to desktop.";
                case "buttonDShortcuts":
                    return ReadConf(Cdir + "Shortcuts.conf");
                case "buttonDInternetZones":
                    return ReadConf(Cdir + "InternetZone.conf");
                default:
                    return "No Information defined.";
            }
        }

        private string ReadConf(string confFile)
        {
            var output = new StringBuilder();
            try
            {
                foreach (var line in File.ReadAllLines(confFile))
                {
                    {
                        output.AppendLine(line);
                    }
                }
            } catch
            {
                return "Unable to read configuration file!";
            }

            return output.ToString();
        }

        
    }
}
