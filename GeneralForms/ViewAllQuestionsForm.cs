using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhysicsQuiz1._0.Classes;

namespace PhysicsQuiz1._0.GeneralForms
{
    public partial class ViewAllQuestionsForm : Form
    {

        bool formclosing = false;

        List<StoredQuestions> questions = new List<StoredQuestions>();
        List<StoredQuestions> AllQuestions = new List<StoredQuestions>();

        public event EventHandler ClosedPage;

        public ViewAllQuestionsForm()
        {
            InitializeComponent();
            QuestionClass qc = new QuestionClass();
            AllQuestions = qc.LoadAllQuestions();
            QuestionListBox.DataSource = AllQuestions;
            QuestionListBox.DisplayMember = "DisplayItem";
            QuestionHeaderLabel.Hide();
            AnswerHeaderLabel.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewAllQuestionsForm_Load(object sender, EventArgs e)
        {
                
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            QuestionClass qc = new QuestionClass();
            string search = SearchBarTextBox.Text;
            int Difficulty = 0;
            int Difficulty1 = 0;
            int Difficulty2 = 0;
            int Area = 0;
            int Area1 = 0;
            int Topic1 = 0;
            int Topic2 = 0;
            int Topic3 = 0;
            int Topic4 = 0;
            int Topic5 = 0;

            if ((DifficultyCheckBox.CheckedItems.Count == 3) || (DifficultyCheckBox.CheckedItems.Count == 0))
            {
                Difficulty = 1;
                Difficulty1 = 2;
                Difficulty2 = 3;
            }
            else
            {
                if (DifficultyCheckBox.CheckedItems.Contains("1"))
                {
                    Difficulty = 1;
                }

                if (DifficultyCheckBox.CheckedItems.Contains("2"))
                {
                    Difficulty1 = 2;
                }

                if (DifficultyCheckBox.CheckedItems.Contains("3"))
                {
                    Difficulty2 = 3;
                }
            }

            if ((TopicCheckedListBox.CheckedItems.Count == 0) || (TopicCheckedListBox.CheckedItems.Count == 5))
            {
                Topic1 = 1;
                Topic2 = 2;
                Topic3 = 3;
                Topic4 = 4;
                Topic5 = 5;
            }
            else
            {
                if (TopicCheckedListBox.CheckedItems.Contains("Particles"))
                {
                    Topic1 = 1;
                }

                if (TopicCheckedListBox.CheckedItems.Contains("Waves"))
                {
                    Topic2 = 2;
                }

                if (TopicCheckedListBox.CheckedItems.Contains("Mechanics"))
                {
                    Topic3 = 3;
                }


                if (TopicCheckedListBox.CheckedItems.Contains("Materials"))
                {
                    Topic4 = 4;
                }


                if (TopicCheckedListBox.CheckedItems.Contains("Electricity"))
                {
                    Topic5 = 5;
                }

            }

            if (AreaCheckedListBox.CheckedItems.Count == 0 || AreaCheckedListBox.CheckedItems.Count == 2)
            {
                Area = 1;
                Area1 = 2;
            }
            else
            {
                if (AreaCheckedListBox.CheckedItems.Contains("Recall"))
                {
                    Area = 1;
                    Area1 = 1;
                }
                else
                {
                    Area = 2;
                    Area1 = 2;
                }
            }

            questions = qc.GetQuestionsExistingDifficulty(search, Topic1, Topic2, Topic3, Topic4, Topic5, Difficulty, Difficulty1, Difficulty2, Area, Area1);
            QuestionListBox.DataSource = questions;
            QuestionListBox.DisplayMember = "DisplayItem";
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuestionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void QuestionListBox_DoubleClick(object sender, EventArgs e)
        {
            AnswerHeaderLabel.Show();
            QuestionHeaderLabel.Show();
            if (QuestionListBox.SelectedItem == null)
            {
                
            }
            else
            {
                StoredQuestions SelectedQuestion = (StoredQuestions)QuestionListBox.SelectedItem;
                if (SelectedQuestion.PictureUrl == "" || SelectedQuestion.PictureUrl == null)
                {
                    QuestionPictureBox.Hide();
                }
                else
                {
                    QuestionPictureBox.Show();
                    QuestionPictureBox.Image = Image.FromFile(SelectedQuestion.PictureUrl);
                }

                QuestionLabel.Text = SelectedQuestion.Question;

                AnswerLabel.Text = SelectedQuestion.CorrectAns;
            }
        }

        private void ReturnToMenuButton_Click(object sender, EventArgs e)
        {
            formclosing = true;
            this.Close();
            ClosedPage?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (formclosing != true)
            {
                ReturnToMenuButton_Click(this, EventArgs.Empty);
            }
            base.OnFormClosed(e);
        }
    }
}
