using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiArduino.Controls.Actions
{
    public partial class KeyShortcutAction : UserControl
    {
        public string Modifiers;
        public string KeyCode;
        public KeyShortcutAction()
        {
            InitializeComponent();
        }

        private void KeyShortcutAction_KeyDown(object sender, KeyEventArgs e)
        {
            keyShortcut.Text = (e.Modifiers.ToString() + " + ").Replace("None + ", "") + e.KeyCode.ToString();
            Modifiers = e.Modifiers.ToString();
            KeyCode = e.KeyCode.ToString();
        }

        private void keyShortcut_Click(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}
