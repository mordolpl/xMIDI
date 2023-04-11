using Microsoft.CodeAnalysis.CSharp.Scripting;
using NAudio.Midi;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xMidi.Forms
{
    public partial class ActionIgniter : Form
    {
        public ActionIgniter()
        {
            InitializeComponent();
            conditionalDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Every (default)"));
            conditionalDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Specific"));
            conditionalDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Custom condition"));
        }

        private void conditionalDrop_SelectedItemChanged(object sender, EventArgs e)
        {
            if (conditionalDrop.SelectedItem.Text == "Every (default)")
            {
                specificNum.Enabled = false;
                conTxt.Enabled = false;
            }
            else if (conditionalDrop.SelectedItem.Text == "Specific")
            {
                specificNum.Enabled = true;
                conTxt.Enabled = false;
            }
            else if (conditionalDrop.SelectedItem.Text == "Custom condition")
            {
                specificNum.Enabled = false;
                conTxt.Enabled = true;
            }
        }

        private int returnValue(MidiEvent midiEvent)
        {
            int value = 0;
            switch (midiEvent.CommandCode)
            {
                case MidiCommandCode.NoteOff:
                    {
                        value = (midiEvent as NoteEvent).Velocity;
                        break;
                    }
                case MidiCommandCode.NoteOn:
                    {
                        value = (midiEvent as NoteEvent).Velocity;
                        break;
                    }
                case MidiCommandCode.KeyAfterTouch:
                    {
                        value = (midiEvent as NoteOnEvent).Velocity;
                        break;
                    }
                case MidiCommandCode.ControlChange:
                    {
                        value = (midiEvent as ControlChangeEvent).ControllerValue;
                        break;
                    }
                case MidiCommandCode.PatchChange:
                    {
                        value = (midiEvent as PatchChangeEvent).Patch;
                        break;
                    }
                case MidiCommandCode.ChannelAfterTouch:
                    {
                        value = (midiEvent as ChannelAfterTouchEvent).AfterTouchPressure;
                        break;
                    }
                case MidiCommandCode.PitchWheelChange:
                    {
                        value = (midiEvent as PitchWheelChangeEvent).Pitch;
                        break;
                    }
                default:
                    {
                        value = 0;
                        break;
                    }
            }
            return value;
        }
        private async Task<bool> ProcessExpression(string expression)
        {
            var processedExpression = expression.Replace("!8", "true");
            return await CSharpScript.EvaluateAsync<bool>(processedExpression);
        }

        public bool Condition(MidiEvent midiEvent)
        {
            if (conditionalDrop.SelectedItem.Text == "Every (default)")
            {
                return true;
            }
            else if (conditionalDrop.SelectedItem.Text == "Specific")
            {
                return (returnValue(midiEvent) == (int)specificNum.Value) ? true : false;
            }
            else if (conditionalDrop.SelectedItem.Text == "Custom condition")
            {
                try
                {
                    return ProcessExpression(MIDIButton.replaceAliases(conTxt.Text, midiEvent)).Result;
                }
                catch (Exception) { Program.arduinoMIDI.errorsCount++; }
            }
            return false;
        }
    }
}
