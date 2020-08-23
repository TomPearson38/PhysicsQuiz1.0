namespace PhysicsQuiz1._0.LoginScreen
{
    partial class LoginStudent
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
            this.components = new System.ComponentModel.Container();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordInsertBox = new System.Windows.Forms.TextBox();
            this.UsernameInsertLabel = new System.Windows.Forms.Label();
            this.UsernameInsertBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DisplayHash = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(356, 201);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(251, 166);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 21;
            this.PasswordLabel.Text = "Password";
            // 
            // PasswordInsertBox
            // 
            this.PasswordInsertBox.Location = new System.Drawing.Point(333, 163);
            this.PasswordInsertBox.Name = "PasswordInsertBox";
            this.PasswordInsertBox.PasswordChar = '*';
            this.PasswordInsertBox.Size = new System.Drawing.Size(157, 20);
            this.PasswordInsertBox.TabIndex = 1;
            this.PasswordInsertBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordInsertBox_KeyDown);
            // 
            // UsernameInsertLabel
            // 
            this.UsernameInsertLabel.AutoSize = true;
            this.UsernameInsertLabel.Location = new System.Drawing.Point(251, 123);
            this.UsernameInsertLabel.Name = "UsernameInsertLabel";
            this.UsernameInsertLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameInsertLabel.TabIndex = 19;
            this.UsernameInsertLabel.Text = "Username";
            // 
            // UsernameInsertBox
            // 
            this.UsernameInsertBox.Location = new System.Drawing.Point(333, 120);
            this.UsernameInsertBox.Name = "UsernameInsertBox";
            this.UsernameInsertBox.Size = new System.Drawing.Size(157, 20);
            this.UsernameInsertBox.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // DisplayHash
            // 
            this.DisplayHash.Location = new System.Drawing.Point(308, 271);
            this.DisplayHash.Name = "DisplayHash";
            this.DisplayHash.Size = new System.Drawing.Size(157, 20);
            this.DisplayHash.TabIndex = 23;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(18, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(67, 38);
            this.BackButton.TabIndex = 24;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // LoginStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.DisplayHash);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.PasswordInsertBox);
            this.Controls.Add(this.UsernameInsertLabel);
            this.Controls.Add(this.UsernameInsertBox);
            this.Name = "LoginStudent";
            this.Text = "LoginStudent";
            this.Load += new System.EventHandler(this.LoginStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordInsertBox;
        private System.Windows.Forms.Label UsernameInsertLabel;
        private System.Windows.Forms.TextBox UsernameInsertBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox DisplayHash;
        private System.Windows.Forms.Button BackButton;
    }
}