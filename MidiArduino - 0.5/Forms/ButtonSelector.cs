using NAudio.Midi;
using System;
using System.Windows.Forms;

namespace MidiArduino
{
    public partial class ButtonSelector : Form
    {
        private MidiEvent midiEvent;
        public ButtonSelector()
        {
            InitializeComponent();
            Program.arduinoMIDI.midiIn.MessageReceived += MidiIn_MessageReceived;
            showMoreDataToolStripMenuItem.Checked = Program.arduinoMIDI.selectorData;
            moreDataText.Visible = showMoreDataToolStripMenuItem.Checked;
        }

        private void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            string message = "";
            switch (e.MidiEvent.CommandCode)
            {
                case MidiCommandCode.NoteOff:
                    {
                        message = e.MidiEvent.CommandCode + " " + (e.MidiEvent as NoteEvent).NoteName;
                        break;
                    }
                case MidiCommandCode.NoteOn:
                    {
                        message = e.MidiEvent.CommandCode + " " + (e.MidiEvent as NoteEvent).NoteName;
                        break;
                    }
                case MidiCommandCode.KeyAfterTouch:
                    {
                        message = e.MidiEvent.CommandCode + " " + (e.MidiEvent as NoteOnEvent).NoteName;
                        break;
                    }
                case MidiCommandCode.ControlChange:
                    {
                        message = e.MidiEvent.CommandCode + " " + (e.MidiEvent as ControlChangeEvent).Controller.ToString();
                        break;
                    }
                case MidiCommandCode.PatchChange:
                    {
                        message = (e.MidiEvent as PatchChangeEvent).ToString();
                        break;
                    }
                case MidiCommandCode.ChannelAfterTouch:
                    {
                        message = (e.MidiEvent as ChannelAfterTouchEvent).ToString();
                        break;
                    }
                case MidiCommandCode.PitchWheelChange:
                    {
                        message = (e.MidiEvent as PitchWheelChangeEvent).ToString();
                        break;
                    }
            }

            UpdateLabel(message);
            this.midiEvent = e.MidiEvent;
        }

        private void UpdateLabel(string text)
        {
            if (this.midiButton.InvokeRequired)
            {
                this.midiButton.BeginInvoke((MethodInvoker)delegate () { 
                    this.midiButton.Text = text;
                    if (moreDataText.Visible) this.moreDataText.Text = String.Format("{0}", midiEvent.ToString());
                });
            }
            else
            {
                this.midiButton.Text = text;
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Program.arduinoMIDI.midiEvent = this.midiEvent;
            this.Close();
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showMoreDataToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Program.arduinoMIDI.selectorData = showMoreDataToolStripMenuItem.Checked;
            moreDataText.Visible = showMoreDataToolStripMenuItem.Checked;
        }
    }
}
