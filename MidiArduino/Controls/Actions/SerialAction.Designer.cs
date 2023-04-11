
namespace xMidi.Controls.Actions
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
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.baudRateNum = new DarkUI.Controls.DarkNumericUpDown();
            this.stringTxt = new DarkUI.Controls.DarkTextBox();
            this.serialPortDrop = new DarkUI.Controls.DarkDropdownList();
            this.deviceControlDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.parityDrop = new DarkUI.Controls.DarkDropdownList();
            this.dataBitsNum = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.stopBitsDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.handshakeDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel7 = new DarkUI.Controls.DarkLabel();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.baudRateNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBitsNum)).BeginInit();
            this.SuspendLayout();
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(3, 40);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(63, 15);
            this.darkLabel2.TabIndex = 3;
            this.darkLabel2.Text = "Baud Rate:";
            // 
            // baudRateNum
            // 
            this.baudRateNum.Location = new System.Drawing.Point(72, 36);
            this.baudRateNum.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.baudRateNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.baudRateNum.Name = "baudRateNum";
            this.baudRateNum.Size = new System.Drawing.Size(63, 23);
            this.baudRateNum.TabIndex = 4;
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
            this.stringTxt.Location = new System.Drawing.Point(82, 124);
            this.stringTxt.Multiline = true;
            this.stringTxt.Name = "stringTxt";
            this.stringTxt.Size = new System.Drawing.Size(171, 24);
            this.stringTxt.TabIndex = 14;
            // 
            // serialPortDrop
            // 
            this.serialPortDrop.Location = new System.Drawing.Point(187, 6);
            this.serialPortDrop.Name = "serialPortDrop";
            this.serialPortDrop.Size = new System.Drawing.Size(66, 26);
            this.serialPortDrop.TabIndex = 2;
            this.serialPortDrop.Text = "darkDropdownList1";
            // 
            // deviceControlDrop
            // 
            this.deviceControlDrop.Location = new System.Drawing.Point(95, 6);
            this.deviceControlDrop.Name = "deviceControlDrop";
            this.deviceControlDrop.Size = new System.Drawing.Size(86, 26);
            this.deviceControlDrop.TabIndex = 1;
            this.deviceControlDrop.Text = "darkDropdownList1";
            this.deviceControlDrop.SelectedItemChanged += new System.EventHandler(this.deviceControlDrop_SelectedItemChanged);
            // 
            // darkLabel4
            // 
            this.darkLabel4.AutoSize = true;
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(3, 12);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(86, 15);
            this.darkLabel4.TabIndex = 0;
            this.darkLabel4.Text = "Device control:";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(141, 41);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(40, 15);
            this.darkLabel1.TabIndex = 5;
            this.darkLabel1.Text = "Parity:";
            // 
            // parityDrop
            // 
            this.parityDrop.Location = new System.Drawing.Point(187, 36);
            this.parityDrop.Name = "parityDrop";
            this.parityDrop.Size = new System.Drawing.Size(66, 26);
            this.parityDrop.TabIndex = 6;
            this.parityDrop.Text = "darkDropdownList1";
            // 
            // dataBitsNum
            // 
            this.dataBitsNum.Location = new System.Drawing.Point(65, 65);
            this.dataBitsNum.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.dataBitsNum.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.dataBitsNum.Name = "dataBitsNum";
            this.dataBitsNum.Size = new System.Drawing.Size(63, 23);
            this.dataBitsNum.TabIndex = 8;
            this.dataBitsNum.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // darkLabel5
            // 
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(3, 69);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(56, 15);
            this.darkLabel5.TabIndex = 7;
            this.darkLabel5.Text = "Data bits:";
            // 
            // stopBitsDrop
            // 
            this.stopBitsDrop.Location = new System.Drawing.Point(187, 65);
            this.stopBitsDrop.Name = "stopBitsDrop";
            this.stopBitsDrop.Size = new System.Drawing.Size(66, 26);
            this.stopBitsDrop.TabIndex = 10;
            this.stopBitsDrop.Text = "darkDropdownList1";
            // 
            // darkLabel6
            // 
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(132, 69);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(56, 15);
            this.darkLabel6.TabIndex = 9;
            this.darkLabel6.Text = "Stop bits:";
            // 
            // handshakeDrop
            // 
            this.handshakeDrop.Location = new System.Drawing.Point(72, 94);
            this.handshakeDrop.Name = "handshakeDrop";
            this.handshakeDrop.Size = new System.Drawing.Size(181, 26);
            this.handshakeDrop.TabIndex = 12;
            this.handshakeDrop.Text = "darkDropdownList1";
            // 
            // darkLabel7
            // 
            this.darkLabel7.AutoSize = true;
            this.darkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel7.Location = new System.Drawing.Point(3, 99);
            this.darkLabel7.Name = "darkLabel7";
            this.darkLabel7.Size = new System.Drawing.Size(69, 15);
            this.darkLabel7.TabIndex = 11;
            this.darkLabel7.Text = "Handshake:";
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(3, 128);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(73, 15);
            this.darkLabel3.TabIndex = 13;
            this.darkLabel3.Text = "Text to send:";
            // 
            // SerialAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.stringTxt);
            this.Controls.Add(this.darkLabel3);
            this.Controls.Add(this.handshakeDrop);
            this.Controls.Add(this.darkLabel7);
            this.Controls.Add(this.stopBitsDrop);
            this.Controls.Add(this.darkLabel6);
            this.Controls.Add(this.dataBitsNum);
            this.Controls.Add(this.darkLabel5);
            this.Controls.Add(this.parityDrop);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.serialPortDrop);
            this.Controls.Add(this.deviceControlDrop);
            this.Controls.Add(this.darkLabel4);
            this.Controls.Add(this.baudRateNum);
            this.Controls.Add(this.darkLabel2);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SerialAction";
            this.Size = new System.Drawing.Size(256, 153);
            ((System.ComponentModel.ISupportInitialize)(this.baudRateNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBitsNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkLabel darkLabel2;
        public DarkUI.Controls.DarkNumericUpDown baudRateNum;
        public DarkUI.Controls.DarkTextBox stringTxt;
        public DarkUI.Controls.DarkDropdownList serialPortDrop;
        public DarkUI.Controls.DarkDropdownList deviceControlDrop;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private DarkUI.Controls.DarkLabel darkLabel1;
        public DarkUI.Controls.DarkDropdownList parityDrop;
        public DarkUI.Controls.DarkNumericUpDown dataBitsNum;
        private DarkUI.Controls.DarkLabel darkLabel5;
        public DarkUI.Controls.DarkDropdownList stopBitsDrop;
        private DarkUI.Controls.DarkLabel darkLabel6;
        public DarkUI.Controls.DarkDropdownList handshakeDrop;
        private DarkUI.Controls.DarkLabel darkLabel7;
        private DarkUI.Controls.DarkLabel darkLabel3;
    }
}
