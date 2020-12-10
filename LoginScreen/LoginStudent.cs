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
            Fom = Frm;
        }

        private void FirstNameInsertBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            var user = new StudentLogin();

            user = db.AttemptStudentLogin(UsernameInsertBox.Text, PasswordInsertBox.Text);

            if (user == null)
            { 
            
            }
            else
            {
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
            Fom.Show();
            this.Close();
        }

        private void PasswordInsertBox_KeyDown(object sender, KeyEventArgs e)
        {
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
            if (validlogin != true)
            {
                Fom.Show();
            }
            base.OnFormClosing(e);
        }
    }
}
