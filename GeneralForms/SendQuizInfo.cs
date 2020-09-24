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


        public SendQuizInfo(StudentLogin student, List<StoredQuestions> sq, List<CompletedQuestion> cq, StoredQuizzes storedQuizzes)
        {
            InitializeComponent();
            Student = student;
            SQ = sq;
            CQ = cq;

            SmtpClient clientDetails = new SmtpClient();
            clientDetails.Port = 587;
            clientDetails.Host = "smtp.gmail.com";
            clientDetails.EnableSsl = true;
            clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
            clientDetails.UseDefaultCredentials = false;
            clientDetails.Credentials = new NetworkCredential("physicsquizemailsend@gmail.com", "M!necraft1");
            MailMessage mailDetails = new MailMessage();
            mailDetails.From = new MailAddress("physicsquizemailsend@gmail.com");
            mailDetails.To.Add("tomapearson38@gmail.com");
            mailDetails.Subject = student.FirstName + " " + student.SecondName + "`s Scores for Test Named:" + storedQuizzes.Name;
            mailDetails.IsBodyHtml = true;
            mailDetails.Body = createemail.createtable(Student, SQ, CQ);
            mailDetails.IsBodyHtml = true;
            clientDetails.Send(mailDetails);
            MessageBox.Show("Your mail has been sent.");
        }

    }
}
