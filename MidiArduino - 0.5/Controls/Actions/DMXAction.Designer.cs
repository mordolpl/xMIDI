
namespace MidiArduino.Controls.Actions
{
    partial class DMXAction
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
            deviceRefresh.Enabled = false;
            deviceRefresh.Stop();

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
            this.components = new System.ComponentModel.Container();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.funcDrop = new DarkUI.Controls.DarkDropdownList();
            this.funcTypeDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.deviceControlDrop = new DarkUI.Controls.DarkDropdownList();
            this.devicesDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.channelNum = new DarkUI.Controls.DarkNumericUpDown();
            this.channelTxt = new DarkUI.Controls.DarkTextBox();
            this.bNum = new DarkUI.Controls.DarkNumericUpDown();
            this.cNum = new DarkUI.Controls.DarkNumericUpDown();
            this.dNum = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.bTxt = new DarkUI.Controls.DarkTextBox();
            this.cTxt = new DarkUI.Controls.DarkTextBox();
            this.dTxt = new DarkUI.Controls.DarkTextBox();
            this.switchBtn = new DarkUI.Controls.DarkButton();
            this.deviceRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.channelNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dNum)).BeginInit();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(3, 70);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(85, 15);
            this.darkLabel1.TabIndex = 7;
            this.darkLabel1.Text = "Time function:";
            // 
            // funcDrop
            // 
            this.funcDrop.Location = new System.Drawing.Point(95, 64);
            this.funcDrop.Name = "funcDrop";
            this.funcDrop.Size = new System.Drawing.Size(86, 26);
            this.funcDrop.TabIndex = 8;
            this.funcDrop.Text = "darkDropdownList1";
            this.funcDrop.SelectedItemChanged += new System.EventHandler(this.funcDrop_SelectedItemChanged);
            // 
            // funcTypeDrop
            // 
            this.funcTypeDrop.Location = new System.Drawing.Point(187, 64);
            this.funcTypeDrop.Name = "funcTypeDrop";
            this.funcTypeDrop.Size = new System.Drawing.Size(66, 26);
            this.funcTypeDrop.TabIndex = 9;
            this.funcTypeDrop.Text = "darkDropdownList1";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(3, 9);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(86, 15);
            this.darkLabel2.TabIndex = 0;
            this.darkLabel2.Text = "Device control:";
            // 
            // deviceControlDrop
            // 
            this.deviceControlDrop.Location = new System.Drawing.Point(95, 3);
            this.deviceControlDrop.Name = "deviceControlDrop";
            this.deviceControlDrop.Size = new System.Drawing.Size(86, 26);
            this.deviceControlDrop.TabIndex = 1;
            this.deviceControlDrop.Text = "darkDropdownList1";
            this.deviceControlDrop.SelectedItemChanged += new System.EventHandler(this.deviceControlDrop_SelectedItemChanged);
            // 
            // devicesDrop
            // 
            this.devicesDrop.Location = new System.Drawing.Point(187, 3);
            this.devicesDrop.Name = "devicesDrop";
            this.devicesDrop.Size = new System.Drawing.Size(66, 26);
            this.devicesDrop.TabIndex = 2;
            this.devicesDrop.Text = "darkDropdownList1";
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(4, 39);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(54, 15);
            this.darkLabel3.TabIndex = 3;
            this.darkLabel3.Text = "Channel:";
            // 
            // channelNum
            // 
            this.channelNum.Location = new System.Drawing.Point(65, 35);
            this.channelNum.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.channelNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.channelNum.Name = "channelNum";
            this.channelNum.Size = new System.Drawing.Size(76, 23);
            this.channelNum.TabIndex = 4;
            this.channelNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // channelTxt
            // 
            this.channelTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.channelTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.channelTxt.Enabled = false;
            this.channelTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.channelTxt.Location = new System.Drawing.Point(187, 35);
            this.channelTxt.Name = "channelTxt";
            this.channelTxt.Size = new System.Drawing.Size(66, 23);
            this.channelTxt.TabIndex = 6;
            // 
            // bNum
            // 
            this.bNum.Location = new System.Drawing.Point(26, 96);
            this.bNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bNum.Name = "bNum";
            this.bNum.Size = new System.Drawing.Size(53, 23);
            this.bNum.TabIndex = 11;
            // 
            // cNum
            // 
            this.cNum.Location = new System.Drawing.Point(113, 96);
            this.cNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.cNum.Name = "cNum";
            this.cNum.Size = new System.Drawing.Size(53, 23);
            this.cNum.TabIndex = 13;
            // 
            // dNum
            // 
            this.dNum.Location = new System.Drawing.Point(200, 96);
            this.dNum.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.dNum.Name = "dNum";
            this.dNum.Size = new System.Drawing.Size(53, 23);
            this.dNum.TabIndex = 15;
            // 
            // darkLabel4
            // 
            this.darkLabel4.AutoSize = true;
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(6, 100);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(17, 15);
            this.darkLabel4.TabIndex = 10;
            this.darkLabel4.Text = "b:";
            // 
            // darkLabel5
            // 
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(94, 100);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(16, 15);
            this.darkLabel5.TabIndex = 12;
            this.darkLabel5.Text = "c:";
            // 
            // darkLabel6
            // 
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(180, 100);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(17, 15);
            this.darkLabel6.TabIndex = 14;
            this.darkLabel6.Text = "d:";
            // 
            // bTxt
            // 
            this.bTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.bTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.bTxt.Location = new System.Drawing.Point(9, 125);
            this.bTxt.Name = "bTxt";
            this.bTxt.Size = new System.Drawing.Size(70, 23);
            this.bTxt.TabIndex = 16;
            // 
            // cTxt
            // 
            this.cTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.cTxt.Location = new System.Drawing.Point(96, 125);
            this.cTxt.Name = "cTxt";
            this.cTxt.Size = new System.Drawing.Size(70, 23);
            this.cTxt.TabIndex = 17;
            // 
            // dTxt
            // 
            this.dTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.dTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dTxt.Location = new System.Drawing.Point(183, 125);
            this.dTxt.Name = "dTxt";
            this.dTxt.Size = new System.Drawing.Size(70, 23);
            this.dTxt.TabIndex = 18;
            // 
            // switchBtn
            // 
            this.switchBtn.Location = new System.Drawing.Point(147, 35);
            this.switchBtn.Name = "switchBtn";
            this.switchBtn.Padding = new System.Windows.Forms.Padding(5);
            this.switchBtn.Size = new System.Drawing.Size(34, 23);
            this.switchBtn.TabIndex = 5;
            this.switchBtn.Text = "<-";
            this.switchBtn.Click += new System.EventHandler(this.switchBtn_Click);
            // 
            // deviceRefresh
            // 
            this.deviceRefresh.Interval = 1500;
            this.deviceRefresh.Tick += new System.EventHandler(this.deviceRefresh_Tick);
            // 
            // DMXAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.switchBtn);
            this.Controls.Add(this.dTxt);
            this.Controls.Add(this.cTxt);
            this.Controls.Add(this.bTxt);
            this.Controls.Add(this.darkLabel6);
            this.Controls.Add(this.darkLabel5);
            this.Controls.Add(this.darkLabel4);
            this.Controls.Add(this.dNum);
            this.Controls.Add(this.cNum);
            this.Controls.Add(this.bNum);
            this.Controls.Add(this.channelTxt);
            this.Controls.Add(this.channelNum);
            this.Controls.Add(this.darkLabel3);
            this.Controls.Add(this.devicesDrop);
            this.Controls.Add(this.deviceControlDrop);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.funcTypeDrop);
            this.Controls.Add(this.funcDrop);
            this.Controls.Add(this.darkLabel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DMXAction";
            this.Size = new System.Drawing.Size(256, 153);
            ((System.ComponentModel.ISupportInitialize)(this.channelNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkLabel darkLabel6;
        public DarkUI.Controls.DarkButton switchBtn;
        private MicroLibrary.MicroTimer microTimer;
        private System.Windows.Forms.Timer deviceRefresh;
        public DarkUI.Controls.DarkDropdownList deviceControlDrop;
        public DarkUI.Controls.DarkDropdownList devicesDrop;
        public DarkUI.Controls.DarkNumericUpDown channelNum;
        public DarkUI.Controls.DarkTextBox channelTxt;
        public DarkUI.Controls.DarkDropdownList funcDrop;
        public DarkUI.Controls.DarkDropdownList funcTypeDrop;
        public DarkUI.Controls.DarkNumericUpDown bNum;
        public DarkUI.Controls.DarkNumericUpDown cNum;
        public DarkUI.Controls.DarkNumericUpDown dNum;
        public DarkUI.Controls.DarkTextBox bTxt;
        public DarkUI.Controls.DarkTextBox cTxt;
        public DarkUI.Controls.DarkTextBox dTxt;
    }
}
