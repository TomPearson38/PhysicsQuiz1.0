namespace PhysicsQuiz1._0.QuizForms
{
    partial class StartQuizForm
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
            this.QuizNameLabel = new System.Windows.Forms.Label();
            this.StartQuizButton = new System.Windows.Forms.Button();
            this.SelectModeComboBox = new System.Windows.Forms.ComboBox();
            this.AdaptiveQuestionsLabel = new System.Windows.Forms.Label();
            this.DefaultQuestionsOrderLabel = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // QuizNameLabel
            // 
            this.QuizNameLabel.AutoSize = true;
            this.QuizNameLabel.Location = new System.Drawing.Point(557, 43);
            this.QuizNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.QuizNameLabel.Name = "QuizNameLabel";
            this.QuizNameLabel.Size = new System.Drawing.Size(122, 17);
            this.QuizNameLabel.TabIndex = 0;
            this.QuizNameLabel.Text = "QuizName = ####";
            // 
            // StartQuizButton
            // 
            this.StartQuizButton.Location = new System.Drawing.Point(482, 232);
            this.StartQuizButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartQuizButton.Name = "StartQuizButton";
            this.StartQuizButton.Size = new System.Drawing.Size(300, 122);
            this.StartQuizButton.TabIndex = 1;
            this.StartQuizButton.Text = "Start Quiz";
            this.StartQuizButton.UseVisualStyleBackColor = true;
            this.StartQuizButton.Click += new System.EventHandler(this.StartQuizButton_Click);
            // 
            // SelectModeComboBox
            // 
            this.SelectModeComboBox.FormattingEnabled = true;
            this.SelectModeComboBox.Items.AddRange(new object[] {
            "Adaptive Questions Order",
            "Default Questions Order"});
            this.SelectModeComboBox.Location = new System.Drawing.Point(507, 91);
            this.SelectModeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SelectModeComboBox.Name = "SelectModeComboBox";
            this.SelectModeComboBox.Size = new System.Drawing.Size(231, 24);
            this.SelectModeComboBox.TabIndex = 2;
            // 
            // AdaptiveQuestionsLabel
            // 
            this.AdaptiveQuestionsLabel.AutoSize = true;
            this.AdaptiveQuestionsLabel.Location = new System.Drawing.Point(60, 74);
            this.AdaptiveQuestionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AdaptiveQuestionsLabel.Name = "AdaptiveQuestionsLabel";
            this.AdaptiveQuestionsLabel.Size = new System.Drawing.Size(317, 68);
            this.AdaptiveQuestionsLabel.TabIndex = 3;
            this.AdaptiveQuestionsLabel.Text = "Adaptive Question - Using machine learning, the \r\nprogram will present you with t" +
    "he questions you \r\nstruggle with more often than the questions that \r\nyou answer" +
    " correct more often.";
            // 
            // DefaultQuestionsOrderLabel
            // 
            this.DefaultQuestionsOrderLabel.AutoSize = true;
            this.DefaultQuestionsOrderLabel.Location = new System.Drawing.Point(784, 74);
            this.DefaultQuestionsOrderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DefaultQuestionsOrderLabel.Name = "DefaultQuestionsOrderLabel";
            this.DefaultQuestionsOrderLabel.Size = new System.Drawing.Size(299, 68);
            this.DefaultQuestionsOrderLabel.TabIndex = 4;
            this.DefaultQuestionsOrderLabel.Text = "Default Questions Order -The program will \r\npresent the questions in a randomized" +
    " order\r\nand your ability will not impact which questions\r\nare presented.";
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(16, 10);
            this.ReturnButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(119, 48);
            this.ReturnButton.TabIndex = 7;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // StartQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 614);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.DefaultQuestionsOrderLabel);
            this.Controls.Add(this.AdaptiveQuestionsLabel);
            this.Controls.Add(this.SelectModeComboBox);
            this.Controls.Add(this.StartQuizButton);
            this.Controls.Add(this.QuizNameLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StartQuizForm";
            this.Text = "StartQuizForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuizNameLabel;
        private System.Windows.Forms.Button StartQuizButton;
        private System.Windows.Forms.ComboBox SelectModeComboBox;
        private System.Windows.Forms.Label AdaptiveQuestionsLabel;
        private System.Windows.Forms.Label DefaultQuestionsOrderLabel;
        private System.Windows.Forms.Button ReturnButton;
    }
}