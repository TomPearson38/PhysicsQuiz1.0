using PhysicsQuiz1._0.Classes;
using PhysicsQuiz1._0.GeneralForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PhysicsQuiz1._0.StudentForms
{
    public partial class StudentHomescreen : Form
    {
        private StudentLogin student;

        public StudentHomescreen(StudentLogin user)
        {
            InitializeComponent();
            student = user;
            WelcomeLabel.Text = $"Welcome {user.FirstName}, Please Select A Mode.";
        }

        private void WelcomeLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewQuestionsButton_Click(object sender, EventArgs e)
        {
            ViewAllQuestionsForm pq = new ViewAllQuestionsForm();
            this.Hide();
            pq.Show();
            pq.ClosedPage += (source, EventArgs) =>
            {
                this.Show();
            };

            }

        private void StudentHomescreen_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.OpenForms[0].Close();
            base.OnFormClosing(e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            GenerateQuizManual gq = new GenerateQuizManual();
            this.Hide();
            gq.Show();
            gq.ClosedPage += (source, EventArgs) =>
            {
                this.Show();
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewStoredQuizzes SQ = new ViewStoredQuizzes();
            this.Hide();
            SQ.Show();
            SQ.ClosedPage += (source, EventArgs) =>
            {
                this.Show();
            };

            SQ.SelectedQuiz += ViewStatsCall;
        }

        private void ViewStatsCall(ViewStoredQuizzes VS,StoredQuizzes storedQuizzes, List<StoredQuestions> storedQuestions, List<StoredQuizQuestions> storedQuizQuestions)
        {
            ViewStats vs = new ViewStats(student, storedQuizzes, storedQuestions, storedQuizQuestions);
            vs.Show();

            vs.FormClosed += (source, EventArgs) =>
            {
                this.Show();
            };

            vs.OpenStoredQuizzes += (source, EventArgs) =>
            {
                button3_Click(null, EventArgs.Empty);
            };
        }

        private void GenerateNewQuizAutoButton_Click(object sender, EventArgs e)
        {
            AutoCreateForm ACF = new AutoCreateForm();
            this.Hide();
            ACF.Show();
            ACF.ClosedPage += (source, EventArgs) =>
            {
                this.Show();
            };
        }
    }
}
