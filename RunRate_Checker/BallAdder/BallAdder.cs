using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunRate_Checker
{
    class BallAdder
    {
        public double totalOvers { get; set; }
        public double CurrentOver { get; set; }
        int Balls = 0, Balls2 = 0;
        string temp = "";
        public BallAdder(double totover)
        {
            totalOvers = totover;
        }
        public void Add_Ball()
        {
            Balls++;
            if (Balls == 6)
            {
                Balls2++;
                Balls = 0;
            }
            totalOvers -= 0.1;
            temp = Convert.ToString(totalOvers);
            if (temp.Contains(".9"))
            {
                totalOvers -= 0.4;
            }
        }
        public string updateCurrentBalls()
        {
            string cb = Convert.ToString(Balls2 + "." + Balls);
            CurrentOver = Convert.ToDouble(cb);
            return cb;
        }
        public string updateTotalBalls()
        {
            string tb = Convert.ToString(totalOvers);
            return tb;
        }

    }
}
