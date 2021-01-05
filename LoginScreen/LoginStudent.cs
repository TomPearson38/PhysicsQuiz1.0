using PhysicsQuiz1._0.Classes;
using PhysicsQuiz1._0.StudentForms;
using System;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.LoginScreen
{
    public partial class LoginStudent : Form
    {
        bool validlogin = false;
        public StartLogin Fom;
        public LoginStudent(StartLogin Frm)
        {
            InitializeComponent();
            Fom = Frm; //The login form is saved to the global variable
        }

        private void FirstNameInsertBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess(); //The class data access is initilized

            var user = new StudentLogin(); //User is created based upon the student login

            user = db.AttemptStudentLogin(UsernameInsertBox.Text, PasswordInsertBox.Text); //The method attempy student login is called, this takes in the parameters of the username and the password that the user has just input


            if (user == null)
            {
                //If the class returned an invalid login then it defaults to a blank user and therefore the login is not authorized and the form display an incorrect login message
                MessageBox.Show("Incorrect Login Credentials", "Error", MessageBoxButtons.OK);
            }
            else
            {
                //If a valid user login was input then the form wipes the current form clean and opens the student home screen passing in the parameters of the returned login information
                validlogin = true;
                UsernameInsertBox.Text = "";
                PasswordInsertBox.Text = "";

                StudentHomescreen StHome = new StudentHomescreen(user);
                StHome.Show();
                this.Close();
            }

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            //Displays the previous form and closes this one
            Fom.Show();
            this.Close();
        }

        private void PasswordInsertBox_KeyDown(object sender, KeyEventArgs e)
        {
            //If the student presses enter in the password input box this code will trigger the login
            if (e.KeyCode == Keys.Enter)
            {
                RegisterButton_Click(sender, e);
            }
        }

        private void LoginStudent_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //When the form is closed the previous form is displayed and this one is closed.
            if (validlogin != true)
            {
                Fom.Show();
            }
            base.OnFormClosing(e);
        }
    }
}
