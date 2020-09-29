using PhysicsQuiz1._0.Classes;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.GeneralForms
{
    public partial class SendQuizInfo : Form
    {
        StudentLogin Student = new StudentLogin();
        List<StoredQuestions> SQ = new List<StoredQuestions>();
        List<CompletedQuestion> CQ = new List<CompletedQuestion>();
        CreateHTMLTable createemail = new CreateHTMLTable();
        StoredQuizzes storedquizzes = new StoredQuizzes();
        DataAccess DA = new DataAccess();


        public SendQuizInfo(StudentLogin student, List<StoredQuestions> sq, List<CompletedQuestion> cq, StoredQuizzes storedQuizzes)
        {
            InitializeComponent();
            Student = student;
            SQ = sq;
            CQ = cq;
            storedquizzes = storedQuizzes;
        }

        private void SendQuizScoresButton_Click(object sender, System.EventArgs e)
        {
            string teacheremail = DA.GetTeacherEmail(Student.ClassId);


            SmtpClient clientDetails = new SmtpClient();
            clientDetails.Port = 587;
            clientDetails.Host = "smtp.gmail.com";
            clientDetails.EnableSsl = true;
            clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
            clientDetails.UseDefaultCredentials = false;
            clientDetails.Credentials = new NetworkCredential("physicsquizemailsend@gmail.com", "M!necraft1");

            MailMessage mailDetails = new MailMessage();
            mailDetails.From = new MailAddress("physicsquizemailsend@gmail.com");
            mailDetails.To.Add(teacheremail);
            mailDetails.Subject = Student.FirstName + " " + Student.SecondName + "`s Scores for Test Named:" + storedquizzes.Name;
            mailDetails.IsBodyHtml = true;
            mailDetails.Body = createemail.createtable(SQ, CQ);

            clientDetails.Send(mailDetails);

            MessageBox.Show("Your mail has been sent.");
        }

        private void ReturnButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
