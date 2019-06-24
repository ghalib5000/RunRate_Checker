using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunRate_Checker.RunRateChecker
{
    class RateChecker
    {
        double ReqRate = 0, CurrentRate = 0, CurrentOver = 0;
        int Runs = 0, CurrentRuns = 0, Balls = 0, Balls2 = 0;


        public void Check_Current_Rate()
        {
            CurrentRate = Math.Round(CurrentRuns / CurrentOver, 2);
         //   curRate.Text = Convert.ToString(CurrentRate);

        }

    }
}
