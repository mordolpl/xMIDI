
namespace xMidi.Controls.Actions
{
    partial class MIDIFileAction
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectAppBtn = new DarkUI.Controls.DarkButton();
            this.pathTxt = new DarkUI.Controls.DarkTextBox();
            this.unlockContextMenu = new DarkUI.Controls.DarkContextMenu();
            this.unlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.midiOutDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.stopBtn = new DarkUI.Controls.DarkButton();
            this.unlockContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectAppBtn
            // 
            this.selectAppBtn.Location = new System.Drawing.Point(223, 50);
            this.selectAppBtn.Name = "selectAppBtn";
            this.selectAppBtn.Padding = new System.Windows.Forms.Padding(5);
            this.selectAppBtn.Size = new System.Drawing.Size(25, 23);
            this.selectAppBtn.TabIndex = 2;
            this.selectAppBtn.Text = "...";
            this.selectAppBtn.Click += new System.EventHandler(this.selectAppBtn_Click);
            // 
            // pathTxt
            // 
            this.pathTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.pathTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathTxt.ContextMenuStrip = this.unlockContextMenu;
            this.pathTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.pathTxt.Location = new System.Drawing.Point(10, 50);
            this.pathTxt.Name = "pathTxt";
            this.pathTxt.ReadOnly = true;
            this.pathTxt.Size = new System.Drawing.Size(207, 23);
            this.pathTxt.TabIndex = 1;
            // 
            // unlockContextMenu
            // 
            this.unlockContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.unlockContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.unlockContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unlockToolStripMenuItem});
            this.unlockContextMenu.Name = "unlockContextMenu";
            this.unlockContextMenu.Size = new System.Drawing.Size(113, 26);
            // 
            // unlockToolStripMenuItem
            // 
            this.unlockToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.unlockToolStripMenuItem.Checked = true;
            this.unlockToolStripMenuItem.CheckOnClick = true;
            this.unlockToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.unlockToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.unlockToolStripMenuItem.Name = "unlockToolStripMenuItem";
            this.unlockToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.unlockToolStripMenuItem.Text = "Locked";
            this.unlockToolStripMenuItem.CheckedChanged += new System.EventHandler(this.unlockToolStripMenuItem_CheckedChanged);
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(7, 32);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(81, 15);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "MIDI file path:";
            // 
            // midiOutDrop
            // 
            this.midiOutDrop.Location = new System.Drawing.Point(88, 79);
            this.midiOutDrop.Name = "midiOutDrop";
            this.midiOutDrop.Size = new System.Drawing.Size(160, 26);
            this.midiOutDrop.TabIndex = 4;
            this.midiOutDrop.Text = "darkDropdownList1";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(9, 83);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(73, 15);
            this.darkLabel2.TabIndex = 3;
            this.darkLabel2.Text = "MIDI Device:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Application";
            this.openFileDialog.Filter = "Midi files|*.midi;*.mid";
            this.openFileDialog.Title = "Arduino MIDI - Open App";
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(178, 127);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Padding = new System.Windows.Forms.Padding(5);
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 5;
            this.stopBtn.Text = "Stop";
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // MIDIFileAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.midiOutDrop);
            this.Controls.Add(this.selectAppBtn);
            this.Controls.Add(this.pathTxt);
            this.Controls.Add(this.darkLabel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MIDIFileAction";
            this.Size = new System.Drawing.Size(256, 153);
            this.unlockContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkButton selectAppBtn;
        public DarkUI.Controls.DarkTextBox pathTxt;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkContextMenu unlockContextMenu;
        private System.Windows.Forms.ToolStripMenuItem unlockToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DarkUI.Controls.DarkButton stopBtn;
        public DarkUI.Controls.DarkDropdownList midiOutDrop;
    }
}
