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

namespace PhysicsQuiz1._0.StudentForms
{
    public partial class ViewStoredQuizzes : Form
    {
        public List<StoredQuizzes> Quizzes = new List<StoredQuizzes>();
        public List<StoredQuestions> SelectedQuestions = new List<StoredQuestions>();
        public List<StoredQuizQuestions> SelectedQuestionsId = new List<StoredQuizQuestions>();
        public StoredQuizzes ChosenQuiz = new StoredQuizzes();

        public event EventHandler ClosedPage;
        public event Action<ViewStoredQuizzes ,StoredQuizzes, List<StoredQuestions>, List<StoredQuizQuestions>> SelectedQuiz;

        bool formclosing = false;

        public ViewStoredQuizzes()
        {
            InitializeComponent();
            QuestionClass qc = new QuestionClass();
            Quizzes = qc.LoadQuizzes("%"); //Loads the quizzes from the database that contain any question text
            QuizListBox.DataSource = Quizzes; //Sets the source for the list box to be the loaded quizzes
            QuizListBox.DisplayMember = "Name"; //The displayed item from the stored quizzes to be the name of the quiz
            
            //Hides the quiz display info so that it only appears when the user clicks on an item
            QuizNameLabel.Hide();
            InsertQuizNameLabel.Hide();
            QuestionsLabel.Hide();
            QuestionsListBox.Hide();
            ExpandButton.Hide();
        }

        private void ViewStoredQuizzes_Load(object sender, EventArgs e)
        {

        }

        private void QuizListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Displays the quiz info
            QuizNameLabel.Show();
            InsertQuizNameLabel.Show();
            QuestionsLabel.Show();
            QuestionsListBox.Show();
            ExpandButton.Show();

            ChosenQuiz = (StoredQuizzes)QuizListBox.SelectedItem;  //The chosen quiz is saved to be the selected item from the list view
            InsertQuizNameLabel.Text = ChosenQuiz.Name; //The quiz name is displayed
            QuestionClass qc = new QuestionClass();
            SelectedQuestionsId = qc.FindQuestionsId(ChosenQuiz); //Retrives the quiz`s questions ID`s from the database
            SelectedQuestions = qc.GetStoredQuizQuestions(SelectedQuestionsId); //The ID`s related questions are then returned from the database
            QuestionsListBox.DataSource = SelectedQuestions; //The data source for the list box displaying the questions is set to the questions
            QuestionsListBox.DisplayMember = "Question"; //The displayed item from the stored quizzes to be the name of the quiz
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            formclosing = true; //When the return button is pressed the form closing is set to true and the code is triggered in order to close this form and open the previous form
            this.Close();
            ClosedPage?.Invoke(this, EventArgs.Empty); //Shows the previous form
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (formclosing != true) //If the page hasn`t set the form to close already it will summon the sub that manages it
            {
                ReturnButton_Click(this, EventArgs.Empty);
            }
            base.OnFormClosed(e); //It will then trigger the normal form closing event
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            QuestionClass qc = new QuestionClass();
            List<StoredQuizzes> SearchedQuizzes = new List<StoredQuizzes>();
            SearchedQuizzes = qc.LoadQuizzes(SearchBarTextBox.Text + "%"); //Loads the quizzes that start with the search criteria from the database
            QuizListBox.DataSource = SearchedQuizzes; //Sets the data source to be these searched quizzes
            QuizListBox.DisplayMember = "Name"; //The quiz name is displayed
        }

        private void SearchBarTextBox_TextChanged(object sender, EventArgs e)
        {
            //If the search criteria is deleted then the quizzes displayed are returned to default
            if (SearchBarTextBox.Text == "")
            {
                QuizListBox.DataSource = Quizzes;
                QuizListBox.DisplayMember = "Name";
            }
        }

        private void ExpandButton_Click(object sender, EventArgs e)
        {
            //Triggered when the user choses to expand a quizzes info
            //Form is closed
            formclosing = true;
            this.Close();
            SelectedQuiz?.Invoke(this, ChosenQuiz, SelectedQuestions, SelectedQuestionsId);
        }
    }
}
