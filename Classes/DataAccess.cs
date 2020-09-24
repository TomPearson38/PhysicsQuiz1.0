using Dapper;
using System;
using System.Data;
using System.Text;

namespace PhysicsQuiz1._0.Classes
{
    public class DataAccess
    {
        public void CreateStudent(string firstname, string surname, string username, string password, int classcode)
        {
            //Creates a student account on the database based on the input data
            //The salt is added to the password to make it more secure when encrypting and is also stored in the database.
            string salt = GenerateSalt();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                var parameters = new { Firstname = firstname, SecondName = surname, Username = username, Password = EncryptPassword(Salted(password, salt)), ClassId = classcode, Salt = salt };

                //Calls the stored procedure create new student and inputs the values created in parameters above
                connection.Execute("dbo.spStudentLogin_CreateNewStudent @Firstname, @SecondName, @Username, @Password, @ClassId, @Salt", parameters);
            }
        }


        public StudentLogin AttemptStudentLogin(string Username, string password)
        {
            //Attempts to login a student based upon the username and password that they have given.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                try 
                {
                    //Attempts to retrive the salt from the database based upon their username. If it cannot find it, it will retun an ystem.Data.SqlClient.SqlException which will be caught 
                    //and then a null value will be returned instead. Showing that it couldn`t be found.
                    string salt = GetSalt(Username, "dbo.spStudentLogin_GetSalt");
                        
                    //connection.QuerySingle<string>("dbo.spStudentLogin_GetSalt @username", new { username = Username });
                   
                    if (salt == null)
                    {
                        return null;
                    }
                    else
                    {
                        //Encrypt password sub encrypts the password and salt input and returns the encryped value
                        var parameters = new { username = Username, password = EncryptPassword(Salted(password, salt)) };


                        //Calls the stored procedure AttemptLogin and inputs the values created in parameters above
                        var user = connection.QuerySingle<StudentLogin>("exec dbo.spStudentLogin_AttemptLogin @username, @password", parameters);
                        if (user == null)
                        {
                            return null;
                        }
                        else
                        {
                            return user;
                        }
                    }
                }
                    catch (System.Data.SqlClient.SqlException)
                {
                    return null;
                }
                catch (System.InvalidOperationException)
                {
                    return null;
                }
        }
        }

        public bool CheckStudentUsername(string username)
        {
            //Used when creating a new student, it checks to see if the username is already taken.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                try
                {
                    string u = connection.QuerySingle<string>($"exec dbo.spStudentLogin_IsUsernameTaken '{username}'");
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool CheckTeacherUsername(string username)
        {
            //Used when creating a new teacher, it checks to see if the username is already taken.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                try
                {
                    int u = connection.QuerySingle<int>($"exec dbo.spTeacherLogin_CheckUsername '{username}'");
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool CheckClassCode(int classcode)
        {
            //Used when creating a new student, it checks to see if the class code input exists.
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                try
                {
                    int u = connection.QuerySingle<int>($"exec dbo.spTClass_CheckValidClassCode '{classcode}'");
                    return true;
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return false;
                }
                catch (System.InvalidOperationException)
                {
                    return false;
                }
            }
        }

        public string Salted(string password, string salt)
        {
            //Combines the passord and salt of the input parameters
            return (password + salt);
        }

        public string GetSalt(string Username, string SaltType)
        {
            //Retrives the salt 
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                try 
                { 
                    var output = connection.QuerySingle<string>($"{SaltType} @username", new { username = Username });
                    return output;
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return null;
                }
                catch (System.InvalidOperationException)
                {
                    return null;
                }
            }
        }

        public string GenerateSalt()
        {
            //Generated a new salt to be added to the end of the password
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[15];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public string EncryptPassword(string saltedpassword)
        {
            //Encrypts the password based upon hashing encryption
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(saltedpassword);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);

            StringBuilder hex = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        public void CreateNewTeacher(string title, string surname, string username, string password, string email)
        {
            //Creates a new teacher based upon the input parameters
            string salt = GenerateSalt();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
            {
                var parameters = new { Title = title, SecondName = surname, Username = username, Password = EncryptPassword(password + salt), Email = email, Salt = salt };

                connection.Execute("dbo.TeacherLogin_CreateNewTeacher @Title, @SecondName, @Username, @Password, @Email, @Salt", parameters);
            }
        }

        public TeacherLogin AttemptTeacherLogin(string Username, string pword)
        {
            //Attempts to login a teacher based upon the username and password that they have given.

            //Attempts to retrive the salt from the database based upon their username. If it cannot find it, it will retun an system.Data.SqlClient.SqlException which will be caught 
            //and then a null value will be returned instead. Showing that it couldn`t be found.
            string salt = GetSalt(Username, "dbo.spTeacherLogin_GetSalt");
            if (salt == null)
            {
                return null;
            }
            else
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Physicsdb")))
                {
                    string encryptedPassword = EncryptPassword(pword + salt);
                    var parameters = new { Username, Password = encryptedPassword };
                    try 
                    {
                        //Attempts to retrive the teachers information from the database based upon their username and encrypted password. If it cannot find it, it will retun an system.Data.SqlClient.SqlException which will be caught 
                        //and then a null value will be returned instead. Showing that it couldn`t be found.
                        var user = connection.QuerySingle<TeacherLogin>("exec dbo.slTeacherLogin_AttemptLogin @Username, @Password", parameters);
                        return user;
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        return null;
                    }
                    catch (System.InvalidOperationException)
                    {
                        return null;
                    }
            }
            }
        }
    }
}
