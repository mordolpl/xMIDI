
namespace xMidi.Forms
{
    partial class ActionManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionManager));
            this.actionList = new DarkUI.Controls.DarkListView();
            this.darkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.nameTxt = new DarkUI.Controls.DarkTextBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.downBtn = new DarkUI.Controls.DarkButton();
            this.upBtn = new DarkUI.Controls.DarkButton();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.addActionBtn = new DarkUI.Controls.DarkButton();
            this.removeActionBtn = new DarkUI.Controls.DarkButton();
            this.darkGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionList
            // 
            this.actionList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.actionList.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionList.Location = new System.Drawing.Point(12, 20);
            this.actionList.Name = "actionList";
            this.actionList.Size = new System.Drawing.Size(202, 263);
            this.actionList.TabIndex = 0;
            this.actionList.Text = "darkListView1";
            this.actionList.SelectedIndicesChanged += new System.EventHandler(this.actionList_SelectedIndicesChanged);
            this.actionList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.actionList_KeyDown);
            // 
            // darkGroupBox1
            // 
            this.darkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.darkGroupBox1.Controls.Add(this.nameTxt);
            this.darkGroupBox1.Controls.Add(this.darkLabel1);
            this.darkGroupBox1.Controls.Add(this.downBtn);
            this.darkGroupBox1.Controls.Add(this.upBtn);
            this.darkGroupBox1.Controls.Add(this.actionPanel);
            this.darkGroupBox1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkGroupBox1.Location = new System.Drawing.Point(220, 12);
            this.darkGroupBox1.Name = "darkGroupBox1";
            this.darkGroupBox1.Size = new System.Drawing.Size(287, 301);
            this.darkGroupBox1.TabIndex = 3;
            this.darkGroupBox1.TabStop = false;
            this.darkGroupBox1.Text = "Action settings";
            // 
            // nameTxt
            // 
            this.nameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTxt.Enabled = false;
            this.nameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.nameTxt.Location = new System.Drawing.Point(148, 18);
            this.nameTxt.MaxLength = 32;
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(133, 23);
            this.nameTxt.TabIndex = 7;
            this.nameTxt.TextChanged += new System.EventHandler(this.nameTxt_TextChanged);
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(64, 22);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(78, 15);
            this.darkLabel1.TabIndex = 6;
            this.darkLabel1.Text = "Action name:";
            // 
            // downBtn
            // 
            this.downBtn.Location = new System.Drawing.Point(35, 18);
            this.downBtn.Name = "downBtn";
            this.downBtn.Padding = new System.Windows.Forms.Padding(5);
            this.downBtn.Size = new System.Drawing.Size(23, 23);
            this.downBtn.TabIndex = 5;
            this.downBtn.Text = "˅";
            this.downBtn.Click += new System.EventHandler(this.downBtn_Click);
            // 
            // upBtn
            // 
            this.upBtn.Location = new System.Drawing.Point(6, 18);
            this.upBtn.Name = "upBtn";
            this.upBtn.Padding = new System.Windows.Forms.Padding(5);
            this.upBtn.Size = new System.Drawing.Size(23, 23);
            this.upBtn.TabIndex = 4;
            this.upBtn.Text = "˄";
            this.upBtn.Click += new System.EventHandler(this.upBtn_Click);
            // 
            // actionPanel
            // 
            this.actionPanel.Location = new System.Drawing.Point(6, 45);
            this.actionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(275, 250);
            this.actionPanel.TabIndex = 8;
            // 
            // addActionBtn
            // 
            this.addActionBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addActionBtn.Location = new System.Drawing.Point(12, 290);
            this.addActionBtn.Name = "addActionBtn";
            this.addActionBtn.Padding = new System.Windows.Forms.Padding(5);
            this.addActionBtn.Size = new System.Drawing.Size(100, 23);
            this.addActionBtn.TabIndex = 1;
            this.addActionBtn.Text = "Add new action";
            this.addActionBtn.Click += new System.EventHandler(this.addActionBtn_Click);
            // 
            // removeActionBtn
            // 
            this.removeActionBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeActionBtn.Location = new System.Drawing.Point(118, 290);
            this.removeActionBtn.Name = "removeActionBtn";
            this.removeActionBtn.Padding = new System.Windows.Forms.Padding(5);
            this.removeActionBtn.Size = new System.Drawing.Size(96, 23);
            this.removeActionBtn.TabIndex = 2;
            this.removeActionBtn.Text = "Remove action";
            this.removeActionBtn.Click += new System.EventHandler(this.removeActionBtn_Click);
            // 
            // ActionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(519, 325);
            this.Controls.Add(this.removeActionBtn);
            this.Controls.Add(this.addActionBtn);
            this.Controls.Add(this.darkGroupBox1);
            this.Controls.Add(this.actionList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ActionManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "xMIDI - Action Manager";
            this.darkGroupBox1.ResumeLayout(false);
            this.darkGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkGroupBox darkGroupBox1;
        private DarkUI.Controls.DarkButton addActionBtn;
        private DarkUI.Controls.DarkButton removeActionBtn;
        private System.Windows.Forms.Panel actionPanel;
        public DarkUI.Controls.DarkListView actionList;
        private DarkUI.Controls.DarkButton downBtn;
        private DarkUI.Controls.DarkButton upBtn;
        private DarkUI.Controls.DarkTextBox nameTxt;
        private DarkUI.Controls.DarkLabel darkLabel1;
    }
}