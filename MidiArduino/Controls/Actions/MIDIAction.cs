using NAudio.Midi;
using System;
using System.Threading;
using System.Windows.Forms;

namespace xMidi.Controls.Actions
{
    public partial class MIDIAction : UserControl
    {
        public bool value = true;
        public MIDIAction()
        {
            InitializeComponent();

            for (int i = 0; i < MidiOut.NumberOfDevices; i++)
            {
                midiOutDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem(MidiOut.DeviceInfo(i).ProductName));
            }

            midiEventDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("NoteOn"));
            midiEventDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("NoteOff"));
            midiEventDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Polyphonic Aftertouch"));
            midiEventDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Control Change"));
            midiEventDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Program Change"));
            midiEventDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Channel Pressure"));
            midiEventDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Pitch Wheel Change"));
        }

        private void switchBtn_Click(object sender, EventArgs e)
        {
            if (value)
            {
                valueTxt.Enabled = true;
                valueNum.Enabled = false;
                switchBtn.Text = "->";
                value = !value;
            }
            else
            {
                valueTxt.Enabled = false;
                valueNum.Enabled = true;
                switchBtn.Text = "<-";
                value = !value;
            }
        }

        public void sendMidi(MidiEvent e, bool async)
        {
            if (async) new Thread(() => { sendMidi(e); }).Start();
            else sendMidi(e);
        }

        public void sendMidi(MidiEvent e)
        {
            try
            {
                MidiEvent midiEvent = null;
                int finalValue = value ? (int)valueNum.Value : Convert.ToInt32(MIDIButton.replaceAliases(valueTxt.Text, e));

                switch (midiEventDrop.SelectedItem.Text)
                {
                    case "NoteOn":
                        {
                            midiEvent = new NoteEvent(0, (int)channelNum.Value, MidiCommandCode.NoteOn, (int)nameValue.Value, finalValue);
                            break;
                        }
                    case "NoteOff":
                        {
                            midiEvent = new NoteEvent(0, (int)channelNum.Value, MidiCommandCode.NoteOff, (int)nameValue.Value, finalValue);
                            break;
                        }
                    case "Control Change":
                        {
                            midiEvent = new ControlChangeEvent(0, (int)channelNum.Value, (MidiController)nameValue.Value, finalValue);
                            break;
                        }
                    case "Program Change":
                        {
                            midiEvent = new PatchChangeEvent(0, (int)channelNum.Value, finalValue);
                            break;
                        }
                    case "Channel Pressure":
                        {
                            midiEvent = new ChannelAfterTouchEvent(0, (int)channelNum.Value, finalValue);
                            break;
                        }
                    case "Pitch Wheel Change":
                        {
                            midiEvent = new PitchWheelChangeEvent(0, (int)channelNum.Value, finalValue);
                            break;
                        }
                }


                MidiOut midiOut = new MidiOut(midiOutDrop.Items.IndexOf(midiOutDrop.SelectedItem));
                midiOut.Send(midiEvent.GetAsShortMessage());
                midiOut.Dispose();
            }
            catch (Exception) { Program.arduinoMIDI.errorsCount++; }
        }

        public void setButton()
        {
            if (!value)
            {
                valueTxt.Enabled = true;
                valueNum.Enabled = false;
                switchBtn.Text = "->";
            }
            else
            {
                valueTxt.Enabled = false;
                valueNum.Enabled = true;
                switchBtn.Text = "<-";
            }
        }
    }
}
