using PhysicsQuiz1._0.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.LoginScreen
{
    public partial class TeacherLoginForm : Form
    {
        bool validlogin = false;
        StartLogin Fom;
        public TeacherLoginForm(StartLogin Frm)
        {
            InitializeComponent();
            Fom = Frm;  //The login form is saved to the global variable
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();  //The class data access is initilized
            var Teach = new TeacherLogin(); //User is created upon the teacher class
            Teach = db.AttemptTeacherLogin(UsernameInsertBox.Text, PasswordInsertBox.Text); //The teach is assigned the value returned from the method attemptstudent login
            if (Teach == null)
            {
                //If the teacher couldn`t be found based upon the details that have been input then the method will return a blank teacherlogin and 
                //this message will be displayed
                MessageBox.Show("Incorrect Login Credentials", "Error", MessageBoxButtons.OK);
            }
            else
            {
                //Otherwise it will be a valid login and the teacher`s details will be passed on to the next form and the other parts of this login form will be reset
                validlogin = true;
                UsernameInsertBox.Text = "";
                PasswordInsertBox.Text = "";
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            //Displays the previous form and closes this one

            Fom.Show();
            this.Hide();
        }

        private void TeacherLoginForm_Load(object sender, EventArgs e)
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
