namespace PhysicsQuiz1._0.GeneralForms
{
    partial class SendQuizInfo
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
            this.SendQuizScoresButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SendQuizScoresButton
            // 
            this.SendQuizScoresButton.Location = new System.Drawing.Point(352, 164);
            this.SendQuizScoresButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SendQuizScoresButton.Name = "SendQuizScoresButton";
            this.SendQuizScoresButton.Size = new System.Drawing.Size(328, 170);
            this.SendQuizScoresButton.TabIndex = 0;
            this.SendQuizScoresButton.Text = "Click to Send Teacher Email";
            this.SendQuizScoresButton.UseVisualStyleBackColor = true;
            this.SendQuizScoresButton.Click += new System.EventHandler(this.SendQuizScoresButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(17, 18);
            this.ReturnButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(112, 59);
            this.ReturnButton.TabIndex = 1;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // SendQuizInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.SendQuizScoresButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SendQuizInfo";
            this.Text = "SendEmail";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SendQuizScoresButton;
        private System.Windows.Forms.Button ReturnButton;
    }
}