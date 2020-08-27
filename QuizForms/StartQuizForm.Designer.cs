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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.AdaptiveQuestionsLabel = new System.Windows.Forms.Label();
            this.DefaultQuestionsOrderLabel = new System.Windows.Forms.Label();
            this.ResetAdaptiveQuestionButton = new System.Windows.Forms.Button();
            this.ResetAdaptiveQuestionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // QuizNameLabel
            // 
            this.QuizNameLabel.AutoSize = true;
            this.QuizNameLabel.Location = new System.Drawing.Point(418, 35);
            this.QuizNameLabel.Name = "QuizNameLabel";
            this.QuizNameLabel.Size = new System.Drawing.Size(96, 13);
            this.QuizNameLabel.TabIndex = 0;
            this.QuizNameLabel.Text = "QuizName = ####";
            // 
            // StartQuizButton
            // 
            this.StartQuizButton.Location = new System.Drawing.Point(358, 317);
            this.StartQuizButton.Name = "StartQuizButton";
            this.StartQuizButton.Size = new System.Drawing.Size(225, 99);
            this.StartQuizButton.TabIndex = 1;
            this.StartQuizButton.Text = "Start Quiz";
            this.StartQuizButton.UseVisualStyleBackColor = true;
            this.StartQuizButton.Click += new System.EventHandler(this.StartQuizButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Adaptive Questions Order",
            "Default Questions Order"});
            this.comboBox1.Location = new System.Drawing.Point(380, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(174, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // AdaptiveQuestionsLabel
            // 
            this.AdaptiveQuestionsLabel.AutoSize = true;
            this.AdaptiveQuestionsLabel.Location = new System.Drawing.Point(45, 60);
            this.AdaptiveQuestionsLabel.Name = "AdaptiveQuestionsLabel";
            this.AdaptiveQuestionsLabel.Size = new System.Drawing.Size(237, 52);
            this.AdaptiveQuestionsLabel.TabIndex = 3;
            this.AdaptiveQuestionsLabel.Text = "Adaptive Question - Using machine learning, the \r\nprogram will present you with t" +
    "he questions you \r\nstruggle with more often than the questions that \r\nyou answer" +
    " correct more often.";
            // 
            // DefaultQuestionsOrderLabel
            // 
            this.DefaultQuestionsOrderLabel.AutoSize = true;
            this.DefaultQuestionsOrderLabel.Location = new System.Drawing.Point(588, 60);
            this.DefaultQuestionsOrderLabel.Name = "DefaultQuestionsOrderLabel";
            this.DefaultQuestionsOrderLabel.Size = new System.Drawing.Size(225, 52);
            this.DefaultQuestionsOrderLabel.TabIndex = 4;
            this.DefaultQuestionsOrderLabel.Text = "Default Questions Order -The program will \r\npresent the questions in a randomized" +
    " order\r\nand your ability will not impact which questions\r\nare presented.";
            // 
            // ResetAdaptiveQuestionButton
            // 
            this.ResetAdaptiveQuestionButton.Location = new System.Drawing.Point(421, 234);
            this.ResetAdaptiveQuestionButton.Name = "ResetAdaptiveQuestionButton";
            this.ResetAdaptiveQuestionButton.Size = new System.Drawing.Size(93, 43);
            this.ResetAdaptiveQuestionButton.TabIndex = 5;
            this.ResetAdaptiveQuestionButton.Text = "Reset Adaptive Question";
            this.ResetAdaptiveQuestionButton.UseVisualStyleBackColor = true;
            // 
            // ResetAdaptiveQuestionLabel
            // 
            this.ResetAdaptiveQuestionLabel.AutoSize = true;
            this.ResetAdaptiveQuestionLabel.Location = new System.Drawing.Point(355, 169);
            this.ResetAdaptiveQuestionLabel.Name = "ResetAdaptiveQuestionLabel";
            this.ResetAdaptiveQuestionLabel.Size = new System.Drawing.Size(261, 39);
            this.ResetAdaptiveQuestionLabel.TabIndex = 6;
            this.ResetAdaptiveQuestionLabel.Text = "Reset Adaptive Question - This will reset the programs\r\nknowledge of your ability" +
    " and will revert its settings to\r\ndefault.";
            // 
            // StartQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 499);
            this.Controls.Add(this.ResetAdaptiveQuestionLabel);
            this.Controls.Add(this.ResetAdaptiveQuestionButton);
            this.Controls.Add(this.DefaultQuestionsOrderLabel);
            this.Controls.Add(this.AdaptiveQuestionsLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.StartQuizButton);
            this.Controls.Add(this.QuizNameLabel);
            this.Name = "StartQuizForm";
            this.Text = "StartQuizForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuizNameLabel;
        private System.Windows.Forms.Button StartQuizButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label AdaptiveQuestionsLabel;
        private System.Windows.Forms.Label DefaultQuestionsOrderLabel;
        private System.Windows.Forms.Button ResetAdaptiveQuestionButton;
        private System.Windows.Forms.Label ResetAdaptiveQuestionLabel;
    }
}