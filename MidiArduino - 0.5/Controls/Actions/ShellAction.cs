using NAudio.Midi;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MidiArduino.Controls.Actions
{
    public partial class ShellAction : UserControl
    {
        public ShellAction()
        {
            InitializeComponent();
        }

        public void sendShell(MidiEvent e, bool async)
        {
            if (async) new Thread(() => { sendShell(e); }).Start();
            else sendShell(e);
        }
        public void sendShell(MidiEvent e)
        {
            var process = new ProcessStartInfo();
            process.FileName = "cmd.exe";
            process.Arguments = "/c " + MIDIButton.replaceAliases(stringTxt.Text, e);
            process.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(process);
        }
    }
}
