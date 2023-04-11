using System;
using System.Windows.Forms;

namespace xMidi
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            midiInteractionCheck.Checked = Properties.Settings.Default.midiIOIneraction;
            autoStartCheck.Checked = Properties.Settings.Default.autoStart;
            outputEnableCheck.Checked = Properties.Settings.Default.outputEnable;
            hideMinimalizeCheck.Checked = Properties.Settings.Default.hideMinimalize;
            runStartupCheck.Checked = Properties.Settings.Default.runStartup;
            configAutoloadCheck.Checked = Properties.Settings.Default.configAutoload;

            if (Program.xMIDI.isStarted) outputEnableCheck.Enabled = false;
            configPathTxtBox.Text = Properties.Settings.Default.configPath;
        }

        #region checkBoxChange

        private void mainTopCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.midiIOIneraction = midiInteractionCheck.Checked;
        }

        private void autoStartCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoStart = autoStartCheck.Checked;
        }

        private void outputEnableCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!Program.xMIDI.isStarted)
            {
                Properties.Settings.Default.outputEnable = outputEnableCheck.Checked;
                Program.xMIDI.midiOutput.Enabled = outputEnableCheck.Checked;
            }
        }

        private void hideCloseCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.hideMinimalize = hideMinimalizeCheck.Checked;
        }

        private void runStartupCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.runStartup = runStartupCheck.Checked;
        }

        private void configAutoloadCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.configAutoload = configAutoloadCheck.Checked;
        }

        #endregion

        #region buttonEvents

        private void loadConfigBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog.Dispose();

                Settings.loadConfig(openFileDialog.FileName);
            }
        }

        private void saveConfigBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog.Dispose();
                Settings.saveConfig(saveFileDialog.FileName);
            }
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Program.xMIDI.inputSygnalDiode.Visible = Program.xMIDI.outputSygnalDiode.Visible = Properties.Settings.Default.midiIOIneraction;
            this.Close();
        }

        private void autoConfigBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog.Dispose();
            }

            Properties.Settings.Default.configPath = openFileDialog.FileName;
            configPathTxtBox.Text = openFileDialog.FileName;
        }

        #endregion

        #region formEvents
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Reload();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                System.Diagnostics.Process.Start("https://github.com/mordolpl");
        }

        #endregion
    }
}
