using Microsoft.CodeAnalysis.CSharp.Scripting;
using MidiArduino.Controls.Actions;
using MidiArduino.Forms;
using MidiArduino.Utils;
using NAudio.CoreAudioApi;
using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiArduino
{
    public partial class MIDIButton : UserControl
    {
        public ActionManager actionManager;
        public MidiEvent midiEvent;
        public MIDIButton(MidiEvent midiEvent, int index)
        {
            InitializeComponent();
            this.midiEvent = midiEvent;
            if(midiEvent != null) buttonCode.Text = returnName(midiEvent);
            actionManager = new ActionManager(index);
            if(Program.arduinoMIDI.midiIn != null) Program.arduinoMIDI.midiIn.MessageReceived += MidiIn_MessageReceived;
            if (Program.arduinoMIDI.midiIn != null) Program.arduinoMIDI.midiIn.ErrorReceived += MidiIn_ErrorReceived;
        }

        #region hoverEffect

        private void buttonCode_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 58, 61, 66);
            buttonCode.BackColor = Color.FromArgb(255, 58, 61, 66);
        }

        private void buttonCode_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 58, 61, 66);
            buttonCode.BackColor = Color.FromArgb(255, 58, 61, 66);
        }

        private void buttonCode_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 50, 53, 55);
            buttonCode.BackColor = Color.FromArgb(255, 50, 53, 55);
        }

        #endregion

        #region buttonEvents

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to remove this button configuration?", "Arduino MIDI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.arduinoMIDI.midiList.Controls.Remove(this);
                Program.arduinoMIDI.updateBindsIndexes();
                Program.arduinoMIDI.midiIn.MessageReceived -= this.MidiIn_MessageReceived;
                Program.arduinoMIDI.midiIn.ErrorReceived -= this.MidiIn_ErrorReceived;
                this.Dispose();
            }
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            actionManager.ShowDialog();
        }

        #endregion

        #region Events
        private void buttonCode_DoubleClick(object sender, EventArgs e)
        {
            actionManager.ShowDialog();
        }

        #endregion

        #region actionLoop

        private void MidiIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            Program.arduinoMIDI.errorsCount++;
        }

        private void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            /*Thread thread = new Thread(() => actionsLoop(e));
            thread.Start();*/
            actionsLoop(e);
        }

        private void actionsLoop(MidiInMessageEventArgs e)
        {
            string event1 = returnName(midiEvent);
            string event2 = returnName(e.MidiEvent);
            if (Program.arduinoMIDI.isStarted && this.buttonActiveCheck.Checked && midiEvent.Channel == e.MidiEvent.Channel && event1 == event2)
            {
                if (showIneractionBool)
                    new Thread(() =>
                    {
                        this.Invoke((MethodInvoker)delegate {
                            buttonCode.BackColor = Color.LightGreen;
                            this.BackColor = Color.LightGreen;
                        });
                        Thread.Sleep(20);
                        this.Invoke((MethodInvoker)delegate {
                            buttonCode.BackColor = Color.FromArgb(255, 50, 53, 55);
                            this.BackColor = Color.FromArgb(255, 50, 53, 55);
                        });
                    }).Start();

                for (int i = 0; i < actionManager.actionList.Items.Count; i++)
                {
                    try
                    {
                        if (actionManager.actionControls[i].actionIgniter.Condition(e.MidiEvent))
                        {
                            if ((int)actionManager.actionControls[i].delayNum.Value > 0)
                                Thread.Sleep((int)actionManager.actionControls[i].delayNum.Value);

                            switch (actionManager.actionControls[i].actionCombo.SelectedIndex)
                            {
                                case 0:
                                    {
                                        string sendKey = "";
                                        string[] modif = (actionManager.actionControls[i].actionType.Controls[0] as KeyShortcutAction).Modifiers.Split(',');
                                        for (int j = 0; j < modif.Length; j++)
                                        {
                                            sendKey += modif[j].Trim().Replace("Shift", "+").Replace("Control", "^").Replace("Alt", "%") + "(";
                                        }
                                        sendKey += "{" + (actionManager.actionControls[i].actionType.Controls[0] as KeyShortcutAction).KeyCode + "}";
                                        for (int j = 0; j < modif.Length; j++)
                                            sendKey += ")";

                                        SendKeys.Send(sendKey);
                                        break;
                                    }
                                case 1:
                                    {
                                        var process = new ProcessStartInfo();
                                        process.FileName = (actionManager.actionControls[i].actionType.Controls[0] as RunAction).pathTxt.Text;
                                        process.Arguments = replaceAliases(this, (actionManager.actionControls[i].actionType.Controls[0] as RunAction).argumentsTxt.Text, e.MidiEvent);
                                        Process.Start(process);
                                        break;
                                    }
                                case 2:
                                    {
                                        var process = new ProcessStartInfo();
                                        process.FileName = "cmd.exe";
                                        process.Arguments = "/c " + replaceAliases(this, (actionManager.actionControls[i].actionType.Controls[0] as ShellAction).stringTxt.Text, e.MidiEvent);
                                        process.WindowStyle = ProcessWindowStyle.Hidden;
                                        Process.Start(process);
                                        break;
                                    }
                                case 3:
                                    {
                                        try
                                        {
                                            SerialPort port = new SerialPort((actionManager.actionControls[i].actionType.Controls[0] as SerialAction).serialPortDrop.SelectedItem.Text,
                                                (int)(actionManager.actionControls[i].actionType.Controls[0] as SerialAction).baudRateNum.Value);
                                            if (!port.IsOpen) port.Open();
                                            if (port.IsOpen) port.Write(replaceAliases(this, (actionManager.actionControls[i].actionType.Controls[0] as SerialAction).stringTxt.Text, e.MidiEvent));
                                            if (port.IsOpen) port.Close();
                                            port.Dispose();
                                        }
                                        catch (System.UnauthorizedAccessException) { }
                                        break;
                                    }
                                case 4:
                                    {
                                        (actionManager.actionControls[i].actionType.Controls[0] as MIDIAction).SendMidi(e.MidiEvent);
                                        break;
                                    }
                                case 5:
                                    {
                                        if (midiEvent.CommandCode != MidiCommandCode.ControlChange) break;
                                        switch ((actionManager.actionControls[i].actionType.Controls[0] as TemplatesAction).templatesDrop.SelectedItem.Text)
                                        {
                                            case "System master volume":
                                                {
                                                    var enumerator = new MMDeviceEnumerator();
                                                    var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
                                                    device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)(e.MidiEvent as ControlChangeEvent).ControllerValue / 127;
                                                    break;
                                                }
                                            case "Monitor brightness":
                                                {
                                                    using (BrightnessController brightnessController = new BrightnessController(Program.arduinoMIDI.Handle))
                                                    {
                                                        brightnessController.SetBrightness((int)((e.MidiEvent as ControlChangeEvent).ControllerValue / 1.27));
                                                    }
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke((MethodInvoker)delegate { UpdateErrors(); });
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        #endregion

        #region functions

        public static string replaceAliases(Control control, string text, MidiEvent e)
        {
            int value = 0;
            switch (e.CommandCode)
            {
                case MidiCommandCode.NoteOff:
                    {
                        value = (e as NoteEvent).Velocity;
                        break;
                    }
                case MidiCommandCode.NoteOn:
                    {
                        value = (e as NoteEvent).Velocity;
                        break;
                    }
                case MidiCommandCode.KeyAfterTouch:
                    {
                        value = (e as NoteOnEvent).Velocity;
                        break;
                    }
                case MidiCommandCode.ControlChange:
                    {
                        value = (e as ControlChangeEvent).ControllerValue;
                        break;
                    }
                case MidiCommandCode.PatchChange:
                    {
                        value = (e as PatchChangeEvent).Patch;
                        break;
                    }
                case MidiCommandCode.ChannelAfterTouch:
                    {
                        value = (e as ChannelAfterTouchEvent).AfterTouchPressure;
                        break;
                    }
                case MidiCommandCode.PitchWheelChange:
                    {
                        value = (e as PitchWheelChangeEvent).Pitch;
                        break;
                    }
                default:
                    {
                        value = 0;
                        break;
                    }
            }

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            int Key = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '{') Key = i;
                else if (text[i] == '}') keyValuePairs.Add(Key, i);
            }

            foreach(var c in keyValuePairs)
            {
                string data = text.Substring(c.Key + 1, c.Value - c.Key - 1);

                if(data == "VALUE")
                {
                    text = text.Remove(c.Key, c.Value - c.Key + 1);
                    text = text.Insert(c.Key, value.ToString());
                }
                else if(data == "CHANNEL")
                {
                    text = text.Remove(c.Key, c.Value - c.Key + 1);
                    text = text.Insert(c.Key, e.Channel.ToString());
                }
                else if(data == @"\n")
                {
                    text = text.Remove(c.Key, c.Value - c.Key + 1);
                    text = text.Insert(c.Key, "\n");
                }
                else if(data == "COMMANDCODE")
                {
                    text = text.Remove(c.Key, c.Value - c.Key + 1);
                    text = text.Insert(c.Key, e.CommandCode.ToString());
                }
                else if(data == "DELTATIME")
                {
                    text = text.Remove(c.Key, c.Value - c.Key + 1);
                    text = text.Insert(c.Key, e.DeltaTime.ToString());
                }
                else if(data == "TIME")
                {
                    text = text.Remove(c.Key, c.Value - c.Key + 1);
                    text = text.Insert(c.Key, DateTime.Now.ToString("HH:mm:ss"));
                }
                else if(data == "DATE")
                {
                    text = text.Remove(c.Key, c.Value - c.Key + 1);
                    text = text.Insert(c.Key, DateTime.Now.Date.ToString());
                }
                else
                {
                    if (data.StartsWith("GET"))
                    {
                        text = text.Remove(c.Key, c.Value - c.Key + 1);
                        string result = Program.arduinoMIDI.storage[Int32.Parse(data.Replace("GET(", "").Replace(")", ""))];
                        text = text.Insert(c.Key, result);
                    }
                    else if (data.StartsWith("PUT"))
                    {
                        string functionContent = data.Replace("PUT(", "").Replace(")", "");
                        string[] param = functionContent.Split(',');
                        text = "";
                        control.Invoke((MethodInvoker)delegate { Program.arduinoMIDI.storage.Insert(Int32.Parse(param[0].Trim()), param[1].Trim().Replace("\"", "")); });                       
                    }
                }
            }

            return text;
        }

        private string returnName(MidiEvent midiEvent)
        {
            string message = "";
            switch (midiEvent.CommandCode)
            {
                case MidiCommandCode.NoteOff:
                    {
                        message = midiEvent.CommandCode + " " + (midiEvent as NoteEvent).NoteName;
                        break;
                    }
                case MidiCommandCode.NoteOn:
                    {
                        message = midiEvent.CommandCode + " " + (midiEvent as NoteEvent).NoteName;
                        break;
                    }
                case MidiCommandCode.KeyAfterTouch:
                    {
                        message = midiEvent.CommandCode + " " + (midiEvent as NoteOnEvent).NoteName;
                        break;
                    }
                case MidiCommandCode.ControlChange:
                    {
                        message = midiEvent.CommandCode + " " + (midiEvent as ControlChangeEvent).Controller.ToString();
                        break;
                    }
                case MidiCommandCode.PatchChange:
                    {
                        message = (midiEvent as PatchChangeEvent).ToString();
                        break;
                    }
                case MidiCommandCode.ChannelAfterTouch:
                    {
                        message = (midiEvent as ChannelAfterTouchEvent).ToString();
                        break;
                    }
                case MidiCommandCode.PitchWheelChange:
                    {
                        message = (midiEvent as PitchWheelChangeEvent).ToString();
                        break;
                    }
            }

            return message;
        }

        public void UpdateMidi()
        {
            Program.arduinoMIDI.midiIn.MessageReceived += MidiIn_MessageReceived;
            Program.arduinoMIDI.midiIn.ErrorReceived += MidiIn_ErrorReceived;
        }

        private void UpdateErrors()
        {
            Program.arduinoMIDI.errorsCount++;
        }

        public void UpdateIndex(int index)
        {
            this.actionManager.updateIndex(index);
        }

        #endregion

        #region contextMenu

        private void moveUp_Click(object sender, EventArgs e)
        {
            int index = Program.arduinoMIDI.midiList.Controls.IndexOf(this);
            if (index == 0) return;
            int nextIndex = index - 1;
            Program.arduinoMIDI.midiList.Controls.SetChildIndex(this, nextIndex);
            Program.arduinoMIDI.midiList.Refresh();
            this.UpdateIndex(nextIndex);
            (Program.arduinoMIDI.midiList.Controls[index] as MIDIButton).UpdateIndex(index);
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            int index = Program.arduinoMIDI.midiList.Controls.IndexOf(this);
            if (index == Program.arduinoMIDI.midiList.Controls.Count - 1) return;
            int nextIndex = index + 1;
            Program.arduinoMIDI.midiList.Controls.SetChildIndex(this, nextIndex);
            Program.arduinoMIDI.midiList.Refresh();
            this.UpdateIndex(nextIndex);
            (Program.arduinoMIDI.midiList.Controls[index] as MIDIButton).UpdateIndex(index);
        }

        #region rename

        private DarkUI.Controls.DarkTextBox textbox;
        private void rename_Click(object sender, EventArgs e)
        {
            textbox = new DarkUI.Controls.DarkTextBox();
            textbox.Location = new Point(0, 3);
            textbox.Size = new Size(169, 20);
            textbox.MaxLength = 16;
            textbox.Text = buttonCode.Text;
            buttonCode.Controls.Add(textbox);
            textbox.Focus();
            textbox.SelectAll();

            textbox.MouseDown += Textbox_LostFocus;
            textbox.LostFocus += Textbox_LostFocus;
            textbox.KeyDown += Textbox_KeyDown;
        }

        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCode.Text = textbox.Text;
                buttonCode.Controls.Remove(textbox);
                textbox.Dispose();
            }
        }

        private void Textbox_LostFocus(object sender, EventArgs e)
        {
            buttonCode.Text = textbox.Text;
            buttonCode.Controls.Remove(textbox);
            textbox.Dispose();
        }

        #endregion        

        private void remove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to remove this button configuration?", "Arduino MIDI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.arduinoMIDI.midiList.Controls.Remove(this);
                Program.arduinoMIDI.updateBindsIndexes();
                Program.arduinoMIDI.midiIn.MessageReceived -= this.MidiIn_MessageReceived;
                Program.arduinoMIDI.midiIn.ErrorReceived -= this.MidiIn_ErrorReceived;
                this.Dispose();
            }
        }

        private bool showIneractionBool = false;

        private void MIDIButtonContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Program.arduinoMIDI.midiList.Controls.IndexOf(this) == 0)
                moveUp.Enabled = false;
            else
                moveUp.Enabled = true;

            if(Program.arduinoMIDI.midiList.Controls.IndexOf(this) == Program.arduinoMIDI.midiList.Controls.Count - 1)
                moveDown.Enabled = false;
            else
                moveDown.Enabled = true;
        }

        private void showInteraction_Click(object sender, EventArgs e)
        {
            showIneractionBool = !showIneractionBool;
            showInteraction.Checked = showIneractionBool;
        }

        #endregion
    }
}
