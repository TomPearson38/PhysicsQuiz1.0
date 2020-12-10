using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PhysicsQuiz1._0.Classes
{
    public class QuestionClass
    {
        //Contains all SQL for all question related forms 
        public List<StoredQuestions> GetQuestionsForSearch(SearchCriteria sc, bool Type)
        {
            //Retreives the questions from the database that fit the search criteria which is sent to the sub by the search critrtia parameter.
            List<StoredQuestions> questions = new List<StoredQuestions>();
            if (sc.Search == "")
            {
                sc.Search = "%";
            }
            else
            {
                sc.Search = "%" + sc.Search + "%";
            }
            //If the search criteria is empty or incomplete we must add the % sign to either end. This way it searches for a string LIKE what has been specified instead of
            //exactly like it.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                if (Type == false)
                {
                    //The type variable holds wether or not the user has searched for generated difficulty (True) or predefined difficulty (False).
                    var parameters = new { Search = sc.Search, Topic1 = sc.Topic1, Topic2 = sc.Topic2, Topic3 = sc.Topic3, Topic4 = sc.Topic4, Topic5 = sc.Topic5, Difficulty = sc.Difficulty, Difficulty2 = sc.Difficulty1, Difficulty3 = sc.Difficulty2, Area = sc.Area, Area2 = sc.Area1 };
                    questions = connection.Query<StoredQuestions>("exec dbo.spStoredQuestions_SearchQuestionsStoredDiff @Search, @Topic1, @Topic2, @Topic3, @Topic4, @Topic5, @Difficulty, @Difficulty2, @Difficulty3, @Area, @Area2", parameters).ToList();
                    return questions;
                }
                else
                {
                    //If the difficulty is generated then there are different stored procedures for different rankings of difficulty this if statemement picks them
                    var parameters = new { Search = sc.Search, Topic1 = sc.Topic1, Topic2 = sc.Topic2, Topic3 = sc.Topic3, Topic4 = sc.Topic4, Topic5 = sc.Topic5, Area = sc.Area, Area2 = sc.Area1 };
                    if(sc.Difficulty == 1)
                    {
                        var q = connection.Query<StoredQuestions>("exec dbo.spStoredQuestions_SearchQuestionsGenDiff1 @Search, @Topic1, @Topic2, @Topic3, @Topic4, @Topic5, @Area, @Area2", parameters).ToList();
                        questions.AddRange(q);
                    }
                    if (sc.Difficulty1 == 2)
                    {
                        var q = connection.Query<StoredQuestions>("exec dbo.spStoredQuestions_SearchQuestionsGenDiff2 @Search, @Topic1, @Topic2, @Topic3, @Topic4, @Topic5, @Area, @Area2", parameters).ToList();
                        questions.AddRange(q);
                    }
                    if (sc.Difficulty2 == 3)
                    {
                        var q = connection.Query<StoredQuestions>("exec dbo.spStoredQuestions_SearchQuestionsGenDiff3 @Search, @Topic1, @Topic2, @Topic3, @Topic4, @Topic5, @Area, @Area2", parameters).ToList();
                        questions.AddRange(q);
                    }
                    if (sc.Difficulty3 == 4)
                    {
                        var q = connection.Query<StoredQuestions>("exec dbo.spStoredQuestions_SearchQuestionsGenDiff4 @Search, @Topic1, @Topic2, @Topic3, @Topic4, @Topic5, @Area, @Area2", parameters).ToList();
                        questions.AddRange(q);
                    }

                    return questions;
                    //The questions are returned to the user
                }
            }
        }

        public List<StoredQuizQuestions> FindQuestionsId(StoredQuizzes SelectedQuiz)
        {
            //Retrevies the questions for the quiz beased upon the quiz that is sent.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                var questions = connection.Query<StoredQuizQuestions>("exec dbo.StoredQuizQuestions_GetQuestons @QuizId", new { QuizId = SelectedQuiz.QuizId }).ToList();
                return questions;
            }
        }

        public List<StoredQuestions> LoadAllQuestions()
        {
            //loads all the questions in the stored question table
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                var questions = connection.Query<StoredQuestions>("exec dbo.spStoredQuestions_LoadAllQuestions").ToList();
                return questions;
            }
        }

        public void CreateQuiz(int[] pastid, string Name)
        {
            //Transfers the question ID`s from pastid to the array id. If there are no more to transfer, then the remaining spaces are saved to 0`s
            int[] Id = new int[15];

            for (int i = 0; i <= 14; i++)
            {
                try
                {
                    Id[i] = pastid[i];
                }
                catch (Exception)
                {
                    Id[i] = 0;
                };
            }


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                //Parameters are passed to the stored procedure and from there are split into normalized form as they are saved 
                var parameters = new { question1 = Id[0], question2 = Id[1], question3 = Id[2], question4 = Id[3], question5 = Id[4], 
                    question6 = Id[5], question7 = Id[6], question8 = Id[7], question9 = Id[8], question10 = Id[9], question11 = Id[10], 
                    question12 = Id[11], question13 = Id[12], question14 = Id[13], question15 = Id[14], name = Name, length = pastid.Length };

                connection.Execute("dbo.spStoredQuizzes_CreateQuiz @question1, @question2, @question3, @question4, @question5, @question6, " +
                    "@question7, @question8, @question9, @question10, @question11, @question12, @question13, @question14, @question15, @name, @length", parameters);
            }
        }

        public List<StoredQuizzes> LoadQuizzes(string Search)
        {
            //Loads the stored quizzes based upon their name from the search criteria
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                var questions = connection.Query<StoredQuizzes>("exec dbo.StoredQuizzes_FindQuiz @search", new { search = Search}).ToList();
                return questions;
            }
        } 

        public List<StoredQuestions> GetStoredQuizQuestions(List<StoredQuizQuestions> SelectedQuiz)
        {
            //When viewing a stored quiz the QuizID is grabbed from get stored quiz questions and each individual question ID is also grabbed. This sub then selects the stored questions
            //From stored questions and then returns them for display
            List<StoredQuestions> sq = new List<StoredQuestions>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                foreach (StoredQuizQuestions a in SelectedQuiz)
                {
                    var questions = connection.QuerySingle<StoredQuestions>("exec dbo.StoredQuestions_FindQuestions @question", new { question = a.QuestionId });
                    sq.Add(questions);
                }
                return sq;
            }
        } 

        public CompletedQuiz CreateCompletedQuiz(CompletedQuiz quiz)
        {
            //If a student has never ran a quiz before the program must create the records in the table of CompletedQuiz in order to store their progress.
            //It does this by creating a composite key consisting of StudentID and the quiz ID
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                var Quiz = connection.QuerySingle<CompletedQuiz>("exec dbo.CompletedQuiz_CreateQuiz @quizId, @studentId, @length", new { quizId = quiz.Id, studentId = quiz.StudentId, length = quiz.Length });
                return Quiz;
            }
        }


        public List<CompletedQuestion> GetCompletedQuestion(CompletedQuiz cq, List<StoredQuizQuestions> SQS)
        {
            //Gets the individual scores for each person and their questions answered
            List<CompletedQuestion> CQ = new List<CompletedQuestion>();
            CompletedQuestion question = new CompletedQuestion();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                foreach(StoredQuizQuestions QuizQuestion in SQS)
                {
                    try
                    {
                        //The program will try to retervie the completed question that contains their studentID and QuestionsID 
                        question = connection.QuerySingle<CompletedQuestion>("exec dbo.CompletedQuestion_GetQuestion @questionId, @studentId", new { questionId = QuizQuestion.QuestionId, studentId = cq.StudentId });
                    }
                    catch(Exception)
                    {
                        //If the program cannot reterive the completed question it will create a new one
                        question = connection.QuerySingle<CompletedQuestion>(" dbo.CompletedQuestion_Create @questionId, @studentId", new { questionId = QuizQuestion.QuestionId, studentId = cq.StudentId });
                    }
                    CQ.Add(question);
                }
            }
            return CQ;
        }
        

        public void UpdateScores(List<StoredQuestions> sq, List<CompletedQuestion> cq)
        {
            //After a question has been answered the student`s completed question needs to be updated so that the scores answered refelct the score that has been given.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                foreach (StoredQuestions storedQuestions in sq)
                {
                    //Storedquestions are also updated for the global difficulty rating that has been awarded after a question has been answered
                    connection.Execute("dbo.StoredQuestions_UpdateQuestion @questionid, @xanswered, @xcorrect, @difficulty ", new { questionid = storedQuestions.QuestionId, xanswered = storedQuestions.XAnswered, xcorrect = storedQuestions.XAnsweredCorrectly, difficulty = storedQuestions.CalculatedDifficulty});
                }
                foreach (CompletedQuestion compquestion in cq)
                {
                    connection.Execute("dbo.CompletedQuestions_UpdateQuestion @questionid, @xanswered, @xcorrect, @studentid, @difficulty ", new { questionid = compquestion.QuestionId, xanswered = compquestion.XCompleted, xcorrect = compquestion.XCorrect, studentid = compquestion.StudentId, difficulty = compquestion.CalculatedDifficulty });
                }

            }
        }

        public void ResetScores(List<CompletedQuestion> cq)
        {
            //A user may wish to reset their progress for a question. If they do this, the database is queried and every CompletedQuestion that contains their 
            //StudentID and the StoredQuestionID is reset back to 0
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                foreach(CompletedQuestion compquestion in cq)
                {
                    connection.Execute("dbo.CompltedQuestion_ResetQuestion @studentid, @questionid", new { studentid = compquestion.StudentId, questionid = compquestion.QuestionId });
                }
            }
        }
    }
}
