using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsQuiz1._0.Classes
{
    public class CalculateDifficulty
    {
        public int CalcDifficulty(int XCompleted, int XCorrect)
        {
            double percent = ((double)XCorrect / XCompleted);
            int cqpercentage = (int)(Math.Round(percent, 2) * 100);
            return cqpercentage;
        }
    }
}
