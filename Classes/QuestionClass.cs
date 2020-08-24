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
        //Test
        public List<StoredQuestions> GetQuestionsExistingDifficulty(string search, int topic1, int topic2, int topic3, int topic4, int topic5, int difficulty, int difficulty2, int difficulty3, int area, int area2)
        {
            if (search == "")
            {
                search = "%";
            }
            else
            {
                search = "%" + search + "%";
            }
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                var parameters = new { Search = search, Topic1 = topic1, Topic2 = topic2, Topic3 = topic3, Topic4 = topic4, Topic5 = topic5, Difficulty = difficulty, Difficulty2 = difficulty2, Difficulty3 = difficulty3, Area = area, Area2 = area2};
                var questions = connection.Query<StoredQuestions>("exec dbo.spStoredQuestions_SearchQuestionsStoredDiff @Search, @Topic1, @Topic2, @Topic3, @Topic4, @Topic5, @Difficulty, @Difficulty2, @Difficulty3, @Area, @Area2", parameters).ToList();
                return questions;
            }
        }

        public List<StoredQuestions> FindQuestions(StoredQuizzes SelectedQuiz)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                var parameters = new
                {
                    question1 = SelectedQuiz.Question1,
                    question2 = SelectedQuiz.Question2,
                    question3 = SelectedQuiz.Question3,
                    question4 = SelectedQuiz.Question4,
                    question5 = SelectedQuiz.Question5,
                    question6 = SelectedQuiz.Question6,
                    question7 = SelectedQuiz.Question7,
                    question8 = SelectedQuiz.Question8,
                    question9 = SelectedQuiz.Question9,
                    question10 = SelectedQuiz.Question10,
                    question11 = SelectedQuiz.Question11,
                    question12 = SelectedQuiz.Question12,
                    question13 = SelectedQuiz.Question13,
                    question14 = SelectedQuiz.Question14,
                    question15 = SelectedQuiz.Question15,
                };

                var questions = connection.Query<StoredQuestions>("dbo.StoredQuestions_FindQuestions @question1, @question2, @question3, @question4, @question5, @question6, " +
                    "@question7, @question8, @question9, @question10, @question11, @question12, @question13, @question14, @question15", parameters).ToList();

                return questions;
            }
        }

        public List<StoredQuestions> LoadAllQuestions()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                var questions = connection.Query<StoredQuestions>("exec dbo.spStoredQuestions_LoadAllQuestions").ToList();
                return questions;
            }
        }

        public void CreateQuiz(int[] pastid, string Name)
        {
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
                var parameters = new { question1 = Id[0], question2 = Id[1], question3 = Id[2], question4 = Id[3], question5 = Id[4], 
                    question6 = Id[5], question7 = Id[6], question8 = Id[7], question9 = Id[8], question10 = Id[9], question11 = Id[10], 
                    question12 = Id[11], question13 = Id[12], question14 = Id[13], question15 = Id[14], name = Name, length = pastid.Length };

                connection.Execute("dbo.spStoredQuizzes_CreateQuiz @question1, @question2, @question3, @question4, @question5, @question6, " +
                    "@question7, @question8, @question9, @question10, @question11, @question12, @question13, @question14, @question15, @name, @length", parameters);
            }
        }

        public List<StoredQuizzes> LoadQuizzes(string Search)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                var questions = connection.Query<StoredQuizzes>("exec dbo.StoredQuizzes_FindQuiz @search", new { search = Search}).ToList();
                return questions;
            }
        }

        public CompletedQuiz GetCompletedQuiz(int QuizId, int StudentId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                try
                {
                    var Quiz = connection.QuerySingle<CompletedQuiz>("exec dbo.spCompletedQuiz_GetQuiz @quizId, @studentId", new { quizId = QuizId, studentId = StudentId });
                    return Quiz;
                }
                catch(Exception)
                {
                    return new CompletedQuiz();
                };
            }
        }
    }
}
