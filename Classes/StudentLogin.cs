using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class StudentLogin : Login
    {
        //Holds the login information for the student
        public int StudentId { get; set; } //foreign key for multiple tables such as completed question. It allows us to identify each student easily and efficiently
        public string FirstName { get; set; }
        public string FullName //Encapsulation 
        { //The Firstname and Surname variables stores the student`s names and the FullName string combines the two for ease of use. 
            get
            {
                return FirstName + " " + SecondName;
            }
        }
    }
}
