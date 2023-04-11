using System.Windows.Forms;

namespace MidiArduino.Controls.Actions
{
    public partial class TemplatesAction : UserControl
    {
        public TemplatesAction(int index)
        {
            InitializeComponent();

            templatesDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("System master volume"));
            templatesDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Monitor brightness"));
            
            if((Program.arduinoMIDI.midiList.Controls[index] as MIDIButton).midiEvent.CommandCode != NAudio.Midi.MidiCommandCode.ControlChange)
            {
                infoTxt.Visible = true;
                templatesDrop.Enabled = false;
            }
        }
    }
}
