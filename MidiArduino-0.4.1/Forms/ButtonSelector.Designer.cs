
namespace MidiArduino
{
    partial class ButtonSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonSelector));
            this.midiButton = new DarkUI.Controls.DarkLabel();
            this.confirmBtn = new DarkUI.Controls.DarkButton();
            this.discardBtn = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // midiButton
            // 
            this.midiButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.midiButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.midiButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.midiButton.Location = new System.Drawing.Point(0, 0);
            this.midiButton.Name = "midiButton";
            this.midiButton.Size = new System.Drawing.Size(261, 169);
            this.midiButton.TabIndex = 0;
            this.midiButton.Text = "Use MIDI button";
            this.midiButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confirmBtn
            // 
            this.confirmBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmBtn.Location = new System.Drawing.Point(183, 172);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Padding = new System.Windows.Forms.Padding(5);
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 1;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // discardBtn
            // 
            this.discardBtn.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discardBtn.Location = new System.Drawing.Point(102, 172);
            this.discardBtn.Name = "discardBtn";
            this.discardBtn.Padding = new System.Windows.Forms.Padding(5);
            this.discardBtn.Size = new System.Drawing.Size(75, 23);
            this.discardBtn.TabIndex = 2;
            this.discardBtn.Text = "Discard";
            this.discardBtn.Click += new System.EventHandler(this.discardBtn_Click);
            // 
            // ButtonSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(260, 197);
            this.Controls.Add(this.discardBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.midiButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ButtonSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Arduino MIDI - Button Selector";
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkLabel midiButton;
        private DarkUI.Controls.DarkButton confirmBtn;
        private DarkUI.Controls.DarkButton discardBtn;
    }
}