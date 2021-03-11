using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class TeacherLogin : Login
    {
        public int TeacherId { get; set; } //The TeacherID is a foreign key for multiple tables such as completed question. It allows us to identify each teacher easily and efficiently 
        public string Title { get; set; }
    }
}
