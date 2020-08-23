namespace PhysicsQuiz1._0.StudentForms
{
    partial class StudentHomescreen
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
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.ViewPastQuizScoresLabel = new System.Windows.Forms.Label();
            this.CompletePreviouslyCreatedQuizLabel = new System.Windows.Forms.Label();
            this.GenerateNewQuizLabel = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.ViewQuestionsButton = new System.Windows.Forms.Button();
            this.ViewQuestionsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Location = new System.Drawing.Point(346, 41);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(239, 13);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "Welcome ##########, Please Select A Mode.";
            this.WelcomeLabel.Click += new System.EventHandler(this.WelcomeLabel_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(241, 36);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 110);
            this.button3.TabIndex = 2;
            this.button3.Text = "Complete Previously Created Quiz";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ViewPastQuizScoresLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CompletePreviouslyCreatedQuizLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.GenerateNewQuizLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button15, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button14, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button13, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ViewQuestionsButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ViewQuestionsLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(199, 206);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 149);
            this.tableLayoutPanel1.TabIndex = 5;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(479, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "label5";
            // 
            // ViewPastQuizScoresLabel
            // 
            this.ViewPastQuizScoresLabel.AutoSize = true;
            this.ViewPastQuizScoresLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewPastQuizScoresLabel.Location = new System.Drawing.Point(360, 0);
            this.ViewPastQuizScoresLabel.Name = "ViewPastQuizScoresLabel";
            this.ViewPastQuizScoresLabel.Size = new System.Drawing.Size(113, 26);
            this.ViewPastQuizScoresLabel.TabIndex = 21;
            this.ViewPastQuizScoresLabel.Text = "View Past Quiz Scores";
            // 
            // CompletePreviouslyCreatedQuizLabel
            // 
            this.CompletePreviouslyCreatedQuizLabel.AutoSize = true;
            this.CompletePreviouslyCreatedQuizLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompletePreviouslyCreatedQuizLabel.Location = new System.Drawing.Point(241, 0);
            this.CompletePreviouslyCreatedQuizLabel.Name = "CompletePreviouslyCreatedQuizLabel";
            this.CompletePreviouslyCreatedQuizLabel.Size = new System.Drawing.Size(113, 26);
            this.CompletePreviouslyCreatedQuizLabel.TabIndex = 20;
            this.CompletePreviouslyCreatedQuizLabel.Text = "CompletePreviously Created Quiz";
            // 
            // GenerateNewQuizLabel
            // 
            this.GenerateNewQuizLabel.AutoSize = true;
            this.GenerateNewQuizLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GenerateNewQuizLabel.Location = new System.Drawing.Point(122, 0);
            this.GenerateNewQuizLabel.Name = "GenerateNewQuizLabel";
            this.GenerateNewQuizLabel.Size = new System.Drawing.Size(113, 13);
            this.GenerateNewQuizLabel.TabIndex = 19;
            this.GenerateNewQuizLabel.Text = "Generate New Quiz";
            // 
            // button15
            // 
            this.button15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button15.Location = new System.Drawing.Point(479, 36);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(115, 110);
            this.button15.TabIndex = 4;
            this.button15.Text = "button15";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button14.Location = new System.Drawing.Point(360, 36);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(113, 110);
            this.button14.TabIndex = 3;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button13.Location = new System.Drawing.Point(122, 36);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(113, 110);
            this.button13.TabIndex = 1;
            this.button13.Text = "Generate New Quiz Manually";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // ViewQuestionsButton
            // 
            this.ViewQuestionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewQuestionsButton.Location = new System.Drawing.Point(3, 36);
            this.ViewQuestionsButton.Name = "ViewQuestionsButton";
            this.ViewQuestionsButton.Size = new System.Drawing.Size(113, 110);
            this.ViewQuestionsButton.TabIndex = 0;
            this.ViewQuestionsButton.Text = "View All Stored Question";
            this.ViewQuestionsButton.UseVisualStyleBackColor = true;
            this.ViewQuestionsButton.Click += new System.EventHandler(this.ViewQuestionsButton_Click);
            // 
            // ViewQuestionsLabel
            // 
            this.ViewQuestionsLabel.AutoSize = true;
            this.ViewQuestionsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewQuestionsLabel.Location = new System.Drawing.Point(3, 0);
            this.ViewQuestionsLabel.Name = "ViewQuestionsLabel";
            this.ViewQuestionsLabel.Size = new System.Drawing.Size(113, 26);
            this.ViewQuestionsLabel.TabIndex = 18;
            this.ViewQuestionsLabel.Text = "View All Stored Question";
            // 
            // StudentHomescreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 613);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.WelcomeLabel);
            this.Name = "StudentHomescreen";
            this.Text = "StudentHomescreen";
            this.Load += new System.EventHandler(this.StudentHomescreen_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ViewPastQuizScoresLabel;
        private System.Windows.Forms.Label CompletePreviouslyCreatedQuizLabel;
        private System.Windows.Forms.Label GenerateNewQuizLabel;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button ViewQuestionsButton;
        private System.Windows.Forms.Label ViewQuestionsLabel;
    }
}