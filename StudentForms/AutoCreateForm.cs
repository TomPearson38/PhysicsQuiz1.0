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
        List<StoredQuestions> questions = new List<StoredQuestions>(); //Holds all of the relevant stored questions based upon criteria
        List<StoredQuestions> AllQuestions = new List<StoredQuestions>(); //Holds the all of the stored questions

        public event EventHandler ClosedPage; //Triggers an event from when the form is closed
        bool formclosing = false; //A boolean used to hold if the form is closing or not.

        public AutoCreateForm()
        {
            InitializeComponent();
            DifficultyCheckBox.Hide();
        }

        private void DifficultyTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Changes the contents of the difficulty combo box based upon which option the user selects
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
                //The user specifies number of questions that they want the quiz to contain
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
                //If the user doesn`t input a correct number of questions then the exception is thrown
                MessageBox.Show("Invaid Number Entered, please enter a value between 3 and 15", "Error", MessageBoxButtons.OK);
                return;
            }

            if ((TopicCheckedListBox.CheckedItems.Count == 0) || (TopicCheckedListBox.CheckedItems.Count == 5))
            {
                //If no question topics or all of them are selected then all of the topics are selected
                sc.Topic1 = 1;
                sc.Topic2 = 2;
                sc.Topic3 = 3;
                sc.Topic4 = 4;
                sc.Topic5 = 5;
            }
            else
            {
                //Otherwise each question must be checked individually to see if it has been selected
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
                //If no question areas or all of them are selected then all of the areas are selected
                sc.Area = 1;
                sc.Area1 = 2;
            }
            else
            {
                //Otherwise each question must be checked individually to see if it has been selected
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

            //The selected difficulty must be chosen and it will then assign values to search criteria based upon it
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

            //The stored questions are reshuffled by this line of code
            List<StoredQuestions> ShuffledQuizQuestions = AllQuestions.OrderBy(x => Guid.NewGuid()).ToList();
            questions = new List<StoredQuestions>();

            //The first to specified number by the user number of questions is saved to the list to be returned containing the quiz questions
            int count = 0;
            while(count < int.Parse(NumberOfQuestionsTextBox.Text) && ShuffledQuizQuestions.Count() > count)
            {
                questions.Add(ShuffledQuizQuestions.ElementAt(count));
                count++;
            }

            //Display members are clarified
            QuestionListBox.DataSource = questions;
            QuestionListBox.DisplayMember = "Question";

            //Displays how many question have been selected from the specified count in case there weren`t enough questions based upon their criteria
            InformationLabel.Text = "Selected " + questions.Count + " questions from criteria returning " + AllQuestions.Count() + " Questions";
        }

        public SearchCriteria GeneratedDifficulty(SearchCriteria sc)
        {
            //If the user selects Generated difficulty this function is called in order to save the correct data to the Search Criteria
            if (DifficultyCheckBox.CheckedItems.Count == 4 || DifficultyCheckBox.CheckedItems.Count == 0)
            {
                //If the user doesn`t select a difficulty then all are selected
                sc.Difficulty = 1;
                sc.Difficulty1 = 2;
                sc.Difficulty2 = 3;
                sc.Difficulty3 = 4;
            }
            else
            {
                //Otherwise the selected difficulties are added to the search criteria
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
            //If the user selects predefined difficulty this function is called in order to save the correct data to the Search Criteria
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
            //Selects a different number of questions from the specified criteria
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
            //User names the quiz
            Name = QuizNameTextBox.Text;
            if (Name == "")
            {
                MessageBox.Show("Error Enter A Quiz Name", "Error", MessageBoxButtons.OK);
                return;
            }
            else if (questions.Count() < 3 || questions.Count > 15)
            {
                //If the program has returned an invalid number of questions this error message will be displayed
                MessageBox.Show("Error, Invalid number of items, please select between 3 and 15 questions. Remove items or create multiple quizzes.", "Error", MessageBoxButtons.OK);
                return;
            }

            //Holds the ID`s of the question that have been selected
            int[] IdNum = new int[questions.Count()];

            foreach (StoredQuestions id in questions)
            {
                IdNum[questions.IndexOf(id)] = id.QuestionId;
            }

            //The questions that have been returned based upon the criteria are passed into the CreateQuiz Method of questionclass
            QuestionClass qc = new QuestionClass();
            qc.CreateQuiz(IdNum, Name);

            //Displays a success message
            MessageBox.Show("Quiz Created!", "Success", MessageBoxButtons.OK);

        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            //Closes the form by clicking return button
            formclosing = true;
            this.Close();
            ClosedPage?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            //Closes the form by clicking the x
            if (formclosing != true)
            {
                ReturnButton_Click(this, EventArgs.Empty);
            }
            base.OnFormClosed(e);
        }
    }
}
