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
            this.SuspendLayout();
            // 
            // SendQuizScoresButton
            // 
            this.SendQuizScoresButton.Location = new System.Drawing.Point(271, 129);
            this.SendQuizScoresButton.Name = "SendQuizScoresButton";
            this.SendQuizScoresButton.Size = new System.Drawing.Size(246, 138);
            this.SendQuizScoresButton.TabIndex = 0;
            this.SendQuizScoresButton.Text = "Send Quiz Scores";
            this.SendQuizScoresButton.UseVisualStyleBackColor = true;
            // 
            // SendQuizInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SendQuizScoresButton);
            this.Name = "SendQuizInfo";
            this.Text = "SendEmail";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SendQuizScoresButton;
    }
}