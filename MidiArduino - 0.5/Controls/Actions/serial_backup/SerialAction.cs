using NAudio.Midi;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace MidiArduino.Controls.Actions
{
    public partial class SerialAction : UserControl
    {
        public SerialAction()
        {
            InitializeComponent();
            foreach (string port in SerialPort.GetPortNames())
            {
                serialPortDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem(port));
            }
        }

        public void serialData(MidiEvent e, bool async)
        {
            if (async) new Thread(() => { serialData(e); }).Start();
            else serialData(e);
        }

        public void serialData(MidiEvent e)
        {
            try
            {
                SerialPort port = new SerialPort(serialPortDrop.SelectedItem.Text, (int)baudRateNum.Value);
                if (!port.IsOpen) port.Open();
                if (port.IsOpen) port.Write(MIDIButton.replaceAliases(stringTxt.Text, e));
                if (port.IsOpen) port.Close();
                port.Dispose();
            }
            catch (System.UnauthorizedAccessException) { }
        }
    }
}
