using System;
using System.Drawing;
using System.Windows.Forms;

namespace xMidi.Forms
{
    public partial class BindProperties : Form
    {
        private BindPropertiesData newData;
        public BindProperties(BindPropertiesData data)
        {
            InitializeComponent();

            channelDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Binded"));
            channelDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Every"));

            eventDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Binded"));
            eventDrop.Items.Add(new DarkUI.Controls.DarkDropdownItem("Every"));

            nameTxt.Text = data.name;
            asyncCheck.Checked = data.isAsync;
            runOnStartCheck.Checked = data.runOnStart;
            fontColorPanel.BackColor = data.fontColor;
            bgColorPanel.BackColor = data.bgColor;
            hoverColorPanel.BackColor = data.hoverColor;
            interactColorPanel.BackColor = data.interactColor;
            newData = data;

            channelDrop.SelectedItem = channelDrop.Items[data.channelB];
            eventDrop.SelectedItem = eventDrop.Items[data.eventB];
        }
        private void fontColorPanel_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                fontColorPanel.BackColor = colorDialog.Color;
                newData.fontColor = colorDialog.Color;
            }
        }
        private void bgColorPanel_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                bgColorPanel.BackColor = colorDialog.Color;
                newData.bgColor = colorDialog.Color;
            }
        }
        private void hoverColorPanel_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                hoverColorPanel.BackColor = colorDialog.Color;
                newData.hoverColor = colorDialog.Color;
            }
        }
        private void interactColorPanel_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                interactColorPanel.BackColor = colorDialog.Color;
                newData.interactColor = colorDialog.Color;
            }
        }

        private void asyncCheck_CheckedChanged(object sender, EventArgs e)
        {
            newData.isAsync = asyncCheck.Checked;
        }
        private void runOnStartCheck_CheckedChanged(object sender, EventArgs e)
        {
            newData.runOnStart = runOnStartCheck.Checked;
        }

        #region Rename

        private DarkUI.Controls.DarkTextBox textbox;
        private void renameBtn_Click(object sender, EventArgs e)
        {
            textbox = new DarkUI.Controls.DarkTextBox();
            textbox.Location = new Point(0, 0);
            textbox.Size = new Size(198, 47);
            textbox.MaxLength = 16;
            textbox.Multiline = true;
            textbox.TextAlign = HorizontalAlignment.Center;
            textbox.Text = nameTxt.Text;
            nameTxt.Controls.Add(textbox);
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
                nameTxt.Text = textbox.Text;
                newData.name = textbox.Text;
                nameTxt.Controls.Remove(textbox);
                textbox.Dispose();
            }
        }
        private void Textbox_LostFocus(object sender, EventArgs e)
        {
            nameTxt.Text = textbox.Text;
            newData.name = textbox.Text;
            nameTxt.Controls.Remove(textbox);
            textbox.Dispose();
        }

        #endregion
        private void rebindBtn_Click(object sender, EventArgs e)
        {
            ButtonSelector buttonSelector = new ButtonSelector();
            buttonSelector.ShowDialog();
            buttonSelector.Dispose();
            if (Program.arduinoMIDI.midiEvent == null) return;
            newData.e = Program.arduinoMIDI.midiEvent;
            Program.arduinoMIDI.midiEvent = null;
            nameTxt.Text = MIDIButton.returnName(newData.e);
            newData.name = nameTxt.Text;
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            (Program.arduinoMIDI.midiList.Controls[newData.id] as MIDIButton).data = newData;
            this.Close();
        }

        private void channelDrop_SelectedItemChanged(object sender, EventArgs e)
        {
            newData.channelB = (channelDrop.SelectedItem.Text == "Binded") ? 0 : 1;
        }
        private void eventDrop_SelectedItemChanged(object sender, EventArgs e)
        {
            newData.eventB = (eventDrop.SelectedItem.Text == "Binded") ? 0 : 1;
        }
    }
}
