using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace MidiArduino.Controls.Actions
{
    public partial class KeyShortcutAction : UserControl
    {
        public string Modifiers;
        public Keys KeyCode;
        public KeyShortcutAction()
        {
            InitializeComponent();
        }

        private void KeyShortcutAction_KeyDown(object sender, KeyEventArgs e)
        {
            keyShortcut.Text = (e.Modifiers.ToString() + " + ").Replace("None + ", "") + e.KeyCode.ToString();
            Modifiers = e.Modifiers.ToString();
            KeyCode = e.KeyCode;
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
            List<VirtualKeyCode> modifiers = new List<VirtualKeyCode>();
            if (Modifiers.Contains("Shift")) modifiers.Add(VirtualKeyCode.SHIFT);
            if (Modifiers.Contains("Control")) modifiers.Add(VirtualKeyCode.CONTROL);
            if (Modifiers.Contains("Alt")) modifiers.Add(VirtualKeyCode.MENU);

            InputSimulator sim = new InputSimulator();
            sim.Keyboard.ModifiedKeyStroke(modifiers, (VirtualKeyCode)KeyCode);
        }
    }
}
