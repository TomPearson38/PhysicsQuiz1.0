using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public abstract class Login
    {
        public string SecondName { get; set; }
        public int ClassId { get; set; } //ClassID is an int containing the ID of their class. This makes it so that they are easily identifiable by their teacher and therefore can send emails to their teacher`s email with their progress.
        public string Salt { get; set; } //. The salt string contains a randomly generated string which is added on the end of the password before it is encrypted using hash set encryption (Objective 13). This makes the password even more secure. 
                                         // As the password is also encrypted, it means that even if an unauthorised user gains access to the database they won`t be able to decipher what the password is. 
        public string Username { get; set; } //Username is this table`s primary key and is mainly used when the user logins in as that way they don`t have to remember a login number, but instead a personalised string.
        public string Password { get; set; }
        public string Email { get; set; } //Their  email is taken so that the teacher can be emailed the student`s progress.
    }


}
