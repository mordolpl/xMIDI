
namespace MidiArduino
{
    partial class SettingsForm
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
            pictureBox1.Image.Dispose();
            pictureBox1.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.darkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.runStartupCheck = new DarkUI.Controls.DarkCheckBox();
            this.hideMinimalizeCheck = new DarkUI.Controls.DarkCheckBox();
            this.outputEnableCheck = new DarkUI.Controls.DarkCheckBox();
            this.autoStartCheck = new DarkUI.Controls.DarkCheckBox();
            this.midiInteractionCheck = new DarkUI.Controls.DarkCheckBox();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.darkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.configAutoloadCheck = new DarkUI.Controls.DarkCheckBox();
            this.autoConfigBtn = new DarkUI.Controls.DarkButton();
            this.configPathTxtBox = new DarkUI.Controls.DarkTextBox();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.saveConfigBtn = new DarkUI.Controls.DarkButton();
            this.loadConfigBtn = new DarkUI.Controls.DarkButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.saveBtn = new DarkUI.Controls.DarkButton();
            this.discardBtn = new DarkUI.Controls.DarkButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.darkGroupBox1.SuspendLayout();
            this.darkGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // darkGroupBox1
            // 
            this.darkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.darkGroupBox1.Controls.Add(this.runStartupCheck);
            this.darkGroupBox1.Controls.Add(this.hideMinimalizeCheck);
            this.darkGroupBox1.Controls.Add(this.outputEnableCheck);
            this.darkGroupBox1.Controls.Add(this.autoStartCheck);
            this.darkGroupBox1.Controls.Add(this.midiInteractionCheck);
            this.darkGroupBox1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.darkGroupBox1.Name = "darkGroupBox1";
            this.darkGroupBox1.Size = new System.Drawing.Size(196, 166);
            this.darkGroupBox1.TabIndex = 0;
            this.darkGroupBox1.TabStop = false;
            this.darkGroupBox1.Text = "Primary";
            // 
            // runStartupCheck
            // 
            this.runStartupCheck.AutoSize = true;
            this.runStartupCheck.Location = new System.Drawing.Point(16, 131);
            this.runStartupCheck.Name = "runStartupCheck";
            this.runStartupCheck.Size = new System.Drawing.Size(144, 19);
            this.runStartupCheck.TabIndex = 4;
            this.runStartupCheck.Text = "Run on system startup";
            this.runStartupCheck.CheckedChanged += new System.EventHandler(this.runStartupCheck_CheckedChanged);
            // 
            // hideMinimalizeCheck
            // 
            this.hideMinimalizeCheck.AutoSize = true;
            this.hideMinimalizeCheck.Location = new System.Drawing.Point(16, 106);
            this.hideMinimalizeCheck.Name = "hideMinimalizeCheck";
            this.hideMinimalizeCheck.Size = new System.Drawing.Size(129, 19);
            this.hideMinimalizeCheck.TabIndex = 3;
            this.hideMinimalizeCheck.Text = "Hide on minimalize";
            this.hideMinimalizeCheck.CheckedChanged += new System.EventHandler(this.hideCloseCheck_CheckedChanged);
            // 
            // outputEnableCheck
            // 
            this.outputEnableCheck.AutoSize = true;
            this.outputEnableCheck.Location = new System.Drawing.Point(16, 31);
            this.outputEnableCheck.Name = "outputEnableCheck";
            this.outputEnableCheck.Size = new System.Drawing.Size(128, 19);
            this.outputEnableCheck.TabIndex = 0;
            this.outputEnableCheck.Text = "Enable MIDI output";
            this.outputEnableCheck.CheckedChanged += new System.EventHandler(this.outputEnableCheck_CheckedChanged);
            // 
            // autoStartCheck
            // 
            this.autoStartCheck.AutoSize = true;
            this.autoStartCheck.Location = new System.Drawing.Point(16, 56);
            this.autoStartCheck.Name = "autoStartCheck";
            this.autoStartCheck.Size = new System.Drawing.Size(166, 19);
            this.autoStartCheck.TabIndex = 1;
            this.autoStartCheck.Text = "Autostart and save devices";
            this.autoStartCheck.CheckedChanged += new System.EventHandler(this.autoStartCheck_CheckedChanged);
            // 
            // midiInteractionCheck
            // 
            this.midiInteractionCheck.AutoSize = true;
            this.midiInteractionCheck.Location = new System.Drawing.Point(16, 81);
            this.midiInteractionCheck.Name = "midiInteractionCheck";
            this.midiInteractionCheck.Size = new System.Drawing.Size(160, 19);
            this.midiInteractionCheck.TabIndex = 2;
            this.midiInteractionCheck.Text = "Show MIDI-IO Interaction";
            this.midiInteractionCheck.CheckedChanged += new System.EventHandler(this.mainTopCheck_CheckedChanged);
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 0);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(425, 2);
            this.darkSeparator1.TabIndex = 1;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // darkGroupBox2
            // 
            this.darkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.darkGroupBox2.Controls.Add(this.configAutoloadCheck);
            this.darkGroupBox2.Controls.Add(this.autoConfigBtn);
            this.darkGroupBox2.Controls.Add(this.configPathTxtBox);
            this.darkGroupBox2.Controls.Add(this.darkLabel2);
            this.darkGroupBox2.Controls.Add(this.saveConfigBtn);
            this.darkGroupBox2.Controls.Add(this.loadConfigBtn);
            this.darkGroupBox2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkGroupBox2.Location = new System.Drawing.Point(214, 12);
            this.darkGroupBox2.Name = "darkGroupBox2";
            this.darkGroupBox2.Size = new System.Drawing.Size(196, 166);
            this.darkGroupBox2.TabIndex = 4;
            this.darkGroupBox2.TabStop = false;
            this.darkGroupBox2.Text = "Configs";
            // 
            // configAutoloadCheck
            // 
            this.configAutoloadCheck.AutoSize = true;
            this.configAutoloadCheck.Location = new System.Drawing.Point(21, 81);
            this.configAutoloadCheck.Name = "configAutoloadCheck";
            this.configAutoloadCheck.Size = new System.Drawing.Size(112, 19);
            this.configAutoloadCheck.TabIndex = 7;
            this.configAutoloadCheck.Text = "Config autoload";
            this.configAutoloadCheck.CheckedChanged += new System.EventHandler(this.configAutoloadCheck_CheckedChanged);
            // 
            // autoConfigBtn
            // 
            this.autoConfigBtn.Location = new System.Drawing.Point(154, 127);
            this.autoConfigBtn.Name = "autoConfigBtn";
            this.autoConfigBtn.Padding = new System.Windows.Forms.Padding(5);
            this.autoConfigBtn.Size = new System.Drawing.Size(23, 23);
            this.autoConfigBtn.TabIndex = 9;
            this.autoConfigBtn.Text = "...";
            this.autoConfigBtn.Click += new System.EventHandler(this.autoConfigBtn_Click);
            // 
            // configPathTxtBox
            // 
            this.configPathTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.configPathTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.configPathTxtBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.configPathTxtBox.Location = new System.Drawing.Point(21, 127);
            this.configPathTxtBox.Name = "configPathTxtBox";
            this.configPathTxtBox.ReadOnly = true;
            this.configPathTxtBox.Size = new System.Drawing.Size(127, 23);
            this.configPathTxtBox.TabIndex = 8;
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(18, 106);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(96, 15);
            this.darkLabel2.TabIndex = 6;
            this.darkLabel2.Text = "Autoload config:";
            // 
            // saveConfigBtn
            // 
            this.saveConfigBtn.Location = new System.Drawing.Point(102, 31);
            this.saveConfigBtn.Name = "saveConfigBtn";
            this.saveConfigBtn.Padding = new System.Windows.Forms.Padding(5);
            this.saveConfigBtn.Size = new System.Drawing.Size(75, 23);
            this.saveConfigBtn.TabIndex = 6;
            this.saveConfigBtn.Text = "Save";
            this.saveConfigBtn.Click += new System.EventHandler(this.saveConfigBtn_Click);
            // 
            // loadConfigBtn
            // 
            this.loadConfigBtn.Location = new System.Drawing.Point(21, 31);
            this.loadConfigBtn.Name = "loadConfigBtn";
            this.loadConfigBtn.Padding = new System.Windows.Forms.Padding(5);
            this.loadConfigBtn.Size = new System.Drawing.Size(75, 23);
            this.loadConfigBtn.TabIndex = 5;
            this.loadConfigBtn.Text = "Load...";
            this.loadConfigBtn.Click += new System.EventHandler(this.loadConfigBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 184);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // darkLabel1
            // 
            this.darkLabel1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(58, 184);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(150, 40);
            this.darkLabel1.TabIndex = 6;
            this.darkLabel1.Text = "BigfootStudios©2023\r\nArduino MIDI v.0.5";
            this.darkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(338, 193);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Padding = new System.Windows.Forms.Padding(5);
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // discardBtn
            // 
            this.discardBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discardBtn.Location = new System.Drawing.Point(257, 193);
            this.discardBtn.Name = "discardBtn";
            this.discardBtn.Padding = new System.Windows.Forms.Padding(5);
            this.discardBtn.Size = new System.Drawing.Size(75, 23);
            this.discardBtn.TabIndex = 10;
            this.discardBtn.Text = "Discard";
            this.discardBtn.Click += new System.EventHandler(this.discardBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "ArduinoMIDIConfig";
            this.openFileDialog.Filter = "Json files (*.json)|*.json";
            this.openFileDialog.Title = "Arduino MIDI";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "ArduinoMIDIConfig";
            this.saveFileDialog.Filter = "Json files (*.json)|*.json";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(425, 229);
            this.Controls.Add(this.discardBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.darkGroupBox2);
            this.Controls.Add(this.darkSeparator1);
            this.Controls.Add(this.darkGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ardunio MIDI - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.darkGroupBox1.ResumeLayout(false);
            this.darkGroupBox1.PerformLayout();
            this.darkGroupBox2.ResumeLayout(false);
            this.darkGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkGroupBox darkGroupBox1;
        private DarkUI.Controls.DarkCheckBox midiInteractionCheck;
        private DarkUI.Controls.DarkCheckBox autoStartCheck;
        private DarkUI.Controls.DarkCheckBox outputEnableCheck;
        private DarkUI.Controls.DarkCheckBox hideMinimalizeCheck;
        private DarkUI.Controls.DarkCheckBox runStartupCheck;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Controls.DarkGroupBox darkGroupBox2;
        private DarkUI.Controls.DarkButton saveConfigBtn;
        private DarkUI.Controls.DarkButton loadConfigBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkButton saveBtn;
        private DarkUI.Controls.DarkButton discardBtn;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private DarkUI.Controls.DarkButton autoConfigBtn;
        private DarkUI.Controls.DarkTextBox configPathTxtBox;
        private DarkUI.Controls.DarkCheckBox configAutoloadCheck;
    }
}