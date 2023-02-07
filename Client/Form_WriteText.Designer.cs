namespace Client
{
    partial class Form_WriteText
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
            this.TxtBoxPathOne = new System.Windows.Forms.TextBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.TxtBoxPathTwo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtBoxPathOne
            // 
            this.TxtBoxPathOne.BackColor = System.Drawing.SystemColors.Window;
            this.TxtBoxPathOne.Location = new System.Drawing.Point(12, 12);
            this.TxtBoxPathOne.Name = "TxtBoxPathOne";
            this.TxtBoxPathOne.Size = new System.Drawing.Size(257, 20);
            this.TxtBoxPathOne.TabIndex = 1;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(275, 23);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 2;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // TxtBoxPathTwo
            // 
            this.TxtBoxPathTwo.Location = new System.Drawing.Point(12, 38);
            this.TxtBoxPathTwo.Name = "TxtBoxPathTwo";
            this.TxtBoxPathTwo.Size = new System.Drawing.Size(257, 20);
            this.TxtBoxPathTwo.TabIndex = 3;
            // 
            // Form_WriteText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(357, 68);
            this.Controls.Add(this.TxtBoxPathTwo);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.TxtBoxPathOne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_WriteText";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WriteText";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBoxPathOne;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.TextBox TxtBoxPathTwo;
    }
}