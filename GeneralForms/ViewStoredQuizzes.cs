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
        public StoredQuizzes ChosenQuiz = new StoredQuizzes();

        public event EventHandler ClosedPage;
        public event Action<ViewStoredQuizzes ,StoredQuizzes, List<StoredQuestions>> SelectedQuiz;

        bool formclosing = false;

        public ViewStoredQuizzes()
        {
            InitializeComponent();
            QuestionClass qc = new QuestionClass();
            Quizzes = qc.LoadQuizzes("%");
            QuizListBox.DataSource = Quizzes;
            QuizListBox.DisplayMember = "Name";

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
            QuizNameLabel.Show();
            InsertQuizNameLabel.Show();
            QuestionsLabel.Show();
            QuestionsListBox.Show();
            ExpandButton.Show();

            ChosenQuiz = (StoredQuizzes)QuizListBox.SelectedItem;
            InsertQuizNameLabel.Text = ChosenQuiz.Name;
            QuestionClass qc = new QuestionClass();
            SelectedQuestions = qc.FindQuestions(ChosenQuiz);
            QuestionsListBox.DataSource = SelectedQuestions;
            QuestionsListBox.DisplayMember = "Question";
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            formclosing = true;
            this.Close();
            ClosedPage?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (formclosing != true)
            {
                ReturnButton_Click(this, EventArgs.Empty);
            }
            base.OnFormClosed(e);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            QuestionClass qc = new QuestionClass();
            List<StoredQuizzes> SearchedQuizzes = new List<StoredQuizzes>();
            SearchedQuizzes = qc.LoadQuizzes(SearchBarTextBox.Text + "%");
            QuizListBox.DataSource = SearchedQuizzes;
            QuizListBox.DisplayMember = "Name";
        }

        private void SearchBarTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchBarTextBox.Text == "")
            {
                QuizListBox.DataSource = Quizzes;
                QuizListBox.DisplayMember = "Name";
            }
        }

        private void ExpandButton_Click(object sender, EventArgs e)
        {
            formclosing = true;
            this.Close();
            SelectedQuiz?.Invoke(this, ChosenQuiz, SelectedQuestions);
        }
    }
}
