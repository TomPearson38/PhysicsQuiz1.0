using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class StoredQuestions
    {
        //Holds the stored questions for the program.       
        public int QuestionId { get; set; } // The question ID is used as the primary key in the table  
                                            // It uniquely identifies each question. It is also used in other tables such as completed question 
                                            // to relate their scores to the individual questions.

        public string CorrectAns { get; set; } //The CorrectAns stores the correct answer (Objective 1.1), it can be anything such as a letter or a sentence, therefore it is a string.

        public string IncorrectAns1 { get; set; } //The incorrect answers must also be input so that the correct answer isn`t obvious as it is the answer relating to the question.
        public string IncorrectAns2 { get; set; }
        public string IncorrectAns3 { get; set; }

        public string PictureUrl { get; set; } //The PictureURL stores the path to the file in the program (Objective 2). It is allowed to be null as some questions don`t need a picture.

        public int TopicId { get; set; } //TopicID holds the number of the topic that the question relates to in a similar way to area which holds the area (Objective 7).
        public int Area { get; set; }

        public int DifficultyRating { get; set; }      //Difficulty rating is a predefined difficulty that can be used to filter questions.
        public string Question { get; set; }           //Question holds the text from the main question body (Objective 9).
        public int XAnswered { get; set; }             // XAnswered holds the number of times the question has been answered and XAnsweredCorrectly. Both of these values are then used to calculate the calculated difficulty.
        public int XAnsweredCorrectly { get; set; }    //This allows the calculated difficulty to scale based on how often it is answered correctly, making 
        public int CalculatedDifficulty { get; set; }  //it the most accurate difficulty rating when it has been answered a large number of times(Objective 9). 
                                                       //However, if it has only been answered a limited number of times it may incorrectly represent the question`s difficulty.

        public string DisplayItem //Embedded function combines the question ID and the question to form a display item that is used when displaying the question information.
        {
            get
            {
                return $"{QuestionId}. {Question}";
            }
            
        }
    }
}
