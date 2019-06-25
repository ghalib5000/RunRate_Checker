using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RunRate_Checker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int wckt = 0;
        double  totalOvers=0;
        int inRuns = 0;
        BallAdder badder;
        RunAdder radder;
        RunRateChecker.RateChecker rchecker;
        //this method willbe used whenever we want to increase the balls
        public void ballMethod()
        {
            badder.Add_Ball( );
            curOvers.Text= badder.updateCurrentBalls();
            oversInput.Text = badder.updateTotalBalls();
            if(Convert.ToDouble(oversInput.Text)<=-0)
            {
                oversInput.Text = "Out of Overs";
                Enabler(false);
                entovr.Text = "Enter Overs";
                entrun.Text = "Enter Runs";
            }
        }
        public void runMethod (int i)
        {
            radder.Add_Runs(i);
            runsInput.Text = radder.updateTotalRuns();
            curRuns.Text = radder.updateCurrentRuns();
            if (Convert.ToInt32(runsInput.Text) <= 0)
            {
                runsInput.Text = "Out of Runs";
                Enabler(false);
                entovr.Text = "Enter Overs";
                entrun.Text = "Enter Runs";
            }
        }
        public void checkRate()
        {
            rchecker.CurrentOver = badder.CurrentOver;
            rchecker.CurrentRuns = radder.CurrentRuns;
            rchecker.InitialRuns = radder.InitialRuns;
            rchecker.totalOvers = badder.totalOvers;
            curRate.Text = rchecker.Check_Current_Rate();
            reqRate.Text = rchecker.Check_Required_Rate();
        }
        public void singularity(int i)
        {
            ballMethod();
            runMethod(i);
            checkRate();
        }
        private void A2r_Click(object sender, RoutedEventArgs e)
        {
            singularity(2);
        }

        private void A1r_Click(object sender, RoutedEventArgs e)
        {
            singularity(1);
        }
        private void adtb_Click(object sender, RoutedEventArgs e)
        {
            singularity(0);
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void OkInput_Click(object sender, RoutedEventArgs e)
        {
            if (oversInput.Text != "" && runsInput.Text != "")
            {
                try
                {
                    totalOvers = Convert.ToInt32(oversInput.Text);
                    inRuns = Convert.ToInt32(runsInput.Text);
                    radder = new RunAdder(inRuns);
                    badder = new BallAdder(totalOvers);
                    rchecker = new RunRateChecker.RateChecker();
                    checkRate();

                    entovr.Text = "remaining overs";
                    entrun.Text = "remaining runs";
                    Enabler(true);
                }

                catch (FormatException ex)
                {
                    reqRate.Text = ex.Message;
                }
                catch (Exception ex)
                {
                    reqRate.Text = ex.Message;
                }
            }
            else
            {
                reqRate.Text = "please enter runs and overs";
            }
        }
        private void Enabler(bool ip)
        {
            runsInput.IsEnabled = !ip;
            oversInput.IsEnabled = !ip;
            okInput.IsEnabled = !ip;
            a1r.IsEnabled = ip;
            a2r.IsEnabled = ip;
            a3r.IsEnabled = ip;
            a4r.IsEnabled = ip;
            a4Wd.IsEnabled = ip;
            a5r.IsEnabled = ip;
            a6r.IsEnabled = ip;
            aW.IsEnabled = ip;
            aWd.IsEnabled = ip;
            anb.IsEnabled = ip;
            alb.IsEnabled = ip;
            adtb.IsEnabled = ip;
            cstmballs.IsEnabled = ip;
            cstmruns.IsEnabled = ip;
            customwckt.IsEnabled = ip;
            cstballok.IsEnabled = ip;
            cstrunok.IsEnabled = ip;
            cstwcktok.IsEnabled = ip;
        }

        private void A3r_Click(object sender, RoutedEventArgs e)
        {
            singularity(3);
        }

        private void A4r_Click(object sender, RoutedEventArgs e)
        {
            singularity(4);
        }

        private void A5r_Click(object sender, RoutedEventArgs e)
        {
            singularity(5);
        }

        private void A6r_Click(object sender, RoutedEventArgs e)
        {
            singularity(6);
        }

        private void AW_Click(object sender, RoutedEventArgs e)
        {
            singularity(0);
            wickter();
        }

        private void AWd_Click(object sender, RoutedEventArgs e)
        {
            runMethod(1);
            checkRate();
        }
        public void wickter()
        {
            wckt++;
            wckts.Text = Convert.ToString(wckt);
            if (wckt == 10)
            {
                wckts.Text = "Out of Wickets";
                Enabler(false);
                entovr.Text = "Enter Overs";
                entrun.Text = "Enter Runs";
            }
        }

        private void A4Wd_Click(object sender, RoutedEventArgs e)
        {
            runMethod(5);
            checkRate();
        }

        private void Anb_Click(object sender, RoutedEventArgs e)
        {
            runMethod(1);
            checkRate();
        }

        private void Cstballok_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0;i< Convert.ToInt32(cstmballs.Text);i++)
            {
                ballMethod();
                checkRate();
            }
        }

        private void Cstrunok_Click(object sender, RoutedEventArgs e)
        {
            runMethod(Convert.ToInt32(cstmruns.Text));
            checkRate();
        }

        private void Cstwcktok_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < Convert.ToInt32(customwckt.Text); i++)
            {
                wickter();
                checkRate();
            }
        }

        private void Alb_Click(object sender, RoutedEventArgs e)
        {
            singularity(1);
        }
    }
}
