using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiArduinoTestingPlatform
{
    public partial class Form1 : Form
    {
        MidiIn midiIn;
        public Form1()
        {
            InitializeComponent();
            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                comboBoxMidiInDevices.Items.Add(MidiIn.DeviceInfo(device).ProductName);
            }
            if (comboBoxMidiInDevices.Items.Count > 0)
            {
                comboBoxMidiInDevices.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            midiIn = new MidiIn(comboBoxMidiInDevices.SelectedIndex);
            midiIn.MessageReceived += midiIn_MessageReceived;
            midiIn.ErrorReceived += midiIn_ErrorReceived;
            midiIn.Start();
        }

        private void midiIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate { label1.Text = e.MidiEvent.ToString(); });
            if (e.MidiEvent.CommandCode.Equals(MidiCommandCode.ControlChange))
            {
                this.Invoke((MethodInvoker)delegate { this.Width = 239 + (e.MidiEvent as ControlChangeEvent).ControllerValue * 2; });
            }
        }
    }
}
