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
    public partial class StartLogin : Form
    {
        public StartLogin()
        {
            //The first form displayed to the user. It contains the different login and register screens for them to use
            InitializeComponent();
        }

        private void RegisterAsTeacherButton_Click(object sender, EventArgs e)
        {
            //Launches the register teacher form
            Form SecForm = new RegisterTeacher(this);
            SecForm.Show();
            this.Hide();
        }

        private void LoginAsTeacherButton_Click(object sender, EventArgs e)
        {
            //Launchest the login teacher form
            Form SecForm = new TeacherLoginForm(this);
            SecForm.Show();
            this.Hide();
        }

        private void StudentLoginButton_Click(object sender, EventArgs e)
        {
            //Launches the login student form
            Form SecForm = new LoginStudent(this);
            SecForm.Show();
            this.Hide();
        }

        private void RegisterStudentButton_Click(object sender, EventArgs e)
        {
            //Launches the register student form
            Form SecForm = new RegisterStudent(this);
            SecForm.Show();
            this.Hide();
        }

        private void StartLogin_Load(object sender, EventArgs e)
        {

        }

        private void StartLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void StartLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
