using System;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace MidiArduino.Controls.Actions
{
    public partial class KeyShortcutAction : UserControl
    {
        public string Modifiers;
        public string KeyCode;
        public Keys key;
        public KeyShortcutAction()
        {
            InitializeComponent();
        }

        private void KeyShortcutAction_KeyDown(object sender, KeyEventArgs e)
        {
            keyShortcut.Text = (e.Modifiers.ToString() + " + ").Replace("None + ", "") + e.KeyCode.ToString();
            Modifiers = e.Modifiers.ToString();
            KeyCode = e.KeyCode.ToString();
            key = e.KeyCode;
        }

        private void keyShortcut_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        public void sendKeyShortcut(bool async)
        {
            if (async) new Thread(() => { sendKeyShortcut(); }).Start();
            else sendKeyShortcut();
        }

        public void sendKeyShortcut()
        {
            /*string sendKey = "";
            string[] modif = Modifiers.Split(',');
            for (int j = 0; j < modif.Length; j++)
            {
                sendKey += modif[j].Trim().Replace("Shift", "+").Replace("Control", "^").Replace("Alt", "%") + "(";
            }
            sendKey += "{" + KeyCode + "}";
            for (int j = 0; j < modif.Length; j++)
                sendKey += ")";

            SendKeys.Send(sendKey);*/

            InputSimulator sim = new InputSimulator();
            sim.Keyboard.KeyPress((VirtualKeyCode)key);
        }
    }
}
