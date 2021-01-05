using PhysicsQuiz1._0.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.StudentForms
{
    public partial class TextQuestionForm : Form
    {
        public event EventHandler<bool> Answered; //Event for when the question has been answered is created

        StoredQuestions CurrentQuestion = new StoredQuestions(); //The current question is stored here

        public TextQuestionForm(StoredQuestions CQuestions) 
        {
            InitializeComponent();

            CurrentQuestion = CQuestions; //The paramter of the current question is passed into the form

            QuestionLabel.Text = CurrentQuestion.Question; //The currentquestion`s question is displayed

            List<string> Answers = new List<string>(); //A new list of answers is created

            //Each individual answer that is stored in currentquestion including the correct answer and the 3 incorrect ones
            Answers.Add(CurrentQuestion.CorrectAns);
            Answers.Add(CurrentQuestion.IncorrectAns1);
            Answers.Add(CurrentQuestion.IncorrectAns2);
            Answers.Add(CurrentQuestion.IncorrectAns3);

            //Answers are shuffled
            Answers = Answers.OrderBy(x => Guid.NewGuid()).ToList();

            //The answers are assigned to the radio buttons
            AnswerRadioButton1.Text = $"{Answers.ElementAt(0)}";
            AnswerRadioButton2.Text = $"{ Answers.ElementAt(1)}";
            AnswerRadioButton3.Text = $"{ Answers.ElementAt(2)}";
            AnswerRadioButton4.Text = $"{ Answers.ElementAt(3)}";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            RadioButton checkedButton;

            //Checks to see if the user has selected an answer
            if (AnswerRadioButton1.Checked == true)
            {
                checkedButton = AnswerRadioButton1;
            }
            else if (AnswerRadioButton2.Checked == true)
            {
                checkedButton = AnswerRadioButton2;
            }
            else if (AnswerRadioButton3.Checked == true)
            {
                checkedButton = AnswerRadioButton3;
            }
            else if (AnswerRadioButton4.Checked == true)
            {
                checkedButton = AnswerRadioButton4;
            }
            else
            {
                return;
            }

            //Answer selected is compared against the correct answer
            //A message is displayed telling the user their result and their result is returned
            if (checkedButton.Text == CurrentQuestion.CorrectAns)
            {
                MessageBox.Show("Correct", "Well Done", MessageBoxButtons.OK);
                Answered?.Invoke(this, true);
            }
            else
            {
                MessageBox.Show("Incorrect", "Try Again", MessageBoxButtons.OK);
                Answered?.Invoke(this, false);
            }

            this.Close(); //Form is closed
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
