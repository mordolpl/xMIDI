
namespace MidiArduino
{
    partial class MIDIButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIButton));
            this.buttonActiveCheck = new DarkUI.Controls.DarkCheckBox();
            this.buttonCode = new DarkUI.Controls.DarkLabel();
            this.MIDIButtonContext = new DarkUI.Controls.DarkContextMenu();
            this.moveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rename = new System.Windows.Forms.ToolStripMenuItem();
            this.remove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showInteraction = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBtn = new DarkUI.Controls.DarkButton();
            this.settingsBtn = new DarkUI.Controls.DarkButton();
            this.MIDIButtonContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonActiveCheck
            // 
            this.buttonActiveCheck.BackColor = System.Drawing.Color.Transparent;
            this.buttonActiveCheck.Checked = true;
            this.buttonActiveCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buttonActiveCheck.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonActiveCheck.Location = new System.Drawing.Point(10, 13);
            this.buttonActiveCheck.Name = "buttonActiveCheck";
            this.buttonActiveCheck.Size = new System.Drawing.Size(13, 13);
            this.buttonActiveCheck.TabIndex = 0;
            // 
            // buttonCode
            // 
            this.buttonCode.AutoEllipsis = true;
            this.buttonCode.ContextMenuStrip = this.MIDIButtonContext;
            this.buttonCode.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.buttonCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCode.Location = new System.Drawing.Point(29, 4);
            this.buttonCode.Name = "buttonCode";
            this.buttonCode.Size = new System.Drawing.Size(169, 30);
            this.buttonCode.TabIndex = 1;
            this.buttonCode.Text = "MIDI Button Code";
            this.buttonCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCode.DoubleClick += new System.EventHandler(this.buttonCode_DoubleClick);
            this.buttonCode.MouseLeave += new System.EventHandler(this.buttonCode_MouseLeave);
            this.buttonCode.MouseHover += new System.EventHandler(this.buttonCode_MouseHover);
            this.buttonCode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonCode_MouseMove);
            // 
            // MIDIButtonContext
            // 
            this.MIDIButtonContext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.MIDIButtonContext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.MIDIButtonContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUp,
            this.moveDown,
            this.toolStripSeparator1,
            this.rename,
            this.remove,
            this.toolStripSeparator2,
            this.showInteraction});
            this.MIDIButtonContext.Name = "darkContextMenu1";
            this.MIDIButtonContext.Size = new System.Drawing.Size(164, 128);
            this.MIDIButtonContext.Opening += new System.ComponentModel.CancelEventHandler(this.MIDIButtonContext_Opening);
            // 
            // moveUp
            // 
            this.moveUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.moveUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(163, 22);
            this.moveUp.Text = "Move Up";
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.moveDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(163, 22);
            this.moveDown.Text = "Move Down";
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // rename
            // 
            this.rename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.rename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(163, 22);
            this.rename.Text = "Rename";
            this.rename.Click += new System.EventHandler(this.rename_Click);
            // 
            // remove
            // 
            this.remove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.remove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(163, 22);
            this.remove.Text = "Remove";
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // showInteraction
            // 
            this.showInteraction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.showInteraction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.showInteraction.Name = "showInteraction";
            this.showInteraction.Size = new System.Drawing.Size(163, 22);
            this.showInteraction.Text = "Show interaction";
            this.showInteraction.Click += new System.EventHandler(this.showInteraction_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.Location = new System.Drawing.Point(204, 5);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Padding = new System.Windows.Forms.Padding(5);
            this.deleteBtn.Size = new System.Drawing.Size(30, 30);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Image = global::MidiArduino.Properties.Resources.settings;
            this.settingsBtn.Location = new System.Drawing.Point(240, 5);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Padding = new System.Windows.Forms.Padding(5);
            this.settingsBtn.Size = new System.Drawing.Size(30, 30);
            this.settingsBtn.TabIndex = 2;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // MIDIButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.ContextMenuStrip = this.MIDIButtonContext;
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.buttonCode);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.buttonActiveCheck);
            this.Name = "MIDIButton";
            this.Size = new System.Drawing.Size(275, 40);
            this.DoubleClick += new System.EventHandler(this.buttonCode_DoubleClick);
            this.MouseLeave += new System.EventHandler(this.buttonCode_MouseLeave);
            this.MouseHover += new System.EventHandler(this.buttonCode_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonCode_MouseMove);
            this.MIDIButtonContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkButton settingsBtn;
        private DarkUI.Controls.DarkButton deleteBtn;
        public DarkUI.Controls.DarkCheckBox buttonActiveCheck;
        public DarkUI.Controls.DarkLabel buttonCode;
        private DarkUI.Controls.DarkContextMenu MIDIButtonContext;
        private System.Windows.Forms.ToolStripMenuItem moveUp;
        private System.Windows.Forms.ToolStripMenuItem moveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem rename;
        private System.Windows.Forms.ToolStripMenuItem remove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showInteraction;
    }
}
