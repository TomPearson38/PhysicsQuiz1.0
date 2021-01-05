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
        //Views all the stats from the quiz that the student has answered
        private StudentLogin Student = new StudentLogin();

        List<StoredQuestions> ListOfStoredQuestions = new List<StoredQuestions>();

        StoredQuizzes SelectedQuiz = new StoredQuizzes();

        List<StoredQuizQuestions> QuizQuestionsId = new List<StoredQuizQuestions>(); //For each answered quiz question the quiz questionID must be saved to this list

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
            //In a seperate sub as the page may need to be refreshed when the student has answered the quiz again

            if (cquestion == null)
            {
                StudentInputNameLabel.Text = ($"{student.FirstName} {student.SecondName}");

                InputClassIdLabel.Text = student.ClassId.ToString();

                QuestionClass qc = new QuestionClass();
                //If the CompletedQuiz has not be loaded from the data base it will load it here 
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
                //If the questions have already been answered and the user wishes to return to their stats then the page needs to be refreshed but we don`t need to
                //query the database again
                listView1.Items.Clear();
                listView1.Refresh();
                completedQuestion = cquestion;
            }

            foreach (StoredQuestions sq in storedQuestions)
            {
                //Assigns the relevant stats the the rows for each question on the table
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
                
                //For each question answered in completed questions, the loop checks to see if it is equal to the current stored question ID.
                foreach (CompletedQuestion cq in completedQuestion)
                {
                    if (cq.QuestionId == sq.QuestionId)
                    {
                        //If the question is the same then the code adds the question`s stats to the table containing their scores (times answered, times correct, difficulty score, etc)
                        b.SubItems.Add(cq.XCompleted.ToString());
                        b.SubItems.Add(cq.XCorrect.ToString());
                        string score = DifficultyScore(cq.CalculatedDifficulty);
                        b.SubItems.Add(score);
                        b.SubItems.Add(cq.CalculatedDifficulty.ToString());
                        break; //braks the loop so that there is no more wasted loops
                    }
                }
                listView1.Items.Add(b);
            }


            Student = student;

            ListOfStoredQuestions = storedQuestions;

            SelectedQuiz = SQuiz;

            QuizQuestionsId = storedQuizQuestions;
            //saves varaibles to the program so that if the user starts a quiz then they don`t need to be retrived and are ready to be called

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
            //Closes the form and opens the previous one
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            //When pressed this button the quiz generates a report which will be sent to the teacher containing the student scores
            SendQuizInfo SQI = new SendQuizInfo(Student, ListOfStoredQuestions, completedQuestion, SelectedQuiz); //This opens the form containing the contorols in which the email is sent

            this.Hide();

            SQI.Show();

            SQI.FormClosed += (source, EventArgs) =>
            {
                this.Show();
            }; //The form closed event will be triggered when the user closes the send email form
        }

        private void StudyButton_Click(object sender, EventArgs e)
        {
            StartQuizForm SQF = new StartQuizForm(Student, SelectedQuiz, ListOfStoredQuestions, QuizQuestionsId, CQuiz, completedQuestion); //Opens the form containing the starting quiz information

            this.Hide();

            SQF.Show();

            SQF.CompletedQuiz += NewViewStats; //Method retrives the stats from the start quiz page based upon how well they did and then refreshes the page

            SQF.FormClosed += (source, EventArgs) =>
            {
                this.Show();
            }; //When the start quiz form is closed then this event is triggered

        }

        private void NewViewStats(StartQuizForm SQF, StudentLogin student, StoredQuizzes SQuiz, List<StoredQuestions> storedQuestions, List<StoredQuizQuestions> storedQuizQuestions, List<CompletedQuestion> cq)
        {
            setup(student, SQuiz, storedQuestions, storedQuizQuestions, cq); //Refresehs the page to display any changes that may have been created when the student either deletes question info or completes a question
        }

        private string DifficultyScore(int cq)
        {
            //This is where the numerical difficulty values are turned into worded difficulty ratinging based upon their scores
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
            //This button will reset the question scores
            QuestionClass qc = new QuestionClass();

            //Resets the questions in the database
            qc.ResetScores(completedQuestion);

            //Creates new completed questions
            completedQuestion = new List<CompletedQuestion>();

            //Clears the table on the current page displaying the question stats
            listView1.Items.Clear();
            listView1.Refresh();

            //Runs the setup sub again
            setup(Student, SelectedQuiz, ListOfStoredQuestions, QuizQuestionsId, null);
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
