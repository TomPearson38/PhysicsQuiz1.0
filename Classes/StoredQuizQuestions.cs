using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class StoredQuizQuestions
    {
        //Stored Questions holds the questions that each quiz contains. When a quiz is created each question that it is related to is saved in this table. 
        //The QuizID holds the ID of the quiz that the entry is refering to and then the QuestionID relates to the StoredQuestion which is saved to the Quiz. 
        //That way when Quizzes of different lengths are created, there will be no wasted
        public int QuizId { get; set; }  
        public int QuestionId { get; set; }
    }
}
