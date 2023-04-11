using MidiArduino.Controls.Actions;
using MidiArduino.Forms;
using System;
using System.Windows.Forms;

namespace MidiArduino.Controls
{
    public partial class ActionControl : UserControl
    {
        public ActionIgniter actionIgniter;
        public int Index;
        public ActionControl(int index)
        {
            InitializeComponent();
            actionIgniter = new ActionIgniter();
            Index = index;

            #region Add actions to list

            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("None"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Key Shortcut"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Run Application"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send Shell Command"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send Serial Data"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send DMX512"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send MIDI Data"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send MIDI File"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Templates"));

            #endregion
        }

        #region Events

        private void actionTypeList_SelectedItemChanged(object sender, EventArgs e)
        {
            actionType.Controls.Clear();
            switch (actionTypeList.SelectedItem.Text)
            {
                case "Key Shortcut":
                    {
                        actionType.Controls.Add(new KeyShortcutAction());
                        break;
                    }
                case "Run Application":
                    {
                        actionType.Controls.Add(new RunAction());
                        break;
                    }
                case "Send Shell Command":
                    {
                        actionType.Controls.Add(new ShellAction());
                        break;
                    }
                case "Send Serial Data":
                    {
                        actionType.Controls.Add(new SerialAction());
                        break;
                    }
                case "Send MIDI Data":
                    {
                        actionType.Controls.Add(new MIDIAction());
                        break;
                    }
                case "Templates":
                    {
                        actionType.Controls.Add(new TemplatesAction(Index));
                        break;
                    }
                case "Send MIDI File":
                    {
                        actionType.Controls.Add(new MIDIFileAction());
                        break;
                    }
                case "Send DMX512":
                    {
                        actionType.Controls.Add(new DMXAction());
                        break;
                    }
            }
        }

        private void actionIngiterBtn_Click(object sender, EventArgs e)
        {
            actionIgniter.ShowDialog();
        }

        #endregion
    }
}
