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

        public event Action<StartQuizForm ,StudentLogin, StoredQuizzes, List<StoredQuestions>, List<StoredQuizQuestions>, List<CompletedQuestion>> CompletedQuiz; //This event is used to return the values of the completed quiz to the stats form when this form is closed

        public StartQuizForm(StudentLogin student, StoredQuizzes sQuiz, List<StoredQuestions> sQuestions, List<StoredQuizQuestions> storedQQuestions, CompletedQuiz cQuiz, List<CompletedQuestion> compQuestion)
        {
            InitializeComponent();
            //Parameters are assigned to the global variables
            Student = student;
            SQuiz = sQuiz;
            storedQuestions = sQuestions;
            storedQuizQuestions = storedQQuestions;
            completedQuiz = cQuiz;
            completedQuestion = compQuestion;
        }

        private void StartQuizButton_Click(object sender, EventArgs e)
        {
            //Hides the main form
            this.Hide();

            CalculateDifficulty cd = new CalculateDifficulty(); //Claculated difficulty is initilised

            //Trys to decide which option the user wants.
            //Adaptive question order: Questions answered incorrectly are presented more often than the correct ones
            //Standard: Questions are presented normally
            //If the user hasn`t selected an option a null exception is thrown
            try
            {
                if (SelectModeComboBox.SelectedItem.ToString() == "Adaptive Questions Order")
                {
                    foreach (CompletedQuestion cq in completedQuestion)
                    {
                        if ((cq.CalculatedDifficulty > 80) && (cq.XCompleted > 5))
                        {
                            //This removes the question from the quiz so that the user doesn`t answer this question that they have already answered correctly the majority of times
                            storedQuizQuestions.Remove(storedQuizQuestions.Find(x => x.QuestionId == cq.QuestionId));
                        }
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                //The null excpetion is caught and this message is displayed
                MessageBox.Show("Please Select A Question Mode", "Error", MessageBoxButtons.OK);
                return;
            }

            //The stored quiz question need to be shuffled so this line of code does that
            List<StoredQuizQuestions> ShuffledQuizQuestions = storedQuizQuestions.OrderBy(x => Guid.NewGuid()).ToList();

            foreach (StoredQuizQuestions QuizQuestion in ShuffledQuizQuestions)
            {
                StoredQuestions CurrentQuestion = (storedQuestions.Find(x => x.QuestionId == QuizQuestion.QuestionId)); //The current question is saved to the varaible called current question

                CompletedQuestion CurrentCompletedQuestion = (completedQuestion.Find(x => x.QuestionId == QuizQuestion.QuestionId)); 

                if (CurrentQuestion.PictureUrl == "") //If there is no picture URL then it doesn`t have a picture
                {
                    var page2 = new TextQuestionForm(CurrentQuestion); //The next form is created

                    page2.Answered += (source, Correct) => //This event is used to return the answer that the user selects and treats it accordingly based upon if the correct bool is true or false
                    {
                        //Question is removed from both storedquestion and completedquestion
                        storedQuestions.Remove(CurrentQuestion);
                        completedQuestion.Remove(CurrentCompletedQuestion);

                        //If the user has ansewred correctly then the current quiz question`s XAnsweredCorrect will increase by one
                        if (Correct == true)
                        {
                            CurrentQuestion.XAnsweredCorrectly++;
                            CurrentCompletedQuestion.XCorrect++;
                        }

                        //Regardless of if the answer was answered correctly the times answered counter must also increment by one
                        CurrentQuestion.XAnswered++;
                        CurrentCompletedQuestion.XCompleted++;

                        //The difficulty rating must be recalculated
                        CurrentQuestion.CalculatedDifficulty = cd.CalcDifficulty(CurrentQuestion.XAnswered, CurrentQuestion.XAnsweredCorrectly);
                        CurrentCompletedQuestion.CalculatedDifficulty = cd.CalcDifficulty(CurrentCompletedQuestion.XCompleted, CurrentCompletedQuestion.XCorrect);
                        
                        //The question is added back to the storedquestion and complted question lists
                        storedQuestions.Add(CurrentQuestion);
                        completedQuestion.Add(CurrentCompletedQuestion);
                    };

                    //Displays the question answering form
                    page2.ShowDialog();
                }
                else
                {
                    var page2 = new PictureQuestionForm(CurrentQuestion);

                    page2.Answered += (source, Correct) =>
                    {
                        //Question is removed from both storedquestion and completedquestion
                        storedQuestions.Remove(CurrentQuestion);
                        completedQuestion.Remove(CurrentCompletedQuestion);

                        //If the user has ansewred correctly then the current quiz question`s XAnsweredCorrect will increase by one
                        if (Correct == true)
                        {
                            CurrentQuestion.XAnsweredCorrectly++;
                            CurrentCompletedQuestion.XCorrect++;
                        }

                        //Regardless of if the answer was answered correctly the times answered counter must also increment by one
                        CurrentQuestion.XAnswered++;
                        CurrentCompletedQuestion.XCompleted++;

                        //The difficulty rating must be recalculated
                        CurrentQuestion.CalculatedDifficulty = cd.CalcDifficulty(CurrentQuestion.XAnswered, CurrentQuestion.XAnsweredCorrectly);
                        CurrentCompletedQuestion.CalculatedDifficulty = cd.CalcDifficulty(CurrentCompletedQuestion.XCompleted, CurrentCompletedQuestion.XCorrect);
                        
                        //The question is added back to the storedquestion and complted question lists
                        storedQuestions.Add(CurrentQuestion);
                        completedQuestion.Add(CurrentCompletedQuestion);
                    };

                    //Displays the question answering form
                    page2.ShowDialog();
                }
                
            }
            //Question class is initilized
            QuestionClass qc = new QuestionClass();

            //The method update scored is called in order to refresh the scored that are in the database
            qc.UpdateScores(storedQuestions, completedQuestion);

            this.Show();

            
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            //The scores are returned to the previous form in order to be refreshed in the scores table
            CompletedQuiz?.Invoke(this, Student, SQuiz, storedQuestions, storedQuizQuestions, completedQuestion);
            this.Close();
        }
    }
}
