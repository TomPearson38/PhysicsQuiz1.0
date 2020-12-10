namespace PhysicsQuiz1._0.LoginScreen
{
    partial class TeacherLoginForm
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordInsertBox = new System.Windows.Forms.TextBox();
            this.UsernameInsertLabel = new System.Windows.Forms.Label();
            this.UsernameInsertBox = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(515, 272);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(100, 28);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(375, 229);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(69, 17);
            this.PasswordLabel.TabIndex = 27;
            this.PasswordLabel.Text = "Password";
            // 
            // PasswordInsertBox
            // 
            this.PasswordInsertBox.Location = new System.Drawing.Point(484, 225);
            this.PasswordInsertBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordInsertBox.Name = "PasswordInsertBox";
            this.PasswordInsertBox.PasswordChar = '*';
            this.PasswordInsertBox.Size = new System.Drawing.Size(208, 22);
            this.PasswordInsertBox.TabIndex = 1;
            // 
            // UsernameInsertLabel
            // 
            this.UsernameInsertLabel.AutoSize = true;
            this.UsernameInsertLabel.Location = new System.Drawing.Point(375, 176);
            this.UsernameInsertLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsernameInsertLabel.Name = "UsernameInsertLabel";
            this.UsernameInsertLabel.Size = new System.Drawing.Size(73, 17);
            this.UsernameInsertLabel.TabIndex = 25;
            this.UsernameInsertLabel.Text = "Username";
            // 
            // UsernameInsertBox
            // 
            this.UsernameInsertBox.Location = new System.Drawing.Point(484, 172);
            this.UsernameInsertBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UsernameInsertBox.Name = "UsernameInsertBox";
            this.UsernameInsertBox.Size = new System.Drawing.Size(208, 22);
            this.UsernameInsertBox.TabIndex = 0;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(16, 15);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(89, 47);
            this.BackButton.TabIndex = 30;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // TeacherLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.PasswordInsertBox);
            this.Controls.Add(this.UsernameInsertLabel);
            this.Controls.Add(this.UsernameInsertBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TeacherLoginForm";
            this.Text = "TeacherLogin";
            this.Load += new System.EventHandler(this.TeacherLoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordInsertBox;
        private System.Windows.Forms.Label UsernameInsertLabel;
        private System.Windows.Forms.TextBox UsernameInsertBox;
        private System.Windows.Forms.Button BackButton;
    }
}