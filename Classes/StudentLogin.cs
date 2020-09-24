using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class StudentLogin
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int ClassId { get; set; }
        public string Salt { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
