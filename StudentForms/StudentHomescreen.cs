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
            student = user; //The students login info is made global in the form
            WelcomeLabel.Text = $"Welcome {user.FirstName}, Please Select A Mode."; //A welcome message us displayed
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
            //Launches the viewquestionsform
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
            //Closes all the remaining open forms
            Application.OpenForms[0].Close();
            base.OnFormClosing(e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Launches the GenerateQuizManual form
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
            //Launches the storedquizzes form
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
            //Launches the viewstats form
            ViewStats vs = new ViewStats(student, storedQuizzes, storedQuestions, storedQuizQuestions);
            vs.Show();

            vs.FormClosed += (source, EventArgs) =>
            {
                this.Show();
            };

            vs.OpenStoredQuizzes += (source, EventArgs) =>
            {
                //The user can specify to return to the storedquizzes, if they wish to do that this event is called
                button3_Click(null, EventArgs.Empty);
            };
        }

        private void GenerateNewQuizAutoButton_Click(object sender, EventArgs e)
        {
            //Launches the auto create quiz form
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
