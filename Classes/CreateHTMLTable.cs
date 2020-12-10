using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class CreateHTMLTable
    {
        //Encapsulation
        //OOP
        //HTML Code
        //2D Array

        List<StoredQuestions> SQ = new List<StoredQuestions>();
        List<CompletedQuestion> CQ = new List<CompletedQuestion>();

        CalculateDifficulty CD = new CalculateDifficulty();

        //Declaration of variables where SQ will contain the stored questions that data will be calculated about
        //CQ stores the questions that the students have answered
        //CD is the class of calculating difficulty based upon the data that has been input.


        int[,] Area = new int[2,2]; //Contains a running total containg how many times each question topic has been answered and how many times it is correct.
        int[,] Topic = new int[5,2];

        public string createtable(List<StoredQuestions> sq, List<CompletedQuestion> CD)
        {
            SQ = sq;
            CQ = CD;

            string finalresult = "";
            finalresult = finalresult + createheader();
            finalresult = finalresult + CreateQuestionTable();
            finalresult = finalresult + "<br><br>";
            finalresult = finalresult + CreateAreaTable();
            finalresult = finalresult + "<br><br>";
            finalresult = finalresult + CreateTopicTable();
            finalresult = finalresult + "</body></ html >";


            return finalresult;

            //The main sub. It contains the while string finalresult which will return the table that has been created in HTML
            //Each part of its deceleration is broken into subs and combined at the end.
        }

        private string createheader()
        {
            string header = "<html><head><style>table, th, td {  border: 1px solid black;}</style></head><body><h2>Question Breakdown</h2>";
            return header;
            //Declares the table`s header 
        }

        private string CreateQuestionTable()
        {
            string QuestionTable = "<table style=\"width: 100 % \" ><tr><th>Question</th><th>Area</th><th>Topic</th><th>Knowledge</th><th>Times Answered</th><th>Times Correct</th></tr>";
            foreach (StoredQuestions sq in SQ)
            {
                string row = "";
                foreach (CompletedQuestion CD in CQ)
                {
                    if (CD.QuestionId == sq.QuestionId)
                    {
                        row = row + "<td>"+ sq.Question +"</td>";
                        if (sq.Area == 1)
                        {
                            row = row + "<td> Recall </td>";
                            Area[0, 0] = Area[0, 0] + CD.XCorrect;
                            Area[0, 1] = Area[0, 1] + CD.XCompleted;
                        }
                        else
                        {
                            row = row + "<td> Calculation </td>";
                            Area[1, 0] = Area[1, 0] + CD.XCorrect;
                            Area[1, 1] = Area[1, 1] + CD.XCompleted;
                        }
                        //Adds the current question type to the related array containg the total times the category has been answered and how mamy times it has been enter correctly


                        if (sq.TopicId == 1)
                        {
                            row = row + "<td> Particles </td>";
                            Topic[0, 0] = Topic[0, 0] + CD.XCorrect;
                            Topic[0, 1] = Topic[0, 1] + CD.XCompleted;
                        }
                        else if (sq.TopicId == 2)
                        {
                            row = row + "<td> Waves </td>";
                            Topic[1, 0] = Topic[1, 0] + CD.XCorrect;
                            Topic[1, 1] = Topic[1, 1] + CD.XCompleted;
                        }
                        else if (sq.TopicId == 3)
                        {
                            row = row + "<td> Mechanics </td>";
                            Topic[2, 0] = Topic[2, 0] + CD.XCorrect;
                            Topic[2, 1] = Topic[2, 1] + CD.XCompleted;
                        }
                        else if (sq.TopicId == 4)
                        {
                            row = row + "<td> Materials </td>";
                            Topic[3, 0] = Topic[3, 0] + CD.XCorrect;
                            Topic[3, 1] = Topic[3, 1] + CD.XCompleted;
                        }
                        else if (sq.TopicId == 5)
                        {
                            row = row + "<td> Electricity </td>";
                            Topic[4, 0] = Topic[4, 0] + CD.XCorrect;
                            Topic[4, 1] = Topic[4, 1] + CD.XCompleted;
                        }

                        //Topic breakdown for the scores on question. It displays the question topic and adds their score on the question to the topic array.

                        string score = DifficultyScore(CD.CalculatedDifficulty);
                        row = row + "<td>"+ score + "</td>";
                        row = row + "<td>" + CD.XCompleted.ToString() + "</td>";
                        row = row + "<td>" + CD.XCorrect.ToString() + "</td>";
                        row = row + "</tr>";
                        break;

                        //Displays the times the question is correct and how many times it has been answered.
                    }
                }
                QuestionTable = QuestionTable + row;
            }
            QuestionTable = QuestionTable + "</table>";
            return QuestionTable;
            //Closes the table and returns it
        }

        private string DifficultyScore(int CD)
        {
            //Returns the worded difficulty rating for the percentage score that the user has
            if (CD <= 20)
            {
                return "Poor";
            }
            else if (CD <= 40)
            {
                return "Worse";
            }
            else if (CD <= 60)
            {
                return "Good";
            }
            else
            {
                return "Great";
            }
        }

        private string CreateAreaTable()
        {
            //Creates the area table based upon the scores that have been gathered previously when creating the question table in the Array Area[]
            string AreaTable;
            AreaTable = "<h2> Area Results </h2><table style=\"width:50 %\"><tr><th>Recall</th><th>Calculations</th></tr>";
            AreaTable = AreaTable + "<tr><td>"+ CD.CalcDifficulty(Area[0,1], Area[0,0]) +"%</td><td>" + CD.CalcDifficulty(Area[1, 1], Area[1, 0]) + "%</td></tr>";
            AreaTable = AreaTable + "</table>";
            return AreaTable;
        }

        private string CreateTopicTable()
        {
            //Creates the Topic table based upon the scores that have been gathered previously when creating the question table in the Array Topic[]
            string TopicTable;
            TopicTable = "<h2>Topic Results</h2><table style=\"width: 100 % \"><tr><th>Particles</th><th>Waves</th><th>Mechanics</th><th>Materials</th><th>Electricty</th></tr><tr>";

            if(Topic[0,0] != 0)
            {
                TopicTable = TopicTable + "<td>" + CD.CalcDifficulty(Topic[0, 1], Topic[0, 0]) + "%</td>";
            }
            else
            {
                TopicTable = TopicTable + "<td> </td>";
            }

            if (Topic[1, 0] != 0)
            {
                TopicTable = TopicTable + "<td>" + CD.CalcDifficulty(Topic[1, 1], Topic[1, 0]) + "%</td>";
            }
            else
            {
                TopicTable = TopicTable + "<td> </td>";
            }

            if (Topic[2, 0] != 0)
            {
                TopicTable = TopicTable + "<td>" + CD.CalcDifficulty(Topic[2, 1], Topic[2, 0]) + "%</td>";
            }
            else
            {
                TopicTable = TopicTable + "<td> </td>";
            }

            if (Topic[3, 0] != 0)
            {
                TopicTable = TopicTable + "<td>" + CD.CalcDifficulty(Topic[3, 1], Topic[3, 0]) + "%</td>";
            }
            else
            {
                TopicTable = TopicTable + "<td> </td>";
            }

            if (Topic[4, 0] != 0)
            {
                TopicTable = TopicTable + "<td>" + CD.CalcDifficulty(Topic[4, 1], Topic[4, 0]) + "%</td>";
            }
            else
            {
                TopicTable = TopicTable + "<td> </td>";
            }


            TopicTable = TopicTable + "</tr></table>";

            return TopicTable;

        }
    }
}
