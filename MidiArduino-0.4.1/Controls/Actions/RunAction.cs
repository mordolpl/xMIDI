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
    }
}
