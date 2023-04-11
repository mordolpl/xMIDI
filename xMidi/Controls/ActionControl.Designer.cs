
namespace xMidi.Controls
{
    partial class ActionControl
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
            /*if (actionType.Controls.Count > 0) actionType.Controls[0].Dispose();
            actionType.Dispose();
            actionTypeList.Dispose();
            actionIgniter.Dispose();
            //System.GC.Collect();*/

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
            this.darkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.actionType = new System.Windows.Forms.Panel();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.delayNum = new DarkUI.Controls.DarkNumericUpDown();
            this.actionIngiterBtn = new DarkUI.Controls.DarkButton();
            this.actionTypeList = new DarkUI.Controls.DarkDropdownList();
            this.asyncCheck = new DarkUI.Controls.DarkCheckBox();
            this.darkGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayNum)).BeginInit();
            this.SuspendLayout();
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(279, 5);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(31, 15);
            this.darkLabel2.TabIndex = 4;
            this.darkLabel2.Text = "(ms)";
            // 
            // darkGroupBox1
            // 
            this.darkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.darkGroupBox1.Controls.Add(this.actionType);
            this.darkGroupBox1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkGroupBox1.Location = new System.Drawing.Point(3, 66);
            this.darkGroupBox1.Name = "darkGroupBox1";
            this.darkGroupBox1.Size = new System.Drawing.Size(268, 181);
            this.darkGroupBox1.TabIndex = 5;
            this.darkGroupBox1.TabStop = false;
            this.darkGroupBox1.Text = "Action Type";
            // 
            // actionType
            // 
            this.actionType.Location = new System.Drawing.Point(6, 22);
            this.actionType.Name = "actionType";
            this.actionType.Size = new System.Drawing.Size(256, 153);
            this.actionType.TabIndex = 6;
            // 
            // darkLabel4
            // 
            this.darkLabel4.AutoSize = true;
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(3, 39);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(71, 15);
            this.darkLabel4.TabIndex = 3;
            this.darkLabel4.Text = "Action type:";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(3, 9);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(66, 15);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Delay (ms):";
            // 
            // delayNum
            // 
            this.delayNum.Location = new System.Drawing.Point(79, 7);
            this.delayNum.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.delayNum.Name = "delayNum";
            this.delayNum.Size = new System.Drawing.Size(80, 23);
            this.delayNum.TabIndex = 1;
            // 
            // actionIngiterBtn
            // 
            this.actionIngiterBtn.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionIngiterBtn.Location = new System.Drawing.Point(165, 7);
            this.actionIngiterBtn.Name = "actionIngiterBtn";
            this.actionIngiterBtn.Padding = new System.Windows.Forms.Padding(5);
            this.actionIngiterBtn.Size = new System.Drawing.Size(106, 23);
            this.actionIngiterBtn.TabIndex = 2;
            this.actionIngiterBtn.Text = "Action Igniter";
            this.actionIngiterBtn.Click += new System.EventHandler(this.actionIngiterBtn_Click);
            // 
            // actionTypeList
            // 
            this.actionTypeList.Location = new System.Drawing.Point(79, 36);
            this.actionTypeList.MaxHeight = 225;
            this.actionTypeList.Name = "actionTypeList";
            this.actionTypeList.Size = new System.Drawing.Size(137, 26);
            this.actionTypeList.TabIndex = 0;
            this.actionTypeList.Text = "darkDropdownList1";
            this.actionTypeList.SelectedItemChanged += new System.EventHandler(this.actionTypeList_SelectedItemChanged);
            // 
            // asyncCheck
            // 
            this.asyncCheck.AutoSize = true;
            this.asyncCheck.Location = new System.Drawing.Point(222, 38);
            this.asyncCheck.Name = "asyncCheck";
            this.asyncCheck.Size = new System.Drawing.Size(58, 19);
            this.asyncCheck.TabIndex = 6;
            this.asyncCheck.Text = "Async";
            // 
            // ActionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Controls.Add(this.asyncCheck);
            this.Controls.Add(this.actionTypeList);
            this.Controls.Add(this.actionIngiterBtn);
            this.Controls.Add(this.delayNum);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.darkLabel4);
            this.Controls.Add(this.darkGroupBox1);
            this.Controls.Add(this.darkLabel2);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ActionControl";
            this.Size = new System.Drawing.Size(275, 250);
            this.darkGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.delayNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkGroupBox darkGroupBox1;
        private DarkUI.Controls.DarkLabel darkLabel4;
        public System.Windows.Forms.Panel actionType;
        private DarkUI.Controls.DarkLabel darkLabel1;
        public DarkUI.Controls.DarkNumericUpDown delayNum;
        public DarkUI.Controls.DarkButton actionIngiterBtn;
        public DarkUI.Controls.DarkDropdownList actionTypeList;
        public DarkUI.Controls.DarkCheckBox asyncCheck;
    }
}
