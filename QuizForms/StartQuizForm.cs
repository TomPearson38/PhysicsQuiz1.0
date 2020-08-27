using PhysicsQuiz1._0.Classes;
using PhysicsQuiz1._0.GeneralForms;
using PhysicsQuiz1._0.StudentForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.QuizForms
{
    public partial class StartQuizForm : Form
    {
        public StudentLogin Student;
        public StoredQuizzes SQuiz;
        public List<StoredQuestions> storedQuestions;
        public List<StoredQuizQuestions> storedQuizQuestions;
        public CompletedQuiz completedQuiz;
        public List<CompletedQuestion> completedQuestion;

        public event Action<ViewStats ,StudentLogin, StoredQuizzes, List<StoredQuestions>, List<StoredQuizQuestions>> CompletedQuiz;

        public StartQuizForm(StudentLogin student, StoredQuizzes sQuiz, List<StoredQuestions> sQuestions, List<StoredQuizQuestions> storedQQuestions, CompletedQuiz cQuiz, List<CompletedQuestion> compQuestion)
        {
            InitializeComponent();
            Student = student;
            SQuiz = sQuiz;
            storedQuestions = sQuestions;
            storedQuizQuestions = storedQQuestions;
            completedQuiz = cQuiz;
            completedQuestion = compQuestion;
        }

        private async void StartQuizButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            List<StoredQuizQuestions> ShuffledQuizQuestions = storedQuizQuestions.OrderBy(x => Guid.NewGuid()).ToList();

            foreach (StoredQuizQuestions QuizQuestion in ShuffledQuizQuestions)
            {
                StoredQuestions CurrentQuestion = (storedQuestions.Find(x => x.QuestionId == QuizQuestion.QuestionId));

                CompletedQuestion CurrentCompletedQuestion = (completedQuestion.Find(x => x.QuestionId == QuizQuestion.QuestionId));

                if (CurrentQuestion.PictureUrl == "")
                {
                    var page2 = new TextQuestionForm(CurrentQuestion);

                    page2.Answered += (source, Correct) =>
                    {
                        storedQuestions.Remove(CurrentQuestion);
                        completedQuestion.Remove(CurrentCompletedQuestion);
                        if (Correct == true)
                        {
                            CurrentQuestion.XAnsweredCorrectly++;
                            CurrentCompletedQuestion.XCorrect++;
                        }
                        CurrentQuestion.XAnswered++;
                        CurrentCompletedQuestion.XCompleted++;
                        storedQuestions.Add(CurrentQuestion);
                        completedQuestion.Add(CurrentCompletedQuestion);
                    };

                    page2.ShowDialog();
                }
                else
                {
                    var page2 = new PictureQuestionForm(CurrentQuestion);

                    page2.Answered += (source, Correct) =>
                    {
                        storedQuestions.Remove(CurrentQuestion);
                        completedQuestion.Remove(CurrentCompletedQuestion);
                        if (Correct == true)
                        {
                            CurrentQuestion.XAnsweredCorrectly++;
                            CurrentCompletedQuestion.XCorrect++;
                        }
                        CurrentQuestion.XAnswered++;
                        CurrentCompletedQuestion.XCompleted++;
                        storedQuestions.Add(CurrentQuestion);
                        completedQuestion.Add(CurrentCompletedQuestion);
                    };

                    page2.ShowDialog();
                }
            }


            this.Show();
        }
    }
}
