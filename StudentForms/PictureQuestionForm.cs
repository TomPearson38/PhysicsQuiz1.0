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
    public partial class PictureQuestionForm : Form
    {
        public PictureQuestionForm()
        {
            InitializeComponent();
            QuestionPictureBox.Image = Image.FromFile("E:/PhysicsQuiz/Code/PhysicsQuiz1.0/QuestionPictures/Particles1.png");
        }
    }
}
