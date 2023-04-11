
namespace xMidi.Controls.Actions
{
    partial class TemplatesAction
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
            this.templatesDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.infoTxt = new DarkUI.Controls.DarkLabel();
            this.SuspendLayout();
            // 
            // templatesDrop
            // 
            this.templatesDrop.Location = new System.Drawing.Point(69, 56);
            this.templatesDrop.Name = "templatesDrop";
            this.templatesDrop.Size = new System.Drawing.Size(184, 26);
            this.templatesDrop.TabIndex = 1;
            this.templatesDrop.Text = "darkDropdownList1";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(4, 61);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(59, 15);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Template:";
            // 
            // infoTxt
            // 
            this.infoTxt.AutoSize = true;
            this.infoTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.infoTxt.Location = new System.Drawing.Point(69, 23);
            this.infoTxt.Name = "infoTxt";
            this.infoTxt.Size = new System.Drawing.Size(186, 30);
            this.infoTxt.TabIndex = 2;
            this.infoTxt.Text = "You should select Control Change\r\nor NoteOn/Off Event to use!";
            this.infoTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infoTxt.Visible = false;
            // 
            // TemplatesAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.infoTxt);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.templatesDrop);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TemplatesAction";
            this.Size = new System.Drawing.Size(256, 153);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkLabel darkLabel1;
        public DarkUI.Controls.DarkDropdownList templatesDrop;
        private DarkUI.Controls.DarkLabel infoTxt;
    }
}
