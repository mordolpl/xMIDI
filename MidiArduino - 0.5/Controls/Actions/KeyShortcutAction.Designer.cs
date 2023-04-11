
namespace MidiArduino.Controls.Actions
{
    partial class KeyShortcutAction
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
            this.keyShortcut = new DarkUI.Controls.DarkLabel();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(95, 121);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(132, 15);
            this.darkLabel1.TabIndex = 2;
            this.darkLabel1.Text = "Click keyboard shortcut";
            // 
            // keyShortcut
            // 
            this.keyShortcut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.keyShortcut.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyShortcut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.keyShortcut.Location = new System.Drawing.Point(27, 17);
            this.keyShortcut.Name = "keyShortcut";
            this.keyShortcut.Size = new System.Drawing.Size(200, 100);
            this.keyShortcut.TabIndex = 0;
            this.keyShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.keyShortcut.Click += new System.EventHandler(this.keyShortcut_Click);
            // 
            // darkButton1
            // 
            this.darkButton1.Location = new System.Drawing.Point(28, 120);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Padding = new System.Windows.Forms.Padding(5);
            this.darkButton1.Size = new System.Drawing.Size(61, 18);
            this.darkButton1.TabIndex = 1;
            this.darkButton1.Text = "More...";
            this.darkButton1.Visible = false;
            // 
            // KeyShortcutAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.darkButton1);
            this.Controls.Add(this.keyShortcut);
            this.Controls.Add(this.darkLabel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "KeyShortcutAction";
            this.Size = new System.Drawing.Size(256, 153);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyShortcutAction_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkButton darkButton1;
        public DarkUI.Controls.DarkLabel keyShortcut;
    }
}
