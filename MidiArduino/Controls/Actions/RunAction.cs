using NAudio.Midi;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace xMidi.Controls.Actions
{
    public partial class RunAction : UserControl
    {
        public RunAction()
        {
            InitializeComponent();
        }

        private void selectAppBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathTxt.Text = openFileDialog.FileName;
            }
        }

        private void unlockToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            pathTxt.ReadOnly = unlockToolStripMenuItem.Checked;
        }

        public void runApplication(MidiEvent e, bool async)
        {
            if (async) new Thread(() => { runApplication(e); }).Start();
            else runApplication(e);
        }

        public void runApplication(MidiEvent e)
        {
            var process = new ProcessStartInfo();
            process.FileName = MIDIButton.replaceAliases(pathTxt.Text, e);
            process.Arguments = MIDIButton.replaceAliases(argumentsTxt.Text, e);
            Process.Start(process);
        }
    }
}
