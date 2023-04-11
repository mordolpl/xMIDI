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
            actionIgniter = new ActionIgniter(index);
            Index = index;

            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("None"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Key Shortcut"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Run Application"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send Shell Command"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send Serial Data"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send MIDI Data"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send DMX512"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Run C# Code"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Send MIDI File"));
            actionTypeList.Items.Add(new DarkUI.Controls.DarkDropdownItem("Templates"));
        }

        #region Events

        private void actionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            actionType.Controls.Clear();
            switch (actionCombo.SelectedIndex)
            {
                case 0:
                    {
                        actionType.Controls.Add(new KeyShortcutAction());
                        break;
                    }
                case 1:
                    {
                        actionType.Controls.Add(new RunAction());
                        break;
                    }
                case 2:
                    {
                        actionType.Controls.Add(new ShellAction());
                        break;
                    }
                case 3:
                    {
                        actionType.Controls.Add(new SerialAction());
                        break;
                    }
                case 4:
                    {
                        actionType.Controls.Add(new MIDIAction());
                        break;
                    }
                case 5:
                    {
                        actionType.Controls.Add(new TemplatesAction(Index));
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
