
namespace xMidi.Forms
{
    partial class ActionIgniter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionIgniter));
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.conditionalDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.conTxt = new DarkUI.Controls.DarkTextBox();
            this.specificNum = new DarkUI.Controls.DarkNumericUpDown();
            this.darkGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.specificNum)).BeginInit();
            this.SuspendLayout();
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(12, 14);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(101, 15);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Value conditional:";
            // 
            // conditionalDrop
            // 
            this.conditionalDrop.Location = new System.Drawing.Point(119, 9);
            this.conditionalDrop.Name = "conditionalDrop";
            this.conditionalDrop.Size = new System.Drawing.Size(149, 26);
            this.conditionalDrop.TabIndex = 1;
            this.conditionalDrop.Text = "darkDropdownList1";
            this.conditionalDrop.SelectedItemChanged += new System.EventHandler(this.conditionalDrop_SelectedItemChanged);
            // 
            // darkGroupBox1
            // 
            this.darkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.darkGroupBox1.Controls.Add(this.darkLabel3);
            this.darkGroupBox1.Controls.Add(this.darkLabel2);
            this.darkGroupBox1.Controls.Add(this.conTxt);
            this.darkGroupBox1.Controls.Add(this.specificNum);
            this.darkGroupBox1.Location = new System.Drawing.Point(15, 41);
            this.darkGroupBox1.Name = "darkGroupBox1";
            this.darkGroupBox1.Size = new System.Drawing.Size(253, 118);
            this.darkGroupBox1.TabIndex = 2;
            this.darkGroupBox1.TabStop = false;
            this.darkGroupBox1.Text = "Condition settings";
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(16, 72);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(63, 15);
            this.darkLabel3.TabIndex = 5;
            this.darkLabel3.Text = "Condition:";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(16, 44);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(82, 15);
            this.darkLabel2.TabIndex = 3;
            this.darkLabel2.Text = "Specific value:";
            // 
            // conTxt
            // 
            this.conTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.conTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conTxt.Enabled = false;
            this.conTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.conTxt.Location = new System.Drawing.Point(85, 70);
            this.conTxt.Name = "conTxt";
            this.conTxt.Size = new System.Drawing.Size(151, 23);
            this.conTxt.TabIndex = 6;
            // 
            // specificNum
            // 
            this.specificNum.Enabled = false;
            this.specificNum.Location = new System.Drawing.Point(107, 41);
            this.specificNum.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.specificNum.Name = "specificNum";
            this.specificNum.Size = new System.Drawing.Size(129, 23);
            this.specificNum.TabIndex = 4;
            // 
            // ActionIgniter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(280, 167);
            this.Controls.Add(this.darkGroupBox1);
            this.Controls.Add(this.conditionalDrop);
            this.Controls.Add(this.darkLabel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionIgniter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "xMIDI - Action Igniter";
            this.darkGroupBox1.ResumeLayout(false);
            this.darkGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.specificNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkGroupBox darkGroupBox1;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkLabel darkLabel2;
        public DarkUI.Controls.DarkDropdownList conditionalDrop;
        public DarkUI.Controls.DarkNumericUpDown specificNum;
        public DarkUI.Controls.DarkTextBox conTxt;
    }
}