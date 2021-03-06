﻿using System;
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
        int selectedmode = 0;

        List<StoredQuestions> questions = new List<StoredQuestions>();
        List<StoredQuestions> AllQuestions = new List<StoredQuestions>();

        public event EventHandler ClosedPage;

        public ViewAllQuestionsForm()
        {
            InitializeComponent();
            DifficultyCheckBox.Hide();
            QuestionClass qc = new QuestionClass();
            //All of the questions are loaded from the class and are used as a base to refer to
            AllQuestions = qc.LoadAllQuestions();
            QuestionListBox.DataSource = AllQuestions;
            QuestionListBox.DisplayMember = "DisplayItem";
            QuestionHeaderLabel.Hide();
            AnswerHeaderLabel.Hide();
            //Sets the question to hide the empty question details
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

        private SearchCriteria PredefDifficultySearch(SearchCriteria sc)
        {
            //If the user selects predefined difficulty this function is called in order to save the correct data to the Search Criteria
            if ((DifficultyCheckBox.CheckedItems.Count == 3) || (DifficultyCheckBox.CheckedItems.Count == 0))
            {
                //If the user doesn`t select a difficulty then all are selected
                sc.Difficulty = 1;
                sc.Difficulty1 = 2;
                sc.Difficulty2 = 3;
            }
            else
            {
                //Otherwise the selected difficulties are added to the search criteria
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





        private void QuestionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuestionListBox_DoubleClick(object sender, EventArgs e)
        {
            //When the user selects a question the question information is displayed over the previous, this code completes that action
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
                    //Assigning the selected question to a variable
                    QuestionPictureBox.Show();
                    QuestionPictureBox.Image = Image.FromFile(SelectedQuestion.PictureUrl);
                }

                QuestionLabel.Text = SelectedQuestion.Question;

                AnswerLabel.Text = SelectedQuestion.CorrectAns;
            }
        }

        private void SelectDifficultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
