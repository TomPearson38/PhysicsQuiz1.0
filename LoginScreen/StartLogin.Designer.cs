namespace PhysicsQuiz1._0.LoginScreen
{
    partial class StartLogin
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
            this.StudentLoginButton = new System.Windows.Forms.Button();
            this.RegisterAsTeacherButton = new System.Windows.Forms.Button();
            this.LoginAsTeacherButton = new System.Windows.Forms.Button();
            this.RegisterStudentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StudentLoginButton
            // 
            this.StudentLoginButton.Location = new System.Drawing.Point(465, 58);
            this.StudentLoginButton.Name = "StudentLoginButton";
            this.StudentLoginButton.Size = new System.Drawing.Size(204, 82);
            this.StudentLoginButton.TabIndex = 2;
            this.StudentLoginButton.Text = "Login As Student";
            this.StudentLoginButton.UseVisualStyleBackColor = true;
            this.StudentLoginButton.Click += new System.EventHandler(this.StudentLoginButton_Click);
            // 
            // RegisterAsTeacherButton
            // 
            this.RegisterAsTeacherButton.Location = new System.Drawing.Point(105, 248);
            this.RegisterAsTeacherButton.Name = "RegisterAsTeacherButton";
            this.RegisterAsTeacherButton.Size = new System.Drawing.Size(204, 82);
            this.RegisterAsTeacherButton.TabIndex = 1;
            this.RegisterAsTeacherButton.Text = "Register As Teacher";
            this.RegisterAsTeacherButton.UseVisualStyleBackColor = true;
            this.RegisterAsTeacherButton.Click += new System.EventHandler(this.RegisterAsTeacherButton_Click);
            // 
            // LoginAsTeacherButton
            // 
            this.LoginAsTeacherButton.Location = new System.Drawing.Point(105, 58);
            this.LoginAsTeacherButton.Name = "LoginAsTeacherButton";
            this.LoginAsTeacherButton.Size = new System.Drawing.Size(204, 82);
            this.LoginAsTeacherButton.TabIndex = 0;
            this.LoginAsTeacherButton.Text = "Login As Teacher";
            this.LoginAsTeacherButton.UseVisualStyleBackColor = true;
            this.LoginAsTeacherButton.Click += new System.EventHandler(this.LoginAsTeacherButton_Click);
            // 
            // RegisterStudentButton
            // 
            this.RegisterStudentButton.Location = new System.Drawing.Point(465, 248);
            this.RegisterStudentButton.Name = "RegisterStudentButton";
            this.RegisterStudentButton.Size = new System.Drawing.Size(204, 82);
            this.RegisterStudentButton.TabIndex = 3;
            this.RegisterStudentButton.Text = "Register As Student";
            this.RegisterStudentButton.UseVisualStyleBackColor = true;
            this.RegisterStudentButton.Click += new System.EventHandler(this.RegisterStudentButton_Click);
            // 
            // StartLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RegisterStudentButton);
            this.Controls.Add(this.LoginAsTeacherButton);
            this.Controls.Add(this.RegisterAsTeacherButton);
            this.Controls.Add(this.StudentLoginButton);
            this.Name = "StartLogin";
            this.Text = "StartLogin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartLogin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartLogin_FormClosed);
            this.Load += new System.EventHandler(this.StartLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StudentLoginButton;
        private System.Windows.Forms.Button RegisterAsTeacherButton;
        private System.Windows.Forms.Button LoginAsTeacherButton;
        private System.Windows.Forms.Button RegisterStudentButton;
    }
}