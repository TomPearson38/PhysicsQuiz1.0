using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class StoredQuizzes
    {
        public int QuizId { get; set; } //The QuizID identifies the individual quiz records as the primary key. 
        public string Name { get; set; } //Name is the name that has been assigned to it by the user 
        public int Length { get; set; } //Length contains how many questions are included in the quiz
    }
}
