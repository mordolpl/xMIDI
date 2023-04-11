using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace xMidi.Controls.Actions
{
    public partial class MIDIFileAction : UserControl
    {
        public bool isStopped = false;
        public MIDIFileAction()
        {
            InitializeComponent();

            for (int i = 0; i < MidiOut.NumberOfDevices; i++)
            {
                midiOutDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem(MidiOut.DeviceInfo(i).ProductName));
            }
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

        public void sendMidiFile(MidiEvent e, bool async)
        {
            isStopped = false;
            if (async) new Thread(() => { CalculateMidiRealTimes(MIDIButton.replaceAliases(pathTxt.Text, e), false); }).Start();
            else CalculateMidiRealTimes(MIDIButton.replaceAliases(pathTxt.Text, e), false);
        }

        private void CalculateMidiRealTimes(string path, bool strict)
        {
            var strictMode = strict;
            var mf = new MidiFile(path, strictMode);
            mf.Events.MidiFileType = 0;

            List<MidiEvent> midiEvents = new List<MidiEvent>();

            for (int n = 0; n < mf.Tracks; n++)
            {
                foreach (var midiEvent in mf.Events[n])
                {
                    midiEvents.Add(midiEvent);
                }
            }

            List<decimal> eventsTimesArr = new List<decimal>();
            decimal lastRealTime = 0m;
            decimal lastAbsoluteTime = 0m;
            decimal currentMicroSecondsPerTick = 0m;

            MidiOut midiOut = new MidiOut(midiOutDrop.Items.IndexOf(midiOutDrop.SelectedItem));

            for (int i = 0; i < midiEvents.Count; i++)
            {
                MidiEvent midiEvent = midiEvents[i];
                TempoEvent tempoEvent = midiEvent as TempoEvent;

                if (midiEvent.AbsoluteTime > lastAbsoluteTime)
                {
                    lastRealTime += ((decimal)midiEvent.AbsoluteTime - lastAbsoluteTime) * currentMicroSecondsPerTick;
                }

                lastAbsoluteTime = midiEvent.AbsoluteTime;

                if (tempoEvent != null)
                {
                    currentMicroSecondsPerTick = (decimal)tempoEvent.MicrosecondsPerQuarterNote / (decimal)mf.DeltaTicksPerQuarterNote;
                    midiEvents.RemoveAt(i);
                    i--;
                    continue;
                }

                eventsTimesArr.Add(lastRealTime);

                if (isStopped) break;

                if (eventsTimesArr.Count > 1) Thread.Sleep((int)(lastRealTime / 1000m - eventsTimesArr[eventsTimesArr.Count - 2] / 1000m));
                else Thread.Sleep((int)(lastRealTime / 1000m));
                midiOut.Send(midiEvent.GetAsShortMessage());
            }

            midiOut.Dispose();
        }

        public void stopPlaying()
        {
            isStopped = true;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            stopPlaying();
        }
    }
}
