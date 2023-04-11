
namespace xMidi.Controls.Actions
{
    partial class MIDIAction
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
            this.midiOutDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.channelNum = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.valueNum = new DarkUI.Controls.DarkNumericUpDown();
            this.valueTxt = new DarkUI.Controls.DarkTextBox();
            this.midiEventDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.switchBtn = new DarkUI.Controls.DarkButton();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.nameValue = new DarkUI.Controls.DarkNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.channelNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameValue)).BeginInit();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(12, 8);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(73, 15);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "MIDI Device:";
            // 
            // midiOutDrop
            // 
            this.midiOutDrop.Location = new System.Drawing.Point(91, 3);
            this.midiOutDrop.Name = "midiOutDrop";
            this.midiOutDrop.Size = new System.Drawing.Size(149, 26);
            this.midiOutDrop.TabIndex = 1;
            this.midiOutDrop.Text = "darkDropdownList1";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(12, 69);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(54, 15);
            this.darkLabel2.TabIndex = 4;
            this.darkLabel2.Text = "Channel:";
            // 
            // channelNum
            // 
            this.channelNum.Location = new System.Drawing.Point(91, 65);
            this.channelNum.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.channelNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.channelNum.Name = "channelNum";
            this.channelNum.Size = new System.Drawing.Size(149, 23);
            this.channelNum.TabIndex = 5;
            this.channelNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(12, 128);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(38, 15);
            this.darkLabel3.TabIndex = 8;
            this.darkLabel3.Text = "Value:";
            // 
            // valueNum
            // 
            this.valueNum.Location = new System.Drawing.Point(58, 124);
            this.valueNum.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.valueNum.Name = "valueNum";
            this.valueNum.Size = new System.Drawing.Size(61, 23);
            this.valueNum.TabIndex = 9;
            this.valueNum.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            // 
            // valueTxt
            // 
            this.valueTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.valueTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.valueTxt.Enabled = false;
            this.valueTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.valueTxt.Location = new System.Drawing.Point(165, 124);
            this.valueTxt.Multiline = true;
            this.valueTxt.Name = "valueTxt";
            this.valueTxt.Size = new System.Drawing.Size(75, 23);
            this.valueTxt.TabIndex = 11;
            // 
            // midiEventDrop
            // 
            this.midiEventDrop.Location = new System.Drawing.Point(91, 33);
            this.midiEventDrop.Name = "midiEventDrop";
            this.midiEventDrop.Size = new System.Drawing.Size(149, 26);
            this.midiEventDrop.TabIndex = 3;
            this.midiEventDrop.Text = "darkDropdownList1";
            // 
            // darkLabel4
            // 
            this.darkLabel4.AutoSize = true;
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(12, 38);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(67, 15);
            this.darkLabel4.TabIndex = 2;
            this.darkLabel4.Text = "MIDI Event:";
            // 
            // switchBtn
            // 
            this.switchBtn.Location = new System.Drawing.Point(125, 124);
            this.switchBtn.Name = "switchBtn";
            this.switchBtn.Padding = new System.Windows.Forms.Padding(5);
            this.switchBtn.Size = new System.Drawing.Size(34, 23);
            this.switchBtn.TabIndex = 10;
            this.switchBtn.Text = "<-";
            this.switchBtn.Click += new System.EventHandler(this.switchBtn_Click);
            // 
            // darkLabel5
            // 
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(12, 99);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(42, 15);
            this.darkLabel5.TabIndex = 6;
            this.darkLabel5.Text = "Name:";
            // 
            // nameValue
            // 
            this.nameValue.Location = new System.Drawing.Point(91, 94);
            this.nameValue.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.nameValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(149, 23);
            this.nameValue.TabIndex = 7;
            this.nameValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MIDIAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.nameValue);
            this.Controls.Add(this.darkLabel5);
            this.Controls.Add(this.switchBtn);
            this.Controls.Add(this.darkLabel4);
            this.Controls.Add(this.midiEventDrop);
            this.Controls.Add(this.valueTxt);
            this.Controls.Add(this.valueNum);
            this.Controls.Add(this.darkLabel3);
            this.Controls.Add(this.channelNum);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.midiOutDrop);
            this.Controls.Add(this.darkLabel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MIDIAction";
            this.Size = new System.Drawing.Size(256, 153);
            ((System.ComponentModel.ISupportInitialize)(this.channelNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkLabel darkLabel3;
        public DarkUI.Controls.DarkDropdownList midiOutDrop;
        public DarkUI.Controls.DarkNumericUpDown channelNum;
        public DarkUI.Controls.DarkNumericUpDown valueNum;
        public DarkUI.Controls.DarkTextBox valueTxt;
        private DarkUI.Controls.DarkLabel darkLabel4;
        public DarkUI.Controls.DarkButton switchBtn;
        private DarkUI.Controls.DarkLabel darkLabel5;
        public DarkUI.Controls.DarkDropdownList midiEventDrop;
        public DarkUI.Controls.DarkNumericUpDown nameValue;
    }
}
