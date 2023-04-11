namespace xMidi.Forms
{
    partial class BindProperties
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
            pictureBox1.Image.Dispose();
            pictureBox1.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BindProperties));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameTxt = new DarkUI.Controls.DarkLabel();
            this.bgColorPanel = new System.Windows.Forms.Panel();
            this.interactColorPanel = new System.Windows.Forms.Panel();
            this.saveBtn = new DarkUI.Controls.DarkButton();
            this.discardBtn = new DarkUI.Controls.DarkButton();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.asyncCheck = new DarkUI.Controls.DarkCheckBox();
            this.runOnStartCheck = new DarkUI.Controls.DarkCheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.renameBtn = new DarkUI.Controls.DarkButton();
            this.rebindBtn = new DarkUI.Controls.DarkButton();
            this.fontColorPanel = new System.Windows.Forms.Panel();
            this.hoverColorPanel = new System.Windows.Forms.Panel();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.channelDrop = new DarkUI.Controls.DarkDropdownList();
            this.eventDrop = new DarkUI.Controls.DarkDropdownList();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(80, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nameTxt.Location = new System.Drawing.Point(46, 140);
            this.nameTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(198, 47);
            this.nameTxt.TabIndex = 1;
            this.nameTxt.Text = "NoteOn C0";
            this.nameTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bgColorPanel
            // 
            this.bgColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bgColorPanel.Location = new System.Drawing.Point(12, 340);
            this.bgColorPanel.Name = "bgColorPanel";
            this.bgColorPanel.Size = new System.Drawing.Size(64, 27);
            this.bgColorPanel.TabIndex = 2;
            this.bgColorPanel.Click += new System.EventHandler(this.bgColorPanel_Click);
            // 
            // interactColorPanel
            // 
            this.interactColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.interactColorPanel.Location = new System.Drawing.Point(208, 340);
            this.interactColorPanel.Name = "interactColorPanel";
            this.interactColorPanel.Size = new System.Drawing.Size(64, 27);
            this.interactColorPanel.TabIndex = 3;
            this.interactColorPanel.Click += new System.EventHandler(this.interactColorPanel_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(204, 387);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Padding = new System.Windows.Forms.Padding(5);
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // discardBtn
            // 
            this.discardBtn.Location = new System.Drawing.Point(123, 387);
            this.discardBtn.Name = "discardBtn";
            this.discardBtn.Padding = new System.Windows.Forms.Padding(5);
            this.discardBtn.Size = new System.Drawing.Size(75, 23);
            this.discardBtn.TabIndex = 5;
            this.discardBtn.Text = "Discard";
            this.discardBtn.Click += new System.EventHandler(this.discardBtn_Click);
            // 
            // darkLabel2
            // 
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(7, 301);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(75, 36);
            this.darkLabel2.TabIndex = 6;
            this.darkLabel2.Text = "Background color:";
            this.darkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.panel4.Location = new System.Drawing.Point(0, 381);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(284, 34);
            this.panel4.TabIndex = 7;
            // 
            // darkLabel3
            // 
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(105, 301);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(75, 36);
            this.darkLabel3.TabIndex = 8;
            this.darkLabel3.Text = "Hover color:";
            this.darkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkLabel4
            // 
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(203, 301);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(75, 36);
            this.darkLabel4.TabIndex = 9;
            this.darkLabel4.Text = "Interact color:";
            this.darkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // asyncCheck
            // 
            this.asyncCheck.AutoSize = true;
            this.asyncCheck.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asyncCheck.Location = new System.Drawing.Point(12, 201);
            this.asyncCheck.Name = "asyncCheck";
            this.asyncCheck.Size = new System.Drawing.Size(60, 21);
            this.asyncCheck.TabIndex = 10;
            this.asyncCheck.Text = "Async";
            this.asyncCheck.CheckedChanged += new System.EventHandler(this.asyncCheck_CheckedChanged);
            // 
            // runOnStartCheck
            // 
            this.runOnStartCheck.AutoSize = true;
            this.runOnStartCheck.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runOnStartCheck.Location = new System.Drawing.Point(12, 228);
            this.runOnStartCheck.Name = "runOnStartCheck";
            this.runOnStartCheck.Size = new System.Drawing.Size(98, 21);
            this.runOnStartCheck.TabIndex = 11;
            this.runOnStartCheck.Text = "Run on start";
            this.runOnStartCheck.CheckedChanged += new System.EventHandler(this.runOnStartCheck_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(75)))));
            this.panel5.Location = new System.Drawing.Point(12, 259);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 2);
            this.panel5.TabIndex = 12;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(75)))));
            this.panel6.Location = new System.Drawing.Point(12, 296);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(260, 2);
            this.panel6.TabIndex = 13;
            // 
            // renameBtn
            // 
            this.renameBtn.Location = new System.Drawing.Point(130, 267);
            this.renameBtn.Name = "renameBtn";
            this.renameBtn.Padding = new System.Windows.Forms.Padding(5);
            this.renameBtn.Size = new System.Drawing.Size(68, 23);
            this.renameBtn.TabIndex = 14;
            this.renameBtn.Text = "Rename";
            this.renameBtn.Click += new System.EventHandler(this.renameBtn_Click);
            // 
            // rebindBtn
            // 
            this.rebindBtn.Location = new System.Drawing.Point(204, 267);
            this.rebindBtn.Name = "rebindBtn";
            this.rebindBtn.Padding = new System.Windows.Forms.Padding(5);
            this.rebindBtn.Size = new System.Drawing.Size(68, 23);
            this.rebindBtn.TabIndex = 15;
            this.rebindBtn.Text = "Rebind";
            this.rebindBtn.Click += new System.EventHandler(this.rebindBtn_Click);
            // 
            // fontColorPanel
            // 
            this.fontColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fontColorPanel.Location = new System.Drawing.Point(76, 267);
            this.fontColorPanel.Name = "fontColorPanel";
            this.fontColorPanel.Size = new System.Drawing.Size(48, 23);
            this.fontColorPanel.TabIndex = 4;
            this.fontColorPanel.Click += new System.EventHandler(this.fontColorPanel_Click);
            // 
            // hoverColorPanel
            // 
            this.hoverColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hoverColorPanel.Location = new System.Drawing.Point(110, 340);
            this.hoverColorPanel.Name = "hoverColorPanel";
            this.hoverColorPanel.Size = new System.Drawing.Size(64, 27);
            this.hoverColorPanel.TabIndex = 3;
            this.hoverColorPanel.Click += new System.EventHandler(this.hoverColorPanel_Click);
            // 
            // darkLabel1
            // 
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(9, 267);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(87, 23);
            this.darkLabel1.TabIndex = 16;
            this.darkLabel1.Text = "Font Color:";
            this.darkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // channelDrop
            // 
            this.channelDrop.Location = new System.Drawing.Point(191, 197);
            this.channelDrop.Name = "channelDrop";
            this.channelDrop.Size = new System.Drawing.Size(81, 23);
            this.channelDrop.TabIndex = 17;
            this.channelDrop.Text = "darkDropdownList1";
            this.channelDrop.SelectedItemChanged += new System.EventHandler(this.channelDrop_SelectedItemChanged);
            // 
            // eventDrop
            // 
            this.eventDrop.Location = new System.Drawing.Point(191, 226);
            this.eventDrop.Name = "eventDrop";
            this.eventDrop.Size = new System.Drawing.Size(81, 23);
            this.eventDrop.TabIndex = 18;
            this.eventDrop.Text = "darkDropdownList2";
            this.eventDrop.SelectedItemChanged += new System.EventHandler(this.eventDrop_SelectedItemChanged);
            // 
            // darkLabel5
            // 
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(134, 201);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(54, 15);
            this.darkLabel5.TabIndex = 19;
            this.darkLabel5.Text = "Channel:";
            // 
            // darkLabel6
            // 
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(121, 231);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(67, 15);
            this.darkLabel6.TabIndex = 20;
            this.darkLabel6.Text = "MIDI Event:";
            // 
            // BindProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(284, 415);
            this.Controls.Add(this.darkLabel6);
            this.Controls.Add(this.darkLabel5);
            this.Controls.Add(this.eventDrop);
            this.Controls.Add(this.channelDrop);
            this.Controls.Add(this.fontColorPanel);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.rebindBtn);
            this.Controls.Add(this.renameBtn);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.runOnStartCheck);
            this.Controls.Add(this.asyncCheck);
            this.Controls.Add(this.darkLabel4);
            this.Controls.Add(this.darkLabel3);
            this.Controls.Add(this.discardBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.darkLabel2);
            this.Controls.Add(this.interactColorPanel);
            this.Controls.Add(this.hoverColorPanel);
            this.Controls.Add(this.bgColorPanel);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "xMIDI - Bind Properties";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DarkUI.Controls.DarkLabel nameTxt;
        private System.Windows.Forms.Panel bgColorPanel;
        private System.Windows.Forms.Panel interactColorPanel;
        private DarkUI.Controls.DarkButton saveBtn;
        private DarkUI.Controls.DarkButton discardBtn;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private System.Windows.Forms.Panel panel4;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private DarkUI.Controls.DarkCheckBox asyncCheck;
        private DarkUI.Controls.DarkCheckBox runOnStartCheck;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private DarkUI.Controls.DarkButton renameBtn;
        private DarkUI.Controls.DarkButton rebindBtn;
        private System.Windows.Forms.Panel fontColorPanel;
        private System.Windows.Forms.Panel hoverColorPanel;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkDropdownList channelDrop;
        private DarkUI.Controls.DarkDropdownList eventDrop;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkLabel darkLabel6;
    }
}