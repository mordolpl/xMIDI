
namespace MidiArduino.Controls.Actions
{
    partial class SerialAction
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
            this.serialPortDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.baudRateNum = new DarkUI.Controls.DarkNumericUpDown();
            this.stringTxt = new DarkUI.Controls.DarkTextBox();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.baudRateNum)).BeginInit();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(12, 8);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(63, 15);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Serial Port:";
            // 
            // serialPortDrop
            // 
            this.serialPortDrop.Location = new System.Drawing.Point(81, 3);
            this.serialPortDrop.Name = "serialPortDrop";
            this.serialPortDrop.Size = new System.Drawing.Size(159, 26);
            this.serialPortDrop.TabIndex = 1;
            this.serialPortDrop.Text = "darkDropdownList1";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(12, 35);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(63, 15);
            this.darkLabel2.TabIndex = 2;
            this.darkLabel2.Text = "Baud Rate:";
            // 
            // baudRateNum
            // 
            this.baudRateNum.Location = new System.Drawing.Point(81, 33);
            this.baudRateNum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.baudRateNum.Name = "baudRateNum";
            this.baudRateNum.Size = new System.Drawing.Size(159, 23);
            this.baudRateNum.TabIndex = 3;
            this.baudRateNum.Value = new decimal(new int[] {
            9600,
            0,
            0,
            0});
            // 
            // stringTxt
            // 
            this.stringTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.stringTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stringTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.stringTxt.Location = new System.Drawing.Point(15, 81);
            this.stringTxt.Multiline = true;
            this.stringTxt.Name = "stringTxt";
            this.stringTxt.Size = new System.Drawing.Size(225, 61);
            this.stringTxt.TabIndex = 5;
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(12, 63);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(63, 15);
            this.darkLabel3.TabIndex = 4;
            this.darkLabel3.Text = "String text:";
            // 
            // SerialAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.darkLabel3);
            this.Controls.Add(this.stringTxt);
            this.Controls.Add(this.baudRateNum);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.serialPortDrop);
            this.Controls.Add(this.darkLabel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SerialAction";
            this.Size = new System.Drawing.Size(256, 153);
            ((System.ComponentModel.ISupportInitialize)(this.baudRateNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkLabel darkLabel3;
        public DarkUI.Controls.DarkDropdownList serialPortDrop;
        public DarkUI.Controls.DarkNumericUpDown baudRateNum;
        public DarkUI.Controls.DarkTextBox stringTxt;
    }
}
