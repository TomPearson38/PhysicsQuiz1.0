using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class CreateHTMLTable
    {
        List<StoredQuestions> SQ = new List<StoredQuestions>();
        List<CompletedQuestion> CQ = new List<CompletedQuestion>();

        CalculateDifficulty cq = new CalculateDifficulty();


        int[,] Area = new int[2,2];
        int[,] Topic = new int[5,2];

        public string createtable(List<StoredQuestions> sq, List<CompletedQuestion> cq)
        {
            SQ = sq;
            CQ = cq;

            string finalresult = "";
            finalresult = finalresult + createheader();
            finalresult = finalresult + CreateQuestionTable();
            finalresult = finalresult + "<br><br>";
            finalresult = finalresult + CreateAreaTable();
            finalresult = finalresult + "<br><br>";
            finalresult = finalresult + CreateTopicTable();
            finalresult = finalresult + "</body></ html >";


            return finalresult;
        }

        private string createheader()
        {
            string header = "<html><head><style>table, th, td {  border: 1px solid black;}</style></head><body><h2>Question Breakdown</h2>";
            return header;
        }

        private string CreateQuestionTable()
        {
            string QuestionTable = "<table style=\"width: 100 % \" ><tr><th>Question</th><th>Area</th><th>Topic</th><th>Knowledge</th><th>Times Answered</th><th>Times Correct</th></tr>";
            foreach (StoredQuestions sq in SQ)
            {
                string row = "";
                foreach (CompletedQuestion cq in CQ)
                {
                    if (cq.QuestionId == sq.QuestionId)
                    {
                        row = row + "<td>"+ sq.Question +"</td>";
                        if (sq.Area == 1)
                        {
                            row = row + "<td> Recall </td>";
                            Area[0, 0] = Area[0, 0] + cq.XCorrect;
                            Area[0, 1] = Area[0, 1] + cq.XCompleted;
                        }
                        else
                        {
                            row = row + "<td> Calculation </td>";
                            Area[1, 0] = Area[1, 0] + cq.XCorrect;
                            Area[1, 1] = Area[1, 1] + cq.XCompleted;
                        }

                        if (sq.TopicId == 1)
                        {
                            row = row + "<td> Particles </td>";
                            Topic[0, 0] = Topic[0, 0] + cq.XCorrect;
                            Topic[0, 1] = Topic[0, 1] + cq.XCompleted;
                        }
                        else if (sq.TopicId == 2)
                        {
                            row = row + "<td> Waves </td>";
                            Topic[1, 0] = Topic[1, 0] + cq.XCorrect;
                            Topic[1, 1] = Topic[1, 1] + cq.XCompleted;
                        }
                        else if (sq.TopicId == 3)
                        {
                            row = row + "<td> Mechanics </td>";
                            Topic[2, 0] = Topic[2, 0] + cq.XCorrect;
                            Topic[2, 1] = Topic[2, 1] + cq.XCompleted;
                        }
                        else if (sq.TopicId == 4)
                        {
                            row = row + "<td> Materials </td>";
                            Topic[3, 0] = Topic[3, 0] + cq.XCorrect;
                            Topic[3, 1] = Topic[3, 1] + cq.XCompleted;
                        }
                        else if (sq.TopicId == 5)
                        {
                            row = row + "<td> Electricity </td>";
                            Topic[4, 0] = Topic[4, 0] + cq.XCorrect;
                            Topic[4, 1] = Topic[4, 1] + cq.XCompleted;
                        }

                        string score = DifficultyScore(cq.CalculatedDifficulty);
                        row = row + "<td>"+ score + "</td>";
                        row = row + "<td>" + cq.XCompleted.ToString() + "</td>";
                        row = row + "<td>" + cq.XCorrect.ToString() + "</td>";
                        row = row + "</tr>";
                        break;
                    }
                }
                QuestionTable = QuestionTable + row;
            }
            QuestionTable = QuestionTable + "</table>";
            return QuestionTable;
        }

        private string DifficultyScore(int cq)
        {
            if (cq <= 20)
            {
                return "Poor";
            }
            else if (cq <= 40)
            {
                return "Worse";
            }
            else if (cq <= 60)
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
            string AreaTable;
            AreaTable = "<h2> Area Results </h2><table style=\"width:50 %\"><tr><th>Recall</th><th>Calculations</th></tr>";
            AreaTable = AreaTable + "<tr><td>"+ cq.CalcDifficulty(Area[0,1], Area[0,0]) +"%</td><td>" + cq.CalcDifficulty(Area[1, 1], Area[1, 0]) + "%</td></tr>";
            AreaTable = AreaTable + "</table>";
            return AreaTable;
        }

        private string CreateTopicTable()
        {
            string TopicTable;
            TopicTable = "<h2>Topic Results</h2><table style=\"width: 100 % \"><tr><th>Particles</th><th>Waves</th><th>Mechanics</th><th>Materials</th><th>Electricty</th></tr><tr>";

            if(Topic[0,0] != 0)
            {
                TopicTable = TopicTable + "<td>" + cq.CalcDifficulty(Topic[0, 1], Topic[0, 0]) + "%</td>";
            }
            else
            {
                TopicTable = TopicTable + "<td> </td>";
            }

            if (Topic[1, 0] != 0)
            {
                TopicTable = TopicTable + "<td>" + cq.CalcDifficulty(Topic[1, 1], Topic[1, 0]) + "%</td>";
            }
            else
            {
                TopicTable = TopicTable + "<td> </td>";
            }

            if (Topic[2, 0] != 0)
            {
                TopicTable = TopicTable + "<td>" + cq.CalcDifficulty(Topic[2, 1], Topic[2, 0]) + "%</td>";
            }
            else
            {
                TopicTable = TopicTable + "<td> </td>";
            }

            if (Topic[3, 0] != 0)
            {
                TopicTable = TopicTable + "<td>" + cq.CalcDifficulty(Topic[3, 1], Topic[3, 0]) + "%</td>";
            }
            else
            {
                TopicTable = TopicTable + "<td> </td>";
            }

            if (Topic[4, 0] != 0)
            {
                TopicTable = TopicTable + "<td>" + cq.CalcDifficulty(Topic[4, 1], Topic[4, 0]) + "%</td>";
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
