using PhysicsQuiz1._0.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.LoginScreen
{
    public partial class RegisterStudent : Form
    {
        StartLogin Fom;
        public RegisterStudent(StartLogin Frm)
        {
            InitializeComponent();
            Fom = Frm; //The login form is saved to the global variable
        }

        private void FirstNameInsertBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var db = new DataAccess(); //The data access class is created 


            if (checkdetails() == true) //The function check ddetails is ran. If it returns true then the following code is executed.
            { 
                if (db.CheckStudentUsername(UsernameInsertBox.Text) == false) //The username is checked against the database to check it isn`t taken
                {
                    if (db.CheckClassCode(int.Parse(ClassCodeInsertBox.Text)) == true) //The class code is checked against the database to check if it is valid
                    {
                        db.CreateStudent(FirstNameInsertBox.Text, SurnameInsertBox.Text, UsernameInsertBox.Text, PasswordInsertBox.Text, int.Parse(ClassCodeInsertBox.Text));
                        //The method create student is ran. It adds the student`s details to the database
                        
                        FirstNameInsertBox.Text = "";
                        SurnameInsertBox.Text = "";
                        UsernameInsertBox.Text = "";
                        PasswordInsertBox.Text = "";
                        ClassCodeInsertBox.Text = "";
                        //All assets are reset for the next student to register
                    }
                    else
                    {
                        //Message will display if the user inputs the incorrect class code
                        MessageBox.Show("Incorrect Class Code, Please Check and Try Again", "Error", MessageBoxButtons.OK);
                    }
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
            if (UsernameInsertBox.Text == "")
            {
                MessageBox.Show( "Please Enter a username", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (ClassCodeInsertBox.Text == "" || ClassCodeInsertBox.Text.Any(char.IsLetter) == true) //Checks if the string contains any letters which a class code cannot
            {
                MessageBox.Show( "Please Enter a Class Code", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (SurnameInsertBox.Text == "" || SurnameInsertBox.Text.Any(char.IsDigit) == true) //Checks if the surname has any numbers in it which isn`t allowed
            {
                MessageBox.Show( "Please Enter a Surname", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (FirstNameInsertBox.Text == "" || FirstNameInsertBox.Text.Any(char.IsDigit) == true) //Checks if the firstname has any numbers in it which isn`t allowed
            {
                MessageBox.Show( "Please Enter a First name", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (PasswordInsertBox.Text == "" || !PasswordInsertBox.Text.Any(char.IsUpper) || !PasswordInsertBox.Text.Any(char.IsDigit) || PasswordInsertBox.Text.Length < 8 || PasswordInsertBox.Text.Length > 15)
            {
                //All passwords must meet a criteria of having an uppercase letter, a lowercase letter, a digit, and a length between 8 and 15 characters
                MessageBox.Show( "Please Enter a Valid Password", "Error", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                //If none of the conditions previously are met which make the details invalid, then the function retuns true.
                //Otherwise the value returned is false
                return true;
            }
        }

        private void RegisterStudent_Load(object sender, EventArgs e)
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
