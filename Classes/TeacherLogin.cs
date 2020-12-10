using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class TeacherLogin
    {
        public int TeacherId { get; set; } //The TeacherID is a foreign key for multiple tables such as completed question. It allows us to identify each teacher easily and efficiently 
        public string Title { get; set; } //
        public string SecondName { get; set; }
        public int ClassId { get; set; } //ClassID is an int containing the ID of their class, it is randomly generated when the Teacher`s account is created.
        public string Username { get; set; } //Username is this table`s primary key and is mainly used when the user logins in as that way they don`t have to remember a login number, but instead a personalised string.
        public string Password { get; set; } //Salt and Password both store information about the user`s login information. The salt string contains a randomly generated string which is added on the end of the password before 
                                             //it is encrypted using hash set encryption. This makes the password even more secure. As the password is also encrypted, it means that even if an unauthorised user gains access to
                                             //the database they won`t be able to decipher what the password is. 
        public string Salt { get; set; }
        public string Email { get; set; } //The teacher`s email is taken so that their student`s results can be emailed to them.
    }
}
