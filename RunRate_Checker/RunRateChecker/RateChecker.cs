using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunRate_Checker.RunRateChecker
{
    class RateChecker
    {
        double  CurrentRate = 0, ReqRate = 0;

        public int InitialRuns { get; set; }
        public int CurrentRuns { get; set; }
        public double totalOvers { get; set; }
        public double CurrentOver { get; set; }
        public string Check_Current_Rate()
        {

            CurrentRate = Math.Round(CurrentRuns / CurrentOver, 2);
         string t= Convert.ToString(CurrentRate);
            return t;
        }
        public string Check_Required_Rate()
        {

            ReqRate = Math.Round(InitialRuns / totalOvers, 2);
            string t = Convert.ToString(ReqRate);
            return t;
        }
    }
}
