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
            Fom = Frm;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            var Teach = new TeacherLogin();
            Teach = db.AttemptTeacherLogin(UsernameInsertBox.Text, PasswordInsertBox.Text);
            if (Teach == null)
            {

            }
            else
            {
                validlogin = true;
                UsernameInsertBox.Text = "";
                PasswordInsertBox.Text = "";
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Fom.Show();
            this.Hide();
        }

        private void TeacherLoginForm_Load(object sender, EventArgs e)
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
