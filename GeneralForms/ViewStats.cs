using PhysicsQuiz1._0.Classes;
using PhysicsQuiz1._0.LoginScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.GeneralForms
{
    public partial class ViewStats : Form
    {
        public ViewStats(StudentLogin student, StoredQuizzes SQuiz, List<StoredQuestions> storedQuestions)
        {
            InitializeComponent();

            QuestionClass qc = new QuestionClass();

            CompletedQuiz CQuiz = qc.GetCompletedQuiz(SQuiz.Id, student.StudentId);

            if(CQuiz == null)
            {
                CQuiz.Id = SQuiz.Id;
                CQuiz.StudentId = student.StudentId;
                CQuiz.Length = SQuiz.Length;
            }
            

            ListViewItem a = new ListViewItem("Question");
            a.SubItems.Add("1");
            a.SubItems.Add("2");
            a.SubItems.Add("3");
            a.SubItems.Add("4");
            a.SubItems.Add("5");

            listView1.Items.Add(a);

            foreach(StoredQuestions sq in storedQuestions)
            {
                ListViewItem b = new ListViewItem(sq.Question);
                b.SubItems.Add(sq.Area.ToString());
                if (sq.TopicId == 1)
                {
                    b.SubItems.Add("Particles");
                }
                else if (sq.TopicId == 2)
                {
                    b.SubItems.Add("Waves");
                }
                else if (sq.TopicId == 3)
                {
                    b.SubItems.Add("Mechanics");
                }
                else if (sq.TopicId == 4)
                {
                    b.SubItems.Add("Materials");
                }
                else if (sq.TopicId == 5)
                {
                    b.SubItems.Add("Electricity");
                }
                b.SubItems.Add(CQuiz.Times)
            }


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
