using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class CompletedQuestion
    {
        public int StudentId { get; set; }
        public int QuestionId { get; set; }
        public int XCompleted { get; set; }
        public int XCorrect { get; set; }
    }
}
