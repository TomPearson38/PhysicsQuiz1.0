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
        public int CalculatedDifficulty { get; set; }
    }
    //Stores the scores of the student’s questions based on their student ID and QuestionID. 
    //It also stores the difficulty that has been calculated. As it is not linked to a specific quiz, 
    //it means that progress from questions is carried across questions 
}
