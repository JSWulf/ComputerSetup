﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaptopSetup
{
    public partial class FormMain : Form
    {
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
        }

        public string HostName { get; set; }
        public string UserName { get; set; }

        private void checkBoxAllUsers_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}