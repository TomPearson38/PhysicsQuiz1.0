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
        private Random Dice = new Random();

        StoredQuestions CurrentQuestion = new StoredQuestions();

        public TextQuestionForm(StoredQuestions CQuestions)
        {
            InitializeComponent();

            QuestionLabel.Text = CurrentQuestion.Question;

            List<string> Answers = new List<string>();

            Answers.Add(CurrentQuestion.CorrectAns);
            Answers.Add(CurrentQuestion.IncorrectAns1);
            Answers.Add(CurrentQuestion.IncorrectAns2);
            Answers.Add(CurrentQuestion.IncorrectAns3);

            Answers = Answers.OrderBy(x => Guid.NewGuid()).ToList();

            AnswerRadioButton1.Text = Answers.ElementAt(0);
            AnswerRadioButton2.Text = Answers.ElementAt(1);
            AnswerRadioButton3.Text = Answers.ElementAt(2);
            AnswerRadioButton4.Text = Answers.ElementAt(3);

            CurrentQuestion = CQuestions;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var checkedButton = Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            if (checkedButton.Text == CurrentQuestion.CorrectAns)
            {

            }
            else
            {

            }
        }
    }
    
}
