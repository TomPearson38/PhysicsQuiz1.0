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
            Fom = Frm; //The login form is saved to the global variable
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess(); //The data access class is created 

            if (checkdetails() == true) //The function check ddetails is ran. If it returns true then the following code is executed.
            {
                if (db.CheckTeacherUsername(UsernameTextBox.Text) == false) //The username is checked against the database to check it isn`t taken
                {
                    db.CreateNewTeacher(TitleSelectComboBox.Text, SurnameTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text);
                    //The method create teacher is ran. It adds the teacher`s details to the database
                    TitleSelectComboBox.SelectedItem = null;
                    SurnameTextBox.Text = "";
                    UsernameTextBox.Text = "";
                    PasswordTextBox.Text = "";
                    EmailTextBox.Text = "";
                    //All assets are reset for the next teacher to register
                }
                else
                {
                    //Message will display if the username is already taken
                    MessageBox.Show("Username is taken, please enter a different username", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            //Closes this form and displays the previous form
            Fom.Show();
            this.Hide();
        }

        private bool checkdetails()
        {
            //Checks if all fields have had data input.
            if (UsernameTextBox.Text == "")
            {
                MessageBox.Show("Please Enter a username", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (EmailTextBox.Text == "" || IsValidEmail(EmailTextBox.Text) == false) //Checks to see if the email entered is valid by running the IsVaildEmail function
            {
                MessageBox.Show("Please Enter a Valid Email", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (SurnameTextBox.Text == "" || SurnameTextBox.Text.Any(char.IsDigit) == true) //Checks if the surname has any numbers in it which isn`t allowed
            {
                MessageBox.Show("Please Enter a Surname", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (TitleSelectComboBox.SelectedItem == null) //Checks for data input
            {
                MessageBox.Show("Please Select a Title", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (PasswordTextBox.Text == "" || !PasswordTextBox.Text.Any(char.IsUpper) || !PasswordTextBox.Text.Any(char.IsDigit) || PasswordTextBox.Text.Length < 8 || PasswordTextBox.Text.Length > 15)
            {
                //All passwords must meet a criteria of having an uppercase letter, a lowercase letter, a digit, and a length between 8 and 15 characters
                MessageBox.Show("Please Enter a Valid Password", "Error", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                //If none of the conditions previously are met which make the details invalid, then the function retuns true.
                //Otherwise the value returned is false
                return true;
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                //Trys to convert the text input to an email address
                var e = new System.Net.Mail.MailAddress(email);
                return e.Address == email;
            }
            catch
            {
                //If it is unable to convert it to an email it will throw an error which will be caught here.
                //A false will then be returned as it is an invalid email
                return false;
            }
        }

        private void RegisterTeacher_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //Closes this form and displays the previous form
            Fom.Show();
            base.OnFormClosing(e);
        }
    }
}
