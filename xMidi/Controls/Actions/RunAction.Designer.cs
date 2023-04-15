
namespace xMidi.Controls.Actions
{
    partial class RunAction
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
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.pathTxt = new DarkUI.Controls.DarkTextBox();
            this.unlockContextMenu = new DarkUI.Controls.DarkContextMenu();
            this.unlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAppBtn = new DarkUI.Controls.DarkButton();
            this.argumentsTxt = new DarkUI.Controls.DarkTextBox();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.unlockContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(7, 23);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(98, 15);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Application path:";
            // 
            // pathTxt
            // 
            this.pathTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.pathTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathTxt.ContextMenuStrip = this.unlockContextMenu;
            this.pathTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.pathTxt.Location = new System.Drawing.Point(10, 41);
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
            // selectAppBtn
            // 
            this.selectAppBtn.Location = new System.Drawing.Point(223, 41);
            this.selectAppBtn.Name = "selectAppBtn";
            this.selectAppBtn.Padding = new System.Windows.Forms.Padding(5);
            this.selectAppBtn.Size = new System.Drawing.Size(25, 23);
            this.selectAppBtn.TabIndex = 2;
            this.selectAppBtn.Text = "...";
            this.selectAppBtn.Click += new System.EventHandler(this.selectAppBtn_Click);
            // 
            // argumentsTxt
            // 
            this.argumentsTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.argumentsTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.argumentsTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.argumentsTxt.Location = new System.Drawing.Point(10, 94);
            this.argumentsTxt.Name = "argumentsTxt";
            this.argumentsTxt.Size = new System.Drawing.Size(207, 23);
            this.argumentsTxt.TabIndex = 4;
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(7, 76);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(91, 15);
            this.darkLabel2.TabIndex = 3;
            this.darkLabel2.Text = "Run arguments:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Application";
            this.openFileDialog.Title = "xMIDI - Open App";
            // 
            // RunAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.argumentsTxt);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.selectAppBtn);
            this.Controls.Add(this.pathTxt);
            this.Controls.Add(this.darkLabel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RunAction";
            this.Size = new System.Drawing.Size(256, 153);
            this.unlockContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkButton selectAppBtn;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public DarkUI.Controls.DarkTextBox pathTxt;
        public DarkUI.Controls.DarkTextBox argumentsTxt;
        private DarkUI.Controls.DarkContextMenu unlockContextMenu;
        private System.Windows.Forms.ToolStripMenuItem unlockToolStripMenuItem;
    }
}
