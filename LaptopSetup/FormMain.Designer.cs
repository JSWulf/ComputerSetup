namespace LaptopSetup
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxPrinter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxAllUsers = new System.Windows.Forms.CheckBox();
            this.checkBoxPrinter = new System.Windows.Forms.CheckBox();
            this.checkBoxTimeZone = new System.Windows.Forms.CheckBox();
            this.checkBoxPowerOptions = new System.Windows.Forms.CheckBox();
            this.checkBoxPinUnpin = new System.Windows.Forms.CheckBox();
            this.checkBoxManuals = new System.Windows.Forms.CheckBox();
            this.checkBoxShortcuts = new System.Windows.Forms.CheckBox();
            this.checkBoxInternetZones = new System.Windows.Forms.CheckBox();
            this.buttonDPinUnpin = new System.Windows.Forms.Button();
            this.buttonDManuals = new System.Windows.Forms.Button();
            this.buttonDShortcuts = new System.Windows.Forms.Button();
            this.buttonDInternetZones = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTimeZone = new System.Windows.Forms.ComboBox();
            this.comboBoxPlugged = new System.Windows.Forms.ComboBox();
            this.comboBoxBattery = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPrinter
            // 
            this.comboBoxPrinter.FormattingEnabled = true;
            this.comboBoxPrinter.Location = new System.Drawing.Point(102, 66);
            this.comboBoxPrinter.Name = "comboBoxPrinter";
            this.comboBoxPrinter.Size = new System.Drawing.Size(170, 21);
            this.comboBoxPrinter.TabIndex = 0;
            this.comboBoxPrinter.SelectedIndexChanged += new System.EventHandler(this.comboBoxPrinter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Target: Localhost, User: Default1";
            // 
            // checkBoxAllUsers
            // 
            this.checkBoxAllUsers.AutoSize = true;
            this.checkBoxAllUsers.Location = new System.Drawing.Point(80, 37);
            this.checkBoxAllUsers.Name = "checkBoxAllUsers";
            this.checkBoxAllUsers.Size = new System.Drawing.Size(108, 17);
            this.checkBoxAllUsers.TabIndex = 2;
            this.checkBoxAllUsers.Text = "Apply to all users.";
            this.checkBoxAllUsers.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrinter
            // 
            this.checkBoxPrinter.AutoSize = true;
            this.checkBoxPrinter.Location = new System.Drawing.Point(15, 68);
            this.checkBoxPrinter.Name = "checkBoxPrinter";
            this.checkBoxPrinter.Size = new System.Drawing.Size(59, 17);
            this.checkBoxPrinter.TabIndex = 3;
            this.checkBoxPrinter.Text = "Printer:";
            this.checkBoxPrinter.UseVisualStyleBackColor = true;
            this.checkBoxPrinter.CheckedChanged += new System.EventHandler(this.checkBoxPrinter_CheckedChanged);
            // 
            // checkBoxTimeZone
            // 
            this.checkBoxTimeZone.AutoSize = true;
            this.checkBoxTimeZone.Location = new System.Drawing.Point(15, 91);
            this.checkBoxTimeZone.Name = "checkBoxTimeZone";
            this.checkBoxTimeZone.Size = new System.Drawing.Size(77, 17);
            this.checkBoxTimeZone.TabIndex = 4;
            this.checkBoxTimeZone.Text = "TimeZone:";
            this.checkBoxTimeZone.UseVisualStyleBackColor = true;
            this.checkBoxTimeZone.CheckedChanged += new System.EventHandler(this.checkBoxTimeZone_CheckedChanged);
            // 
            // checkBoxPowerOptions
            // 
            this.checkBoxPowerOptions.AutoSize = true;
            this.checkBoxPowerOptions.Location = new System.Drawing.Point(7, 10);
            this.checkBoxPowerOptions.Name = "checkBoxPowerOptions";
            this.checkBoxPowerOptions.Size = new System.Drawing.Size(117, 17);
            this.checkBoxPowerOptions.TabIndex = 5;
            this.checkBoxPowerOptions.Text = "Set Power Options:";
            this.checkBoxPowerOptions.UseVisualStyleBackColor = true;
            this.checkBoxPowerOptions.CheckedChanged += new System.EventHandler(this.checkBoxPowerOptions_CheckedChanged);
            // 
            // checkBoxPinUnpin
            // 
            this.checkBoxPinUnpin.AutoSize = true;
            this.checkBoxPinUnpin.Location = new System.Drawing.Point(15, 192);
            this.checkBoxPinUnpin.Name = "checkBoxPinUnpin";
            this.checkBoxPinUnpin.Size = new System.Drawing.Size(121, 17);
            this.checkBoxPinUnpin.TabIndex = 6;
            this.checkBoxPinUnpin.Text = "Pin and Unpin Items";
            this.checkBoxPinUnpin.UseVisualStyleBackColor = true;
            this.checkBoxPinUnpin.CheckedChanged += new System.EventHandler(this.checkBoxPinUnpin_CheckedChanged);
            // 
            // checkBoxManuals
            // 
            this.checkBoxManuals.AutoSize = true;
            this.checkBoxManuals.Location = new System.Drawing.Point(15, 215);
            this.checkBoxManuals.Name = "checkBoxManuals";
            this.checkBoxManuals.Size = new System.Drawing.Size(148, 17);
            this.checkBoxManuals.TabIndex = 7;
            this.checkBoxManuals.Text = "Copy Manuals to Desktop";
            this.checkBoxManuals.UseVisualStyleBackColor = true;
            this.checkBoxManuals.CheckedChanged += new System.EventHandler(this.checkBoxManuals_CheckedChanged);
            // 
            // checkBoxShortcuts
            // 
            this.checkBoxShortcuts.AutoSize = true;
            this.checkBoxShortcuts.Location = new System.Drawing.Point(15, 238);
            this.checkBoxShortcuts.Name = "checkBoxShortcuts";
            this.checkBoxShortcuts.Size = new System.Drawing.Size(105, 17);
            this.checkBoxShortcuts.TabIndex = 8;
            this.checkBoxShortcuts.Text = "Create Shortcuts";
            this.checkBoxShortcuts.UseVisualStyleBackColor = true;
            this.checkBoxShortcuts.CheckedChanged += new System.EventHandler(this.checkBoxShortcuts_CheckedChanged);
            // 
            // checkBoxInternetZones
            // 
            this.checkBoxInternetZones.AutoSize = true;
            this.checkBoxInternetZones.Location = new System.Drawing.Point(15, 261);
            this.checkBoxInternetZones.Name = "checkBoxInternetZones";
            this.checkBoxInternetZones.Size = new System.Drawing.Size(117, 17);
            this.checkBoxInternetZones.TabIndex = 9;
            this.checkBoxInternetZones.Text = "Add Internet Zones";
            this.checkBoxInternetZones.UseVisualStyleBackColor = true;
            this.checkBoxInternetZones.CheckedChanged += new System.EventHandler(this.checkBoxInternetZones_CheckedChanged);
            // 
            // buttonDPinUnpin
            // 
            this.buttonDPinUnpin.Location = new System.Drawing.Point(197, 188);
            this.buttonDPinUnpin.Name = "buttonDPinUnpin";
            this.buttonDPinUnpin.Size = new System.Drawing.Size(75, 23);
            this.buttonDPinUnpin.TabIndex = 10;
            this.buttonDPinUnpin.Text = "Details...";
            this.buttonDPinUnpin.UseVisualStyleBackColor = true;
            
            // 
            // buttonDManuals
            // 
            this.buttonDManuals.Location = new System.Drawing.Point(197, 211);
            this.buttonDManuals.Name = "buttonDManuals";
            this.buttonDManuals.Size = new System.Drawing.Size(75, 23);
            this.buttonDManuals.TabIndex = 11;
            this.buttonDManuals.Text = "Details...";
            this.buttonDManuals.UseVisualStyleBackColor = true;
            // 
            // buttonDShortcuts
            // 
            this.buttonDShortcuts.Location = new System.Drawing.Point(197, 234);
            this.buttonDShortcuts.Name = "buttonDShortcuts";
            this.buttonDShortcuts.Size = new System.Drawing.Size(75, 23);
            this.buttonDShortcuts.TabIndex = 12;
            this.buttonDShortcuts.Text = "Details...";
            this.buttonDShortcuts.UseVisualStyleBackColor = true;
            // 
            // buttonDInternetZones
            // 
            this.buttonDInternetZones.Location = new System.Drawing.Point(197, 257);
            this.buttonDInternetZones.Name = "buttonDInternetZones";
            this.buttonDInternetZones.Size = new System.Drawing.Size(75, 23);
            this.buttonDInternetZones.TabIndex = 13;
            this.buttonDInternetZones.Text = "Details...";
            this.buttonDInternetZones.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(15, 297);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRun.Location = new System.Drawing.Point(183, 291);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(89, 32);
            this.buttonRun.TabIndex = 15;
            this.buttonRun.Text = "Run...";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Plugged In:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "On Battery:";
            // 
            // comboBoxTimeZone
            // 
            this.comboBoxTimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeZone.FormattingEnabled = true;
            this.comboBoxTimeZone.Location = new System.Drawing.Point(102, 89);
            this.comboBoxTimeZone.Name = "comboBoxTimeZone";
            this.comboBoxTimeZone.Size = new System.Drawing.Size(170, 21);
            this.comboBoxTimeZone.TabIndex = 18;
            this.comboBoxTimeZone.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimeZone_SelectedIndexChanged);
            // 
            // comboBoxPlugged
            // 
            this.comboBoxPlugged.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlugged.FormattingEnabled = true;
            this.comboBoxPlugged.Location = new System.Drawing.Point(6, 46);
            this.comboBoxPlugged.Name = "comboBoxPlugged";
            this.comboBoxPlugged.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPlugged.TabIndex = 20;
            this.comboBoxPlugged.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlugged_SelectedIndexChanged);
            // 
            // comboBoxBattery
            // 
            this.comboBoxBattery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBattery.FormattingEnabled = true;
            this.comboBoxBattery.Location = new System.Drawing.Point(142, 46);
            this.comboBoxBattery.Name = "comboBoxBattery";
            this.comboBoxBattery.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBattery.TabIndex = 21;
            this.comboBoxBattery.SelectedIndexChanged += new System.EventHandler(this.comboBoxBattery_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxPowerOptions);
            this.groupBox1.Controls.Add(this.comboBoxBattery);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxPlugged);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 72);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxTimeZone);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDInternetZones);
            this.Controls.Add(this.buttonDShortcuts);
            this.Controls.Add(this.buttonDManuals);
            this.Controls.Add(this.buttonDPinUnpin);
            this.Controls.Add(this.checkBoxInternetZones);
            this.Controls.Add(this.checkBoxShortcuts);
            this.Controls.Add(this.checkBoxManuals);
            this.Controls.Add(this.checkBoxPinUnpin);
            this.Controls.Add(this.checkBoxTimeZone);
            this.Controls.Add(this.checkBoxPrinter);
            this.Controls.Add(this.checkBoxAllUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPrinter);
            this.Name = "FormMain";
            this.Text = "Computer Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBoxPrinter;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox checkBoxAllUsers;
        public System.Windows.Forms.CheckBox checkBoxPrinter;
        public System.Windows.Forms.CheckBox checkBoxTimeZone;
        public System.Windows.Forms.CheckBox checkBoxPowerOptions;
        public System.Windows.Forms.CheckBox checkBoxPinUnpin;
        public System.Windows.Forms.CheckBox checkBoxManuals;
        public System.Windows.Forms.CheckBox checkBoxShortcuts;
        public System.Windows.Forms.CheckBox checkBoxInternetZones;
        public System.Windows.Forms.Button buttonDPinUnpin;
        public System.Windows.Forms.Button buttonDManuals;
        public System.Windows.Forms.Button buttonDShortcuts;
        public System.Windows.Forms.Button buttonDInternetZones;
        public System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.Button buttonRun;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxTimeZone;
        public System.Windows.Forms.ComboBox comboBoxPlugged;
        public System.Windows.Forms.ComboBox comboBoxBattery;
        public System.Windows.Forms.GroupBox groupBox1;
    }
}

