using PhysicsQuiz1._0.Classes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.LoginScreen
{
    public partial class RegisterTeacher : Form
    {
        StartLogin Fom;
        public RegisterTeacher(StartLogin Frm)
        {
            InitializeComponent();
            Fom = Frm;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            if (checkdetails() == true)
            {
                if (db.CheckTeacherUsername(UsernameTextBox.Text) == false)
                {
                    db.CreateNewTeacher(TitleSelectComboBox.Text, SurnameTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text);
                    TitleSelectComboBox.SelectedItem = null;
                    SurnameTextBox.Text = "";
                    UsernameTextBox.Text = "";
                    PasswordTextBox.Text = "";
                    EmailTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Username is taken, please enter a different username", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Fom.Show();
            this.Hide();
        }

        private bool checkdetails()
        {
            if (UsernameTextBox.Text == "")
            {
                MessageBox.Show("Please Enter a username", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (EmailTextBox.Text == "" || IsValidEmail(EmailTextBox.Text) == false)
            {
                MessageBox.Show("Please Enter a Valid Email", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (SurnameTextBox.Text == "" || SurnameTextBox.Text.Any(char.IsDigit) == true)
            {
                MessageBox.Show("Please Enter a Surname", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (TitleSelectComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please Select a Title", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (PasswordTextBox.Text == "" || !PasswordTextBox.Text.Any(char.IsUpper) || !PasswordTextBox.Text.Any(char.IsDigit) || PasswordTextBox.Text.Length < 8 || PasswordTextBox.Text.Length > 15)
            {
                MessageBox.Show("Please Enter a Valid Password", "Error", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var e = new System.Net.Mail.MailAddress(email);
                return e.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void RegisterTeacher_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Fom.Show();
            base.OnFormClosing(e);
        }
    }
}
