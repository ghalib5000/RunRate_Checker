using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunRate_Checker
{
    class BallAdder
    {
        double  ReqRate = 0, CurrentRate = 0, CurrentOver = 0;
        int Runs = 0, CurrentRuns = 0, Balls = 0, Balls2 =0;
        
        private void Add_Ball()
        {
            Balls++;
            if (Balls == 6)
            {
                Balls2++;
                Balls = 0;
            }
            curOvers.Text = Convert.ToString(Balls2 + "." + Balls);
            CurrentOver = Convert.ToDouble(curOvers.Text);
        }

    }
}
