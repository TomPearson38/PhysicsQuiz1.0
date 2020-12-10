using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    class TClass
    {
        public int Id { get; set; } //A composite primary key containing the unique class ID created by an incrementing counter and the Teacher`s ID.
        public int TeacherId { get; set; }
    }
}
