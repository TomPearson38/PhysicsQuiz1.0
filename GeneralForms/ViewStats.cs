using PhysicsQuiz1._0.Classes;
using PhysicsQuiz1._0.LoginScreen;
using PhysicsQuiz1._0.QuizForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.GeneralForms
{
    public partial class ViewStats : Form
    {
        private StudentLogin Student = new StudentLogin();

        List<StoredQuestions> ListOfStoredQuestions = new List<StoredQuestions>();

        StoredQuizzes SelectedQuiz = new StoredQuizzes();

        List<StoredQuestions> QuizQuestions = new List<StoredQuestions>();

        List<StoredQuizQuestions> QuizQuestionsId = new List<StoredQuizQuestions>();

        List<CompletedQuestion> completedQuestion = new List<CompletedQuestion>();

        CompletedQuiz CQuiz = new CompletedQuiz();

        public event EventHandler OpenStoredQuizzes;

        public ViewStats(StudentLogin student, StoredQuizzes SQuiz, List<StoredQuestions> storedQuestions, List<StoredQuizQuestions> storedQuizQuestions)
        {
            InitializeComponent();

            StudentInputNameLabel.Text = ($"{student.FistName} {student.SecondName}");

            InputClassIdLabel.Text = student.ClassId.ToString();

            QuestionClass qc = new QuestionClass();

            CQuiz = qc.GetCompletedQuiz(SQuiz.QuizId, student.StudentId);

            if(CQuiz == null)
            {
                CQuiz.Id = SQuiz.QuizId;
                CQuiz.StudentId = student.StudentId;
                CQuiz.Length = SQuiz.Length;
                CQuiz = qc.CreateCompletedQuiz(CQuiz);
            }

            completedQuestion = qc.GetCompletedQuestion(CQuiz, storedQuizQuestions);

            foreach(StoredQuestions sq in storedQuestions)
            {
                ListViewItem b = new ListViewItem(sq.Question);
                b.SubItems.Add(sq.Area.ToString());
                if (sq.TopicId == 1)
                {
                    b.SubItems.Add("Particles");
                }
                else if (sq.TopicId == 2)
                {
                    b.SubItems.Add("Waves");
                }
                else if (sq.TopicId == 3)
                {
                    b.SubItems.Add("Mechanics");
                }
                else if (sq.TopicId == 4)
                {
                    b.SubItems.Add("Materials");
                }
                else if (sq.TopicId == 5)
                {
                    b.SubItems.Add("Electricity");
                }

                foreach (CompletedQuestion cq in completedQuestion)
                {
                    if(cq.QuestionId == sq.QuestionId)
                    {
                        b.SubItems.Add(cq.XCompleted.ToString());
                        b.SubItems.Add(cq.XCorrect.ToString());
                        break;
                    }
                }
                listView1.Items.Add(b);
            }

            Student = student;

            ListOfStoredQuestions = storedQuestions;

            SelectedQuiz = SQuiz;

            QuizQuestions = storedQuestions;

            QuizQuestionsId = storedQuizQuestions;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReturnedToStoredQuizzesButton_Click(object sender, EventArgs e)
        {
            this.Close();
            OpenStoredQuizzes?.Invoke(this, EventArgs.Empty);
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {

        }

        private void StudyButton_Click(object sender, EventArgs e)
        {
            StartQuizForm SQF = new StartQuizForm(Student, SelectedQuiz, ListOfStoredQuestions, QuizQuestionsId, CQuiz, completedQuestion);

            this.Hide();

            SQF.Show();
        }
    }
}
