using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MidiArduino
{
    public partial class ArduinoMIDI : Form
    {
        public MidiIn midiIn;
        public MidiOut midiOut;
        public MidiEvent midiEvent;

        private DarkUI.Controls.DarkScrollBar darkScrollBar;
        public List<string> storage = new List<string>();
        public bool isStarted = false;
        private int midiInCount;
        private int midiOutCount;

        public int errorsCount = 0;
        private int intervalCount = 0;

        #region functions
        private void loadMidiDevices()
        {
            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                midiInput.Items.Add(new DarkUI.Controls.DarkDropdownItem(MidiIn.DeviceInfo(device).ProductName));
            }
            if (midiInput.Items.Count > 0)
            {
                midiInput.SelectedItem = midiInput.Items[0];
            }
            for (int device = 0; device < MidiOut.NumberOfDevices; device++)
            {
                midiOutput.Items.Add(new DarkUI.Controls.DarkDropdownItem(MidiOut.DeviceInfo(device).ProductName));
            }

            midiInCount = MidiIn.NumberOfDevices;
            midiOutCount = MidiOut.NumberOfDevices;
        }

        private void loadDarkScrollBar()
        {
            darkScrollBar = new DarkUI.Controls.DarkScrollBar();
            darkScrollBar.Name = "darkScrollBar";
            darkScrollBar.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Vertical;
            darkScrollBar.Size = new System.Drawing.Size(midiList.Width, midiList.Height);
            darkScrollBar.Height = midiList.Height;
            darkScrollBar.Location = new Point(midiList.Location.X + 279, midiList.Location.Y);
            darkScrollBar.Enabled = true;
            darkScrollBar.Visible = true;
            darkScrollBar.Minimum = midiList.VerticalScroll.Minimum;
            darkScrollBar.Maximum = (46) * midiList.Controls.Count - midiList.Height;
            if (darkScrollBar.Maximum < 0) darkScrollBar.Maximum = 0;
            darkScrollBar.ValueChanged += (s, e) => { midiList.VerticalScroll.Value = e.Value; };

            midiList.AutoScroll = true;
            midiList.VerticalScroll.Visible = false;
            midiList.MouseWheel += (s, e) => { darkScrollBar.Value = midiList.VerticalScroll.Value; darkScrollBar.UpdateScrollBar(); };
            this.Controls.Add(darkScrollBar);
            darkScrollBar.BringToFront();
        }

        private void updateDarkScrollBar()
        {
            darkScrollBar.Maximum = (46) * midiList.Controls.Count - midiList.Height;
            if (darkScrollBar.Maximum < 0) darkScrollBar.Maximum = 0;
        }

        private void start()
        {
            try
            {
                if (!isStarted)
                {
                    if (midiInput.Items.Count <= 0) { MessageBox.Show("Select input device!", "Arduino MIDI", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    if (Properties.Settings.Default.outputEnable) if (midiOutput.SelectedItem == null) { MessageBox.Show("Select output device!", "Arduino MIDI", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                    midiIn = new MidiIn(midiInput.Items.IndexOf(midiInput.SelectedItem));
                    midiIn.MessageReceived += midiIn_MessageReceived;
                    midiIn.ErrorReceived += midiIn_ErrorReceived;
                    midiIn.Start();

                    if (Properties.Settings.Default.outputEnable) midiOut = new MidiOut(midiOutput.Items.IndexOf(midiOutput.SelectedItem));
                    startBtn.Text = "Stop";
                    stopToolStripMenuItem.Text = "Stop";
                    isStarted = true;
                    midiInput.Enabled = false;
                    midiOutput.Enabled = false;

                    if (midiList.Controls.Count > 0)
                        foreach (var button in midiList.Controls)
                            (button as MIDIButton).UpdateMidi();

                    workTime.Start();
                }
                else
                {
                    midiIn.Stop();
                    midiIn.Dispose();

                    if (Properties.Settings.Default.outputEnable) midiOut.Dispose();
                    startBtn.Text = "Start";
                    stopToolStripMenuItem.Text = "Start";
                    isStarted = false;
                    midiInput.Enabled = true;
                    if(Properties.Settings.Default.outputEnable) midiOutput.Enabled = true;

                    workTime.Stop();
                    StopForm stopForm = new StopForm(errorsCount, ConvertSecondsToDate(intervalCount));
                    stopForm.ShowDialog();
                    intervalCount = 0;
                    errorsCount = 0;
                }
            }
            catch (NAudio.MmException)
            {
                MessageBox.Show("The device was probably disconnected!\nWe recommend to restart the application.", "Arduino MIDI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ConvertSecondsToDate(int seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(seconds));

            if (t.Days > 0)
                return t.ToString(@"d'd, 'hh\:mm\:ss");
            return t.ToString(@"hh\:mm\:ss");

        }

        private void loadConfig()
        {
            midiOutput.Enabled = Properties.Settings.Default.outputEnable;
            inputSygnalDiode.Visible = outputSygnalDiode.Visible = Properties.Settings.Default.midiIOIneraction;

            if (Properties.Settings.Default.configAutoload && !string.IsNullOrEmpty(Properties.Settings.Default.configPath))
            {
                if (System.IO.File.Exists(Properties.Settings.Default.configPath))
                {
                    Settings.loadConfig(Properties.Settings.Default.configPath);
                }
            }

            if (Properties.Settings.Default.autoStart)
            {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.midiInput))
                {
                    foreach(var device in midiInput.Items)
                    {
                        if (device.Text == Properties.Settings.Default.midiInput) midiInput.SelectedItem = device;
                    }
                }
                if (!string.IsNullOrEmpty(Properties.Settings.Default.midiOutput) && Properties.Settings.Default.outputEnable)
                {
                    foreach (var device in midiOutput.Items)
                    {
                        if (device.Text == Properties.Settings.Default.midiOutput) midiOutput.SelectedItem = device;
                    }
                }

                start();
            }
        }

        public void updateBindsIndexes()
        {
            for(int i = 0; i < midiList.Controls.Count; i++)
            {
                (midiList.Controls[i] as MIDIButton).UpdateIndex(i);
            }
        }

        #endregion

        #region buttosEvents
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (midiInput.SelectedItem == null || !isStarted) { MessageBox.Show("You should select midi device and start first!", "Arduino MIDI", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            ButtonSelector b = new ButtonSelector();
            b.ShowDialog();
            b.Dispose();
            if (this.midiEvent != null)
            {
                midiList.Controls.Add(new MIDIButton(this.midiEvent, midiList.Controls.Count));
                updateDarkScrollBar();
            }
            this.midiEvent = null;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            start();
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            SettingsForm s = new SettingsForm();
            s.ShowDialog();
            s.Dispose();
        }

        #endregion

        #region midiEvents
        private void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            if (isStarted)
            {
                if (Properties.Settings.Default.outputEnable)
                {
                    midiOut.Send(e.MidiEvent.GetAsShortMessage());
                }

                if (Properties.Settings.Default.midiIOIneraction)
                    new System.Threading.Thread(() =>
                    {
                        this.Invoke((MethodInvoker)delegate {
                            inputSygnalDiode.BackColor = Color.Green;
                        });
                        System.Threading.Thread.Sleep(20);
                        this.Invoke((MethodInvoker)delegate {
                            inputSygnalDiode.BackColor = Color.FromArgb(255, 60, 63, 65);
                        });
                    }).Start();
            }
        }

        private void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            errorsCount++;
        }

        #endregion

        #region formEvents
        public ArduinoMIDI()
        {
            InitializeComponent();
        }

        private void ArduinoMIDI_Load(object sender, EventArgs e)
        {
            loadMidiDevices();
            loadDarkScrollBar();
            midiDeviceReload.Start();
            loadConfig();
        }

        private void ArduinoMIDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Settings

            if (Properties.Settings.Default.runStartup)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
                key.SetValue("Arduino MIDI", "\"" + Application.ExecutablePath + "\" autostart");
            }
            else
            {
                try
                {
                    Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                        "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
                    key.DeleteValue("Arduino MIDI");
                }
                catch (System.ArgumentException er)
                {
                    Console.WriteLine(er.Message);
                }
            }

            if (Properties.Settings.Default.autoStart)
            {
                Properties.Settings.Default.midiInput = midiInput.SelectedItem.Text;
                if(Properties.Settings.Default.outputEnable) Properties.Settings.Default.midiOutput = midiOutput.SelectedItem.Text;
                Properties.Settings.Default.Save();
            }
            #endregion

            midiDeviceReload.Stop();
            if (midiIn == null || !isStarted) return;
            midiIn.Stop();
            midiIn.Dispose();
        }

        private void ArduinoMIDI_Resize(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.hideMinimalize && this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyMidi.ShowBalloonTip(3000);
            }
        }

        private void ArduinoMIDI_Shown(object sender, EventArgs e)
        {
            if (Program.isStartup && Properties.Settings.Default.minOnStartup)
            {
                this.WindowState = FormWindowState.Minimized;
                Program.isStartup = false;
            }
        }

        private void midiDeviceReload_Tick(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                if(midiInCount != MidiIn.NumberOfDevices)
                {
                    midiInput.Items.Clear();

                    for (int device = 0; device < MidiIn.NumberOfDevices; device++)
                    {
                        midiInput.Items.Add(new DarkUI.Controls.DarkDropdownItem(MidiIn.DeviceInfo(device).ProductName));
                    }

                    midiInCount = MidiIn.NumberOfDevices;
                }
                
                if(midiOutCount != MidiOut.NumberOfDevices)
                {
                    midiOutput.Items.Clear();

                    for (int device = 0; device < MidiOut.NumberOfDevices; device++)
                    {
                        midiOutput.Items.Add(new DarkUI.Controls.DarkDropdownItem(MidiOut.DeviceInfo(device).ProductName));
                    }

                    midiOutCount = MidiOut.NumberOfDevices;
                }
            }
        }


        private void workTime_Tick(object sender, EventArgs e)
        {
            intervalCount++;
        }

        #endregion

        #region notify

        private void notifyMidi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void showArduinoMIDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void showSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm s = new SettingsForm();
            s.ShowDialog();
            s.Dispose();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start();
        }

        private void closeApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion
    }
}
