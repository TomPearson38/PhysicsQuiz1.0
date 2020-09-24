using PhysicsQuiz1._0.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.StudentForms
{
    public partial class AutoCreateForm : Form
    {
        int selectedmode = 0;
        List<StoredQuestions> questions = new List<StoredQuestions>();
        List<StoredQuestions> AllQuestions = new List<StoredQuestions>();

        public event EventHandler ClosedPage;
        bool formclosing = false;

        public AutoCreateForm()
        {
            InitializeComponent();
            DifficultyCheckBox.Hide();
        }

        private void DifficultyTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DifficultyCheckBox.Show();
            if (DifficultyTypeComboBox.SelectedItem.ToString() == "Pre-defined Difficulty Setting")
            {
                selectedmode = 1;
                DifficultyCheckBox.Items.Clear();
                DifficultyCheckBox.Items.Add("1");
                DifficultyCheckBox.Items.Add("2");
                DifficultyCheckBox.Items.Add("3");
                DifficultyCheckBox.Height = 49;
            }
            else if (DifficultyTypeComboBox.SelectedItem.ToString() == "Machine Generated Difficulty Setting")
            {
                selectedmode = 2;
                DifficultyCheckBox.Items.Clear();
                DifficultyCheckBox.Items.Add("Advanced");
                DifficultyCheckBox.Items.Add("Hard");
                DifficultyCheckBox.Items.Add("Average");
                DifficultyCheckBox.Items.Add("Easy");
                DifficultyCheckBox.Height = 64;
            }
            else
            {
                selectedmode = 0;
                DifficultyCheckBox.Hide();
            }

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            int numberselected;
            QuestionClass qc = new QuestionClass();
            SearchCriteria sc = new SearchCriteria();

            try
            {
                if (int.Parse(NumberOfQuestionsTextBox.Text) <= 15 && int.Parse(NumberOfQuestionsTextBox.Text) >= 3)
                {
                    numberselected = int.Parse(NumberOfQuestionsTextBox.Text);
                }
                else
                {
                    MessageBox.Show("Outside bounds, please enter a value between 3 and 15", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invaid Number Entered, please enter a value between 3 and 15", "Error", MessageBoxButtons.OK);
                return;
            }

            if ((TopicCheckedListBox.CheckedItems.Count == 0) || (TopicCheckedListBox.CheckedItems.Count == 5))
            {
                sc.Topic1 = 1;
                sc.Topic2 = 2;
                sc.Topic3 = 3;
                sc.Topic4 = 4;
                sc.Topic5 = 5;
            }
            else
            {
                if (TopicCheckedListBox.CheckedItems.Contains("Particles"))
                {
                    sc.Topic1 = 1;
                }

                if (TopicCheckedListBox.CheckedItems.Contains("Waves"))
                {
                    sc.Topic2 = 2;
                }

                if (TopicCheckedListBox.CheckedItems.Contains("Mechanics"))
                {
                    sc.Topic3 = 3;
                }


                if (TopicCheckedListBox.CheckedItems.Contains("Materials"))
                {
                    sc.Topic4 = 4;
                }


                if (TopicCheckedListBox.CheckedItems.Contains("Electricity"))
                {
                    sc.Topic5 = 5;
                }
            }

            if (AreaCheckedListBox.CheckedItems.Count == 0 || AreaCheckedListBox.CheckedItems.Count == 2)
            {
                sc.Area = 1;
                sc.Area1 = 2;
            }
            else
            {
                if (AreaCheckedListBox.CheckedItems.Contains("Recall"))
                {
                    sc.Area = 1;
                    sc.Area1 = 1;
                }
                else
                {
                    sc.Area = 2;
                    sc.Area1 = 2;
                }
            }

            if (selectedmode == 2)
            {
                sc = GeneratedDifficulty(sc);
                AllQuestions = qc.GetQuestionsForSearch(sc, true);
            }
            else
            {
                sc = PredefDifficultySearch(sc);
                AllQuestions = qc.GetQuestionsForSearch(sc, false);
            }

            List<StoredQuestions> ShuffledQuizQuestions = AllQuestions.OrderBy(x => Guid.NewGuid()).ToList();
            questions = new List<StoredQuestions>();

            int count = 0;
            while(count < int.Parse(NumberOfQuestionsTextBox.Text) && ShuffledQuizQuestions.Count() > count)
            {
                questions.Add(ShuffledQuizQuestions.ElementAt(count));
                count++;
            }


            QuestionListBox.DataSource = questions;
            QuestionListBox.DisplayMember = "Question";

            InformationLabel.Text = "Selected " + questions.Count + " questions from criteria returning " + AllQuestions.Count() + " Questions";
        }

        public SearchCriteria GeneratedDifficulty(SearchCriteria sc)
        {
            if (DifficultyCheckBox.CheckedItems.Count == 4 || DifficultyCheckBox.CheckedItems.Count == 0)
            {
                sc.Difficulty = 1;
                sc.Difficulty1 = 2;
                sc.Difficulty2 = 3;
                sc.Difficulty3 = 4;
            }
            else
            {
                if (DifficultyCheckBox.CheckedIndices.Contains(0))
                {
                    sc.Difficulty = 1;
                }
                if (DifficultyCheckBox.CheckedItems.Contains(1))
                {
                    sc.Difficulty1 = 2;
                }
                if (DifficultyCheckBox.CheckedItems.Contains(2))
                {
                    sc.Difficulty2 = 3;
                }
                if (DifficultyCheckBox.CheckedItems.Contains(3))
                {
                    sc.Difficulty3 = 4;
                }
            }
            return sc;
        }

        private SearchCriteria PredefDifficultySearch(SearchCriteria sc)
        {
            if ((DifficultyCheckBox.CheckedItems.Count == 3) || (DifficultyCheckBox.CheckedItems.Count == 0))
            {
                sc.Difficulty = 1;
                sc.Difficulty1 = 2;
                sc.Difficulty2 = 3;
            }
            else
            {
                if (DifficultyCheckBox.CheckedItems.Contains("1"))
                {
                    sc.Difficulty = 1;
                }

                if (DifficultyCheckBox.CheckedItems.Contains("2"))
                {
                    sc.Difficulty1 = 2;
                }

                if (DifficultyCheckBox.CheckedItems.Contains("3"))
                {
                    sc.Difficulty2 = 3;
                }
            }

            return sc;
        }

        private void ReshuffleButton_Click(object sender, EventArgs e)
        {
            List<StoredQuestions> ShuffledQuizQuestions = AllQuestions.OrderBy(x => Guid.NewGuid()).ToList();
            questions = new List<StoredQuestions>();

            int count = 0;
            while (count < int.Parse(NumberOfQuestionsTextBox.Text) && ShuffledQuizQuestions.Count() > count)
            {
                questions.Add(ShuffledQuizQuestions.ElementAt(count));
                count++;
            }


            QuestionListBox.DataSource = questions;
            QuestionListBox.DisplayMember = "Question";
        }

        private void CreateQuizButton_Click(object sender, EventArgs e)
        {
            Name = QuizNameTextBox.Text;
            if (Name == "")
            {
                MessageBox.Show("Error Enter A Quiz Name", "Error", MessageBoxButtons.OK);
                return;
            }
            else if (questions.Count() < 3 || questions.Count > 15)
            {
                MessageBox.Show("Error, Invalid number of items, please select between 3 and 15 questions. Remove items or create multiple quizzes.", "Error", MessageBoxButtons.OK);
                return;
            }


            int[] IdNum = new int[questions.Count()];

            foreach (StoredQuestions id in questions)
            {
                IdNum[questions.IndexOf(id)] = id.QuestionId;
            }

            QuestionClass qc = new QuestionClass();

            qc.CreateQuiz(IdNum, Name);

            MessageBox.Show("Quiz Created!", "Success", MessageBoxButtons.OK);

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
    }
}
