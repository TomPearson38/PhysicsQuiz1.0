using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class StoredQuestions
    {
        public int QuestionId { get; set; }
        public string CorrectAns { get; set; }
        public string IncorrectAns1 { get; set; }
        public string IncorrectAns2 { get; set; }
        public string IncorrectAns3 { get; set; }
        public string PictureUrl { get; set; }
        public int TopicId { get; set; }
        public int Area { get; set; }
        public int DifficultyRating { get; set; }
        public string Question { get; set; }
        public int XAnswered { get; set; }
        public int XAnsweredCorrectly { get; set; }
        public int CalculatedDifficulty { get; set; }

        public string DisplayItem
        {
            get
            {
                return $"{QuestionId}. {Question}";
            }
            
        }
    }
}
