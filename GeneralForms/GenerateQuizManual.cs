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

namespace PhysicsQuiz1._0.GeneralForms
{
    public partial class GenerateQuizManual : Form
    {
        int selectedmode = 0;

        List<StoredQuestions> questions = new List<StoredQuestions>(); //Holds all of the relevant stored questions based upon criteria
        List<StoredQuestions> AllQuestions = new List<StoredQuestions>(); //Holds the all of the stored questions
        ObservableCollection<StoredQuestions> NewQuiz = new ObservableCollection<StoredQuestions>(); //Holds the selected quiz questions by the user

        public event EventHandler ClosedPage; //Triggers an event from when the form is closed
        bool formclosing = false; //A boolean used to hold if the form is closing or not.

        public GenerateQuizManual()
        {
            InitializeComponent();
            QuestionClass qc = new QuestionClass();
            AllQuestions = qc.LoadAllQuestions(); //Loads the questions from the SQL database
            QuestionListBox.DataSource = AllQuestions; //Adds the questions to the question list box 
            QuestionListBox.DisplayMember = "DisplayItem";
            QuestionHeaderLabel.Hide();
            AnswerHeaderLabel.Hide();
            DifficultyCheckBox.Hide();
            //Sets the question to hide the empty question details
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void QuestionListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //When the user selects a question the question information is displayed over the previous, this code completes that action
            AnswerHeaderLabel.Show();
            QuestionHeaderLabel.Show();
            if (QuestionListBox.SelectedItem == null)
            {

            }
            else
            {
                //Assigning the selected question to a variable
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

        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            //All relevant question search criteria must be saved to the class SearchCriteria
            QuestionClass qc = new QuestionClass();
            SearchCriteria sc = new SearchCriteria();

            sc.Search = SearchBarTextBox.Text;
            //The user`s selected topics are added the the criteria
            //If they have selected no topics it will select them all
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
            //If the user selects no areas all of them are selected otherwise it will follow onto
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

            //The selected difficulty must be choesen and it will then assign values to search criteria based upon it
            if (selectedmode == 2)
            {
                sc = GeneratedDifficulty(sc);
                questions = qc.GetQuestionsForSearch(sc, true);
            }
            else
            {
                sc = PredefDifficultySearch(sc);
                questions = qc.GetQuestionsForSearch(sc, false);
            }


            QuestionListBox.DataSource = questions;
            QuestionListBox.DisplayMember = "DisplayItem";
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

        private SearchCriteria GeneratedDifficulty(SearchCriteria sc)
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            //When the add button is pressed the question must be coppied from the stored questions, to the NewQuiz collection
            if (QuestionListBox.SelectedItem == null)
            {
                return;
            }
            else if(NewQuiz.Count() == 15)
            {
                //Only 15 questions MAX are allowed per quiz so if they try to add too many the program will display this error
                MessageBox.Show("Error, Invalid number of items, please select between 3 and 15 questions. Remove items or create multiple quizzes.", "Error", MessageBoxButtons.OK);
                return;
            }
            StoredQuestions SelectedQuestion = (StoredQuestions)QuestionListBox.SelectedItem;

            //If the quiz already contains the question then this message will display
            if (NewQuiz.Contains(SelectedQuestion))
            {
                string message = "This question has already been added to the quiz!";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }

            //If none of the other criteria have occured it will add the question to the quiz
            NewQuiz.Add(SelectedQuestion);

            //Resets the variables
            QuizListBox.DataSource = null;
            QuizListBox.DataSource = NewQuiz;
            QuizListBox.DisplayMember = "Question";

            QuestionCapacityProgressBar.Increment(1);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            //If no question is selected then the question cannot be removed
            if (QuizListBox.SelectedItem == null)
            {
                return;
            }
            
            //The selected question is saved to a variable
            StoredQuestions SelectedQuestion = (StoredQuestions)QuizListBox.SelectedItem;

            //Removes the question from the quiz 
            NewQuiz.Remove(SelectedQuestion);

            QuizListBox.DataSource = null;
            QuizListBox.DataSource = NewQuiz;
            QuizListBox.DisplayMember = "Question";

            QuestionCapacityProgressBar.Increment(-1);

        }

        private void QuestionCapacityProgressBar_Click(object sender, EventArgs e)
        {
            //When the progress bar is pressed this message is displayed
            string message = $"There are {QuestionCapacityProgressBar.Value} out of 15 questions entered";
            string caption = "Information";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        private void CreateQuizButton_Click(object sender, EventArgs e)
        {
            //Once the user has decided that they want to create the quiz then a few validity checks are ran
            Name = QuizNameTextBox.Text;
            if(Name == "")
            {
                MessageBox.Show("Error Enter A Quiz Name", "Error", MessageBoxButtons.OK);
                return;
            }
            else if(NewQuiz.Count() < 3 || NewQuiz.Count > 15)
            {
                MessageBox.Show("Error, Invalid number of items, please select between 3 and 15 questions. Remove items or create multiple quizzes.", "Error", MessageBoxButtons.OK);
                return;
            }

            //If all criteria is passed then the number of questions in the quiz is added to the int[] array with their question ID
            int[] IdNum = new int[NewQuiz.Count()];

            foreach(StoredQuestions id in NewQuiz)
            {
                IdNum[NewQuiz.IndexOf(id)] = id.QuestionId;
            }

            QuestionClass qc = new QuestionClass();

            //Queries the SQL database to create the quiz
            qc.CreateQuiz(IdNum, Name);

            MessageBox.Show("Quiz Created!", "Success", MessageBoxButtons.OK);

        }

        private void GenerateQuizManual_Load(object sender, EventArgs e)
        {

        }

        private void ReturnToMenuButton_Click(object sender, EventArgs e)
        {
            //Returns to the menu
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

        private void DifficultyTypeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
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
    }
}
