
namespace xMidi
{
    partial class xMIDI
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xMIDI));
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.midiList = new System.Windows.Forms.FlowLayoutPanel();
            this.addBtn = new DarkUI.Controls.DarkButton();
            this.startBtn = new DarkUI.Controls.DarkButton();
            this.settingsBtn = new DarkUI.Controls.DarkButton();
            this.midiDeviceReload = new System.Windows.Forms.Timer(this.components);
            this.notifyMidi = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new DarkUI.Controls.DarkContextMenu();
            this.showXMIDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midiInput = new DarkUI.Controls.DarkDropdownList();
            this.midiOutput = new DarkUI.Controls.DarkDropdownList();
            this.workTime = new System.Windows.Forms.Timer(this.components);
            this.inputSygnalDiode = new System.Windows.Forms.Panel();
            this.outputSygnalDiode = new System.Windows.Forms.Panel();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(12, 9);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(65, 13);
            this.darkLabel1.TabIndex = 6;
            this.darkLabel1.Text = "MIDI Input:";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(169, 9);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(75, 13);
            this.darkLabel2.TabIndex = 8;
            this.darkLabel2.Text = "MIDI Output:";
            // 
            // midiList
            // 
            this.midiList.AutoScroll = true;
            this.midiList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.midiList.Location = new System.Drawing.Point(15, 67);
            this.midiList.Name = "midiList";
            this.midiList.Padding = new System.Windows.Forms.Padding(1);
            this.midiList.Size = new System.Drawing.Size(299, 317);
            this.midiList.TabIndex = 2;
            this.midiList.WrapContents = false;
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(15, 409);
            this.addBtn.Name = "addBtn";
            this.addBtn.Padding = new System.Windows.Forms.Padding(5);
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Add";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(189, 409);
            this.startBtn.Name = "startBtn";
            this.startBtn.Padding = new System.Windows.Forms.Padding(5);
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 4;
            this.startBtn.Text = "Start";
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Image = global::xMidi.Properties.Resources.settings;
            this.settingsBtn.Location = new System.Drawing.Point(279, 403);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Padding = new System.Windows.Forms.Padding(5);
            this.settingsBtn.Size = new System.Drawing.Size(35, 35);
            this.settingsBtn.TabIndex = 5;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // midiDeviceReload
            // 
            this.midiDeviceReload.Enabled = true;
            this.midiDeviceReload.Interval = 3000;
            this.midiDeviceReload.Tick += new System.EventHandler(this.midiDeviceReload_Tick);
            // 
            // notifyMidi
            // 
            this.notifyMidi.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyMidi.BalloonTipText = "xMIDI is still working";
            this.notifyMidi.BalloonTipTitle = "xMIDI";
            this.notifyMidi.ContextMenuStrip = this.notifyMenu;
            this.notifyMidi.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyMidi.Icon")));
            this.notifyMidi.Text = "xMIDI";
            this.notifyMidi.Visible = true;
            this.notifyMidi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyMidi_MouseDoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.notifyMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showXMIDIToolStripMenuItem,
            this.showSettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.stopToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeApplicationToolStripMenuItem});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(181, 128);
            // 
            // showXMIDIToolStripMenuItem
            // 
            this.showXMIDIToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.showXMIDIToolStripMenuItem.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showXMIDIToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.showXMIDIToolStripMenuItem.Name = "showXMIDIToolStripMenuItem";
            this.showXMIDIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showXMIDIToolStripMenuItem.Text = "Show xMIDI";
            this.showXMIDIToolStripMenuItem.Click += new System.EventHandler(this.showArduinoMIDIToolStripMenuItem_Click);
            // 
            // showSettingsToolStripMenuItem
            // 
            this.showSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.showSettingsToolStripMenuItem.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.showSettingsToolStripMenuItem.Name = "showSettingsToolStripMenuItem";
            this.showSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showSettingsToolStripMenuItem.Text = "Show Settings";
            this.showSettingsToolStripMenuItem.Click += new System.EventHandler(this.showSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.stopToolStripMenuItem.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopToolStripMenuItem.Text = "Start";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // closeApplicationToolStripMenuItem
            // 
            this.closeApplicationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.closeApplicationToolStripMenuItem.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeApplicationToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.closeApplicationToolStripMenuItem.Name = "closeApplicationToolStripMenuItem";
            this.closeApplicationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeApplicationToolStripMenuItem.Text = "Close Application";
            this.closeApplicationToolStripMenuItem.Click += new System.EventHandler(this.closeApplicationToolStripMenuItem_Click);
            // 
            // midiInput
            // 
            this.midiInput.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.midiInput.Location = new System.Drawing.Point(15, 25);
            this.midiInput.Name = "midiInput";
            this.midiInput.Size = new System.Drawing.Size(142, 26);
            this.midiInput.TabIndex = 0;
            this.midiInput.Text = "darkDropdownList1";
            // 
            // midiOutput
            // 
            this.midiOutput.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.midiOutput.Location = new System.Drawing.Point(172, 25);
            this.midiOutput.Name = "midiOutput";
            this.midiOutput.Size = new System.Drawing.Size(142, 26);
            this.midiOutput.TabIndex = 1;
            this.midiOutput.Text = "darkDropdownList2";
            // 
            // workTime
            // 
            this.workTime.Enabled = true;
            this.workTime.Interval = 1000;
            this.workTime.Tick += new System.EventHandler(this.workTime_Tick);
            // 
            // inputSygnalDiode
            // 
            this.inputSygnalDiode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.inputSygnalDiode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputSygnalDiode.Location = new System.Drawing.Point(144, 9);
            this.inputSygnalDiode.Name = "inputSygnalDiode";
            this.inputSygnalDiode.Size = new System.Drawing.Size(13, 13);
            this.inputSygnalDiode.TabIndex = 7;
            this.inputSygnalDiode.Visible = false;
            // 
            // outputSygnalDiode
            // 
            this.outputSygnalDiode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.outputSygnalDiode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputSygnalDiode.Location = new System.Drawing.Point(301, 9);
            this.outputSygnalDiode.Name = "outputSygnalDiode";
            this.outputSygnalDiode.Size = new System.Drawing.Size(13, 13);
            this.outputSygnalDiode.TabIndex = 9;
            this.outputSygnalDiode.Visible = false;
            // 
            // xMIDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(326, 450);
            this.Controls.Add(this.outputSygnalDiode);
            this.Controls.Add(this.inputSygnalDiode);
            this.Controls.Add(this.midiOutput);
            this.Controls.Add(this.midiInput);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.midiList);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.settingsBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "xMIDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xMIDI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.xMIDI_FormClosing);
            this.Load += new System.EventHandler(this.xMIDI_Load);
            this.Shown += new System.EventHandler(this.xMIDI_Shown);
            this.Resize += new System.EventHandler(this.xMIDI_Resize);
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkButton settingsBtn;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkButton addBtn;
        private DarkUI.Controls.DarkButton startBtn;
        private System.Windows.Forms.Timer midiDeviceReload;
        private System.Windows.Forms.NotifyIcon notifyMidi;
        private DarkUI.Controls.DarkContextMenu notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem showXMIDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSettingsToolStripMenuItem;
        public System.Windows.Forms.FlowLayoutPanel midiList;
        public DarkUI.Controls.DarkDropdownList midiOutput;
        private System.Windows.Forms.Timer workTime;
        public DarkUI.Controls.DarkDropdownList midiInput;
        public System.Windows.Forms.Panel inputSygnalDiode;
        public System.Windows.Forms.Panel outputSygnalDiode;
    }
}

