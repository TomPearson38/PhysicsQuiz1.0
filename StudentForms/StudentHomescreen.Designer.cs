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
            this.GenerateNewQuizAutoButton = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.ViewQuestionsButton = new System.Windows.Forms.Button();
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
            this.button3.Location = new System.Drawing.Point(301, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 143);
            this.button3.TabIndex = 2;
            this.button3.Text = "View And Study Created Quizzes";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.GenerateNewQuizAutoButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button13, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ViewQuestionsButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(199, 142);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(597, 149);
            this.tableLayoutPanel1.TabIndex = 5;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // GenerateNewQuizAutoButton
            // 
            this.GenerateNewQuizAutoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenerateNewQuizAutoButton.Location = new System.Drawing.Point(450, 3);
            this.GenerateNewQuizAutoButton.Name = "GenerateNewQuizAutoButton";
            this.GenerateNewQuizAutoButton.Size = new System.Drawing.Size(144, 143);
            this.GenerateNewQuizAutoButton.TabIndex = 3;
            this.GenerateNewQuizAutoButton.Text = "Generate New Quiz Automatically";
            this.GenerateNewQuizAutoButton.UseVisualStyleBackColor = true;
            this.GenerateNewQuizAutoButton.Click += new System.EventHandler(this.GenerateNewQuizAutoButton_Click);
            // 
            // button13
            // 
            this.button13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button13.Location = new System.Drawing.Point(152, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(143, 143);
            this.button13.TabIndex = 1;
            this.button13.Text = "Generate New Quiz Manually";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // ViewQuestionsButton
            // 
            this.ViewQuestionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewQuestionsButton.Location = new System.Drawing.Point(3, 3);
            this.ViewQuestionsButton.Name = "ViewQuestionsButton";
            this.ViewQuestionsButton.Size = new System.Drawing.Size(143, 143);
            this.ViewQuestionsButton.TabIndex = 0;
            this.ViewQuestionsButton.Text = "View All Stored Question";
            this.ViewQuestionsButton.UseVisualStyleBackColor = true;
            this.ViewQuestionsButton.Click += new System.EventHandler(this.ViewQuestionsButton_Click);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button GenerateNewQuizAutoButton;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button ViewQuestionsButton;
    }
}