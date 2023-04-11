using MidiArduino.Controls.Actions;
using MidiArduino.Forms;
using NAudio.Midi;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MidiArduino
{
    public partial class MIDIButton : UserControl
    {
        public ActionManager actionManager;
        public MidiEvent midiEvent;
        private Stopwatch stopwatch;
        public BindPropertiesData data;
        public MIDIButton(BindPropertiesData bindData)
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            midiEvent = bindData.e;
            if(midiEvent != null) buttonCode.Text = returnName(midiEvent);
            actionManager = new ActionManager(bindData.id);
            data = bindData;
            data.name = returnName(midiEvent);
            BackColor = data.bgColor;
            buttonCode.BackColor = data.bgColor;
            buttonCode.ForeColor = data.fontColor;
            if(Program.arduinoMIDI.midiIn != null) Program.arduinoMIDI.midiIn.MessageReceived += MidiIn_MessageReceived;
            if (Program.arduinoMIDI.midiIn != null) Program.arduinoMIDI.midiIn.ErrorReceived += MidiIn_ErrorReceived;
        }

        #region hoverEffect

        private void buttonCode_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = data.hoverColor;
            buttonCode.BackColor = data.hoverColor;
        }

        private void buttonCode_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = data.hoverColor;
            buttonCode.BackColor = data.hoverColor;
        }

        private void buttonCode_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = data.bgColor;
            buttonCode.BackColor = data.bgColor;
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
            if (data.isAsync)
            {
                Thread thread = new Thread(() => actionsLoop(e));
                thread.Start();
            }
            else actionsLoop(e);
        }

        private void actionsLoop(MidiInMessageEventArgs e)
        {
            string event1 = returnName(midiEvent);
            string event2 = returnName(e.MidiEvent);

            if (Program.arduinoMIDI.isStarted && buttonActiveCheck.Checked)
            {
                if (data.channelB == 0 && midiEvent.Channel != e.MidiEvent.Channel) return;
                if (data.eventB == 0 && event1 != event2) return;

                if (showIneractionBool)
                {
                    if (stopwatch.ElapsedMilliseconds > 20)
                        new Thread(() =>
                        {
                            this.Invoke((MethodInvoker)delegate {
                                buttonCode.BackColor = data.interactColor;
                                this.BackColor = data.interactColor;
                            });
                            Thread.Sleep(20);
                            this.Invoke((MethodInvoker)delegate {
                                buttonCode.BackColor = data.bgColor;
                                this.BackColor = data.bgColor;
                            });
                        }).Start();
                    stopwatch = new Stopwatch();
                    stopwatch.Start();
                }

                for (int i = 0; i < actionManager.actionList.Items.Count; i++)
                {
                    try
                    {
                        if (actionManager.actionControls[i].actionIgniter.Condition(e.MidiEvent))
                        {
                            if ((int)actionManager.actionControls[i].delayNum.Value > 0)
                                Thread.Sleep((int)actionManager.actionControls[i].delayNum.Value);

                            switch (actionManager.actionControls[i].actionTypeList.SelectedItem.Text)
                            {
                                case "Key Shortcut":
                                {
                                    (actionManager.actionControls[i].actionType.Controls[0] as KeyShortcutAction).sendKeyShortcut(actionManager.actionControls[i].asyncCheck.Checked);
                                    break;
                                }
                                case "Run Application":
                                {
                                    (actionManager.actionControls[i].actionType.Controls[0] as RunAction).runApplication(e.MidiEvent, actionManager.actionControls[i].asyncCheck.Checked);
                                    break;
                                }
                                case "Send Shell Command":
                                {
                                    (actionManager.actionControls[i].actionType.Controls[0] as ShellAction).sendShell(e.MidiEvent, actionManager.actionControls[i].asyncCheck.Checked);
                                    break;
                                }
                                case "Send Serial Data":
                                {
                                    (actionManager.actionControls[i].actionType.Controls[0] as SerialAction).serialData(e.MidiEvent, actionManager.actionControls[i].asyncCheck.Checked);
                                    break;
                                }
                                case "Send DMX512":
                                {
                                    (actionManager.actionControls[i].actionType.Controls[0] as DMXAction).startDMX(e.MidiEvent, actionManager.actionControls[i].asyncCheck.Checked);
                                    break;
                                }
                                case "Send MIDI Data":
                                {
                                    (actionManager.actionControls[i].actionType.Controls[0] as MIDIAction).sendMidi(e.MidiEvent, actionManager.actionControls[i].asyncCheck.Checked);
                                    break;
                                }
                                case "Send MIDI File":
                                {
                                    (actionManager.actionControls[i].actionType.Controls[0] as MIDIFileAction).sendMidiFile(e.MidiEvent, actionManager.actionControls[i].asyncCheck.Checked);
                                    break;
                                }
                                case "Templates":
                                {
                                    (actionManager.actionControls[i].actionType.Controls[0] as TemplatesAction).useTemplate(e.MidiEvent, midiEvent, actionManager.actionControls[i].asyncCheck.Checked);
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

        public static string replaceAliases(string text, MidiEvent e)
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

            int deep = 0;
            int count;
            bool isNotEmpty = true;
            do
            {
                count = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '{') deep++;
                    else if (text[i] == '}')
                    {
                        deep--;
                        count++;
                        if (deep >= 0)
                        {
                            string data = "";
                            int startIndex = 0;

                            for(int j = i - 1; j > 0; j--)
                            {
                                if (text[j] == '{') { startIndex = j; break; }
                                data += text[j];
                            }

                            char[] charArray = data.ToCharArray();
                            Array.Reverse(charArray);
                            data = new string(charArray);

                            if (data == "VALUE")
                            {
                                text = text.Remove(startIndex, data.Length + 2);
                                text = text.Insert(startIndex, value.ToString());
                                break;
                            }
                            else if (data == "CHANNEL")
                            {
                                text = text.Remove(startIndex, data.Length + 2);
                                text = text.Insert(startIndex, e.Channel.ToString());
                                break;
                            }
                            else if (data == "COMMANDCODE")
                            {
                                text = text.Remove(startIndex, data.Length + 2);
                                text = text.Insert(startIndex, e.CommandCode.ToString());
                                break;
                            }
                            else if (data == "ABSOLUTETIME")
                            {
                                text = text.Remove(startIndex, data.Length + 2);
                                text = text.Insert(startIndex, e.AbsoluteTime.ToString());
                                break;
                            }
                            else if (data == "DELTATIME")
                            {
                                text = text.Remove(startIndex, data.Length + 2);
                                text = text.Insert(startIndex, e.DeltaTime.ToString());
                                break;
                            }
                            else if (data == "TIME")
                            {
                                text = text.Remove(startIndex, data.Length + 2);
                                text = text.Insert(startIndex, DateTime.Now.ToString("HH:mm:ss"));
                                break;
                            }
                            else if (data == "DATE")
                            {
                                text = text.Remove(startIndex, data.Length + 2);
                                text = text.Insert(startIndex, DateTime.Now.Date.ToString());
                                break;
                            }
                            else if (data == @"\n" || data == "NEWLINE")
                            {
                                text = text.Remove(startIndex, data.Length + 2);
                                text = text.Insert(startIndex, "\n");
                                break;
                            }
                            else if (data == "USER")
                            {
                                text = text.Remove(startIndex, data.Length + 2);
                                text = text.Insert(startIndex, Environment.UserName);
                                break;
                            }
                            else if (data == "DESKTOP")
                            {
                                text = text.Remove(startIndex, data.Length + 2);
                                text = text.Insert(startIndex, Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                                break;
                            }
                            else
                            {
                                if (data.StartsWith("GET"))
                                {
                                    text = text.Remove(startIndex, data.Length + 2);
                                    string result = Utils.Helper.storage[Convert.ToInt32(data.Replace("GET(", "").Replace(")", ""))];
                                    text = text.Insert(startIndex, result);
                                    break;
                                }
                                else if (data.StartsWith("PUT"))
                                {
                                    text = text.Remove(startIndex, data.Length + 2);
                                    string functionContent = data.Replace("PUT(", "").Replace(")", "");
                                    string[] param = functionContent.Split(',');
                                    Utils.Helper.storage.Insert(Convert.ToInt32(param[0].Trim()), param[1].Trim().Replace("\"", ""));
                                    break;
                                }
                                else if (data.StartsWith("MATH"))
                                {
                                    text = text.Remove(startIndex, data.Length + 2);
                                    DataTable dt = new DataTable();
                                    var result = dt.Compute(data.Replace("MATH(\"", "").Replace("\")", ""), "");
                                    text = text.Insert(startIndex, result.ToString());
                                    break;
                                }
                                else if (data.StartsWith("DELAY"))
                                {
                                    text = text.Remove(startIndex, data.Length + 2);
                                    int result = Int32.Parse(data.Replace("DELAY(", "").Replace(")", ""));
                                    Thread.Sleep(result);
                                    break;
                                }
                                else if (data.StartsWith("PATH"))
                                {
                                    text = text.Remove(startIndex, data.Length + 2);
                                    int directory = Convert.ToInt32(data.Replace("PATH(", "").Replace(")", ""));
                                    string result = Environment.GetFolderPath((Environment.SpecialFolder)directory);
                                    text = text.Insert(startIndex, result.ToString());
                                    break;
                                }
                                else if (data.StartsWith("RANDOM"))
                                {
                                    text = text.Remove(startIndex, data.Length + 2);
                                    string functionContent = data.Replace("RANDOM(", "").Replace(")", "");
                                    string[] param = functionContent.Split(',');
                                    Random random = new Random();
                                    if(functionContent.Length == 0) text = text.Insert(startIndex, random.NextDouble().ToString().Replace(',', '.'));
                                    else text = text.Insert(startIndex, random.Next(Convert.ToInt32(param[0]), Convert.ToInt32(param[1]) + 1).ToString());
                                    break;
                                }
                                else if (data.StartsWith("REPLACE"))
                                {
                                    text = text.Remove(startIndex, data.Length + 2);
                                    string functionContent = data.Replace("REPLACE(", "").Replace(")", "");
                                    string[] param = functionContent.Split(',');
                                    text = text.Insert(startIndex, param[0].Replace("\"", "").Replace(param[1].Replace("\"", "").Trim(), param[2].Replace("\"", "").Trim()));
                                    break;
                                }
                                else if(data.StartsWith("MSG"))
                                {
                                    text = text.Remove(startIndex, data.Length + 2);
                                    string result = data.Replace("MSG(\"", "").Replace("\")", "");
                                    MessageBox.Show(result);
                                    break;
                                }

                                count--;
                            }
                        }
                    }
                }
                if (count == 0) isNotEmpty = false;
            }
            while (isNotEmpty);

            return text;
        }

        public static string returnName(MidiEvent midiEvent)
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
                default:
                    {
                        message = midiEvent.ToString();
                        break;
                    }
            }

            return message;
        }

        public void UpdateMidi()
        {
            Program.arduinoMIDI.midiIn.MessageReceived += MidiIn_MessageReceived;
            Program.arduinoMIDI.midiIn.ErrorReceived += MidiIn_ErrorReceived;

            MidiInMessageEventArgs message = new MidiInMessageEventArgs(midiEvent.GetAsShortMessage(), 0);
            if (data.runOnStart) actionsLoop(message);
        }

        private void UpdateErrors()
        {
            Program.arduinoMIDI.errorsCount++;
        }

        public void stopActions()
        {
            foreach(var action in actionManager.actionControls)
            {
                if(action.actionType.Controls.Count > 0)
                {
                    if (action.actionType.Controls[0] is MIDIFileAction)
                    {
                        (action.actionType.Controls[0] as MIDIFileAction).stopPlaying();
                    }
                    else if (action.actionType.Controls[0] is DMXAction)
                    {
                        (action.actionType.Controls[0] as DMXAction).disconnect();
                        (action.actionType.Controls[0] as DMXAction).stopDMX();
                    }
                    else if (action.actionType.Controls[0] is SerialAction)
                    {
                        (action.actionType.Controls[0] as SerialAction).disconnect();
                    }
                }
            }
        }

        public void UpdateIndex(int index)
        {
            this.actionManager.updateIndex(index);
            data.id = index;
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

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindProperties bp = new BindProperties(data);
            bp.ShowDialog();
            bp.Dispose();

            buttonCode.Text = data.name;
            BackColor = data.bgColor;
            buttonCode.BackColor = data.bgColor;
            buttonCode.ForeColor = data.fontColor;
            if(data.e != null) midiEvent = data.e;
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
                data.name = buttonCode.Text;
                buttonCode.Controls.Remove(textbox);
                textbox.Dispose();
            }
        }

        private void Textbox_LostFocus(object sender, EventArgs e)
        {
            buttonCode.Text = textbox.Text;
            data.name = buttonCode.Text;
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

    public struct BindPropertiesData
    {
        public string name;
        public int id;
        [JsonIgnore]
        public MidiEvent e;
        public bool isAsync;
        public bool runOnStart;
        public int channelB;
        public int eventB;

        public Color bgColor;
        public Color hoverColor;
        public Color interactColor;
        public Color fontColor;
    }
}
