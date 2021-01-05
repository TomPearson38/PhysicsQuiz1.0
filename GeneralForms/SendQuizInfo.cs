using PhysicsQuiz1._0.Classes;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace PhysicsQuiz1._0.GeneralForms
{
    public partial class SendQuizInfo : Form
    {
        //The user can select to send a project report to their teacher based upon their email that was declared then they created an account.

        StudentLogin Student = new StudentLogin();
        List<StoredQuestions> SQ = new List<StoredQuestions>();
        List<CompletedQuestion> CQ = new List<CompletedQuestion>();
        CreateHTMLTable createemail = new CreateHTMLTable();
        StoredQuizzes storedquizzes = new StoredQuizzes();
        DataAccess DA = new DataAccess();


        public SendQuizInfo(StudentLogin student, List<StoredQuestions> sq, List<CompletedQuestion> cq, StoredQuizzes storedQuizzes)
        {
            //The student, storedquestions that they have answered, their completed question and the quiz are passed into the sub and then made global by this sub.
            InitializeComponent();
            Student = student;
            SQ = sq;
            CQ = cq;
            storedquizzes = storedQuizzes;
        }

        private void SendQuizScoresButton_Click(object sender, System.EventArgs e)
        {
            //When the send quiz button is pressed, the teacher`s email is retreived from the database by this function
            string teacheremail = DA.GetTeacherEmail(Student.ClassId);

            //This portion of code signs into the email account created to send emails based on google mail
            SmtpClient clientDetails = new SmtpClient();
            clientDetails.Port = 587;
            clientDetails.Host = "smtp.gmail.com";
            clientDetails.EnableSsl = true;
            clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
            clientDetails.UseDefaultCredentials = false;
            clientDetails.Credentials = new NetworkCredential("physicsquizemailsend@gmail.com", "M!necraft1");

            //This portion creates the mail message
            MailMessage mailDetails = new MailMessage();
            mailDetails.From = new MailAddress("physicsquizemailsend@gmail.com");
            mailDetails.To.Add(teacheremail); //The recepient`s details are added here
            mailDetails.Subject = Student.FirstName + " " + Student.SecondName + "`s Scores for Test Named:" + storedquizzes.Name;
            mailDetails.IsBodyHtml = true;
            
            //This class creates the email body
            mailDetails.Body = createemail.createtable(SQ, CQ);

            //The email is then sent by this line of code here
            clientDetails.Send(mailDetails);

            MessageBox.Show("Your mail has been sent.");
        }

        private void ReturnButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
