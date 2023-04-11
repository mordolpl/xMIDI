using NAudio.CoreAudioApi;
using NAudio.Midi;
using System.Threading;
using System.Windows.Forms;
using xMidi.Utils;

namespace xMidi.Controls.Actions
{
    public partial class TemplatesAction : UserControl
    {
        public TemplatesAction(int index)
        {
            InitializeComponent();

            if (((Program.arduinoMIDI.midiList.Controls[index] as MIDIButton).midiEvent.CommandCode == MidiCommandCode.NoteOn) ||
                ((Program.arduinoMIDI.midiList.Controls[index] as MIDIButton).midiEvent.CommandCode == MidiCommandCode.NoteOff))
            {
                templatesDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Skip to previous track"));
                templatesDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Play/Pause"));
                templatesDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Skip to next track"));
            }
            else if ((Program.arduinoMIDI.midiList.Controls[index] as MIDIButton).midiEvent.CommandCode == MidiCommandCode.ControlChange)
            {
                templatesDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("System master volume"));
                templatesDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Monitor brightness"));
            }
            else
            {
                infoTxt.Visible = true;
                templatesDrop.Enabled = false;
            }
        }
        public void useTemplate(MidiEvent e, MidiEvent en, bool async)
        {
            if (async) new Thread(() => { useTemplate(e, en); }).Start();
            else useTemplate(e, en);
        }
        public void useTemplate(MidiEvent e, MidiEvent en)
        {
            if ((en.CommandCode == MidiCommandCode.NoteOn) ||
                (en.CommandCode == MidiCommandCode.NoteOff) ||
                (en.CommandCode == MidiCommandCode.ControlChange))
                switch (templatesDrop.SelectedItem.Text)
                {
                    case "System master volume":
                        {
                            var enumerator = new MMDeviceEnumerator();
                            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
                            device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)(e as ControlChangeEvent).ControllerValue / 127;
                            break;
                        }
                    case "Monitor brightness":
                        {
                            using (BrightnessController brightnessController = new BrightnessController(Program.arduinoMIDI.Handle))
                            {
                                brightnessController.SetBrightness((int)((e as ControlChangeEvent).ControllerValue / 1.27));
                            }
                            break;
                        }
                    case "Skip to previous track":
                        {
                            WindowsPlayer.PreviousTrack();
                            break;
                        }
                    case "Play/Pause":
                        {
                            WindowsPlayer.PlayPause();
                            break;
                        }
                    case "Skip to next track":
                        {
                            WindowsPlayer.NextTrack();
                            break;
                        }
                }
        }
    }
}
