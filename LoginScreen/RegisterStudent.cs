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
            Fom = Frm;
        }

        private void FirstNameInsertBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var db = new DataAccess();
            if (checkdetails() == true)
            {
                if (db.CheckStudentUsername(UsernameInsertBox.Text) == false)
                {
                    if (db.CheckClassCode(int.Parse(ClassCodeInsertBox.Text)) == true)
                    {
                        db.CreateStudent(FirstNameInsertBox.Text, SurnameInsertBox.Text, UsernameInsertBox.Text, PasswordInsertBox.Text, int.Parse(ClassCodeInsertBox.Text));
                        FirstNameInsertBox.Text = "";
                        SurnameInsertBox.Text = "";
                        UsernameInsertBox.Text = "";
                        PasswordInsertBox.Text = "";
                        ClassCodeInsertBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Class Code, Please Check and Try Again", "Error", MessageBoxButtons.OK);
                    }
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
            if (UsernameInsertBox.Text == "")
            {
                MessageBox.Show( "Please Enter a username", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (ClassCodeInsertBox.Text == "" || ClassCodeInsertBox.Text.Any(char.IsLetter) == true)
            {
                MessageBox.Show( "Please Enter a Class Code", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (SurnameInsertBox.Text == "" || SurnameInsertBox.Text.Any(char.IsDigit) == true)
            {
                MessageBox.Show( "Please Enter a Surname", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (FirstNameInsertBox.Text == "" || FirstNameInsertBox.Text.Any(char.IsDigit) == true)
            {
                MessageBox.Show( "Please Enter a First name", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (PasswordInsertBox.Text == "" || !PasswordInsertBox.Text.Any(char.IsUpper) || !PasswordInsertBox.Text.Any(char.IsDigit) || PasswordInsertBox.Text.Length < 8 || PasswordInsertBox.Text.Length > 15)
            {
                MessageBox.Show( "Please Enter a Valid Password", "Error", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void RegisterStudent_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Fom.Show();
            base.OnFormClosing(e);
        }
    }
}
