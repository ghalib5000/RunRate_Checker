using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunRate_Checker
{
    class RunAdder
    {
       public  RunAdder(int inirun)
        {
            InitialRuns = inirun;
        }
        
        int InitialRuns = 0, CurrentRuns = 0;
        public void Add_Runs(int r)
        {
            CurrentRuns += r;
            InitialRuns -= r;
          
        }

        public string updateCurrentRuns()
        {
            string cr = Convert.ToString(CurrentRuns);
            return cr;
        }
        public string updateTotalRuns()
        {
           string tr = Convert.ToString(InitialRuns);
            return tr;
        }

    }
}
