using PhysicsQuiz1._0.GeneralForms;
using PhysicsQuiz1._0.LoginScreen;
using PhysicsQuiz1._0.StudentForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsQuiz1._0
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartLogin());
        }
    }
}
