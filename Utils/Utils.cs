using System;

namespace snake_cs.Utils
{
    public class Utils
    {
        public static (int, int) randomBoardPosition(int nRows, int nCollumns){
            Random random = new Random();
            var iPos = random.Next(0, nRows);
            var jPos = random.Next(0, nCollumns);
            return (iPos, jPos);
        }
    }
}