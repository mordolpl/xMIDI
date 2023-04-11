using System;
using System.Drawing;
using System.Windows.Forms;

namespace MidiArduino
{
    public partial class StopForm : Form
    {
        public StopForm(int errorCount, string time)
        {
            InitializeComponent();
            errorsTxt.Text = "Error: " + errorCount;
            timeTxt.Text = "In time: " + time;

            if (errorCount == 0) errorsTxt.ForeColor = Color.Green;
            else if(errorCount > 0 && errorCount < 10) errorsTxt.ForeColor = Color.Orange;
            else errorsTxt.ForeColor = Color.Red;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
