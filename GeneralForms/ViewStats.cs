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

        List<StoredQuizQuestions> QuizQuestionsId = new List<StoredQuizQuestions>();

        List<CompletedQuestion> completedQuestion = new List<CompletedQuestion>();

        CompletedQuiz CQuiz = new CompletedQuiz();

        public event EventHandler OpenStoredQuizzes;

        public ViewStats(StudentLogin student, StoredQuizzes SQuiz, List<StoredQuestions> storedQuestions, List<StoredQuizQuestions> storedQuizQuestions)
        {
            InitializeComponent();
            setup(student, SQuiz, storedQuestions, storedQuizQuestions, null);
        }

        private void setup(StudentLogin student, StoredQuizzes SQuiz, List<StoredQuestions> storedQuestions, List<StoredQuizQuestions> storedQuizQuestions, List<CompletedQuestion> cquestion)
        {


            if (cquestion == null)
            {
                StudentInputNameLabel.Text = ($"{student.FirstName} {student.SecondName}");

                InputClassIdLabel.Text = student.ClassId.ToString();

                QuestionClass qc = new QuestionClass();

                //CQuiz = qc.GetCompletedQuiz(SQuiz.QuizId, student.StudentId);

                if (CQuiz == null)
                {
                    CQuiz.Id = SQuiz.QuizId;
                    CQuiz.StudentId = student.StudentId;
                    CQuiz.Length = SQuiz.Length;
                    CQuiz = qc.CreateCompletedQuiz(CQuiz);
                }

                completedQuestion = qc.GetCompletedQuestion(CQuiz, storedQuizQuestions);
            }
            else
            {
                listView1.Items.Clear();
                listView1.Refresh();
                completedQuestion = cquestion;
            }

            foreach (StoredQuestions sq in storedQuestions)
            {
                ListViewItem b = new ListViewItem(sq.Question);
                if (sq.Area == 1)
                {
                    b.SubItems.Add("Recall");
                }
                else
                {
                    b.SubItems.Add("Calculations");
                }

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
                    if (cq.QuestionId == sq.QuestionId)
                    {
                        b.SubItems.Add(cq.XCompleted.ToString());
                        b.SubItems.Add(cq.XCorrect.ToString());
                        string score = DifficultyScore(cq.CalculatedDifficulty);
                        b.SubItems.Add(score);
                        b.SubItems.Add(cq.CalculatedDifficulty.ToString());
                        break;
                    }
                }
                listView1.Items.Add(b);
            }


            Student = student;

            ListOfStoredQuestions = storedQuestions;

            SelectedQuiz = SQuiz;

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
            SendQuizInfo SQI = new SendQuizInfo(Student, ListOfStoredQuestions, completedQuestion, SelectedQuiz);

            this.Hide();

            SQI.Show();

            SQI.FormClosed += (source, EventArgs) =>
            {
                this.Show();
            };
        }

        private void StudyButton_Click(object sender, EventArgs e)
        {
            StartQuizForm SQF = new StartQuizForm(Student, SelectedQuiz, ListOfStoredQuestions, QuizQuestionsId, CQuiz, completedQuestion);

            this.Hide();

            SQF.Show();

            SQF.CompletedQuiz += NewViewStats;

            SQF.FormClosed += (source, EventArgs) =>
            {
                this.Show();
            };

        }

        private void NewViewStats(StartQuizForm SQF, StudentLogin student, StoredQuizzes SQuiz, List<StoredQuestions> storedQuestions, List<StoredQuizQuestions> storedQuizQuestions, List<CompletedQuestion> cq)
        {
            setup(student, SQuiz, storedQuestions, storedQuizQuestions, cq);
        }

        private string DifficultyScore(int cq)
        {
            if(cq <= 20)
            {
                return "Poor";
            }
            else if (cq <= 40)
            {
                return "Worse";
            }
            else if (cq <= 60)
            {
                return "Good";
            }
            else
            {
                return "Great";
            }
        }

        private void ResetQuestionButton_Click(object sender, EventArgs e)
        {
            QuestionClass qc = new QuestionClass();

            qc.ResetScores(completedQuestion);

            completedQuestion = new List<CompletedQuestion>();

            listView1.Items.Clear();
            listView1.Refresh();

            setup(Student, SelectedQuiz, ListOfStoredQuestions, QuizQuestionsId, null);
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
