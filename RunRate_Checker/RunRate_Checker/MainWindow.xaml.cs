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
        double  ReqRate = 0, CurrentRate = 0, CurrentOver = 0;
        int Runs = 0, CurrentRuns = 0, Balls = 0, Balls2 =0;
        
        private void Add_Runs(int r)
        {
            CurrentRuns += r;
            curRuns.Text = Convert.ToString(CurrentRuns);
            Check_Current_Rate();
        }
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

        private void A1r_Click(object sender, RoutedEventArgs e)
        {
            Add_Ball();
            Add_Runs(1);
        }
        private void Check_Current_Rate()
        {
            CurrentRate = Math.Round(CurrentRuns / CurrentOver,2 );
            curRate.Text =  Convert.ToString(CurrentRate);
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
                    Runs = Convert.ToInt32(runsInput.Text);

                    ReqRate = Runs/ Convert.ToInt32(oversInput.Text);
                    reqRate.Text = Convert.ToString(ReqRate);
                    Check_Current_Rate();
                    curRate.Text = Convert.ToString(CurrentRate);
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

    }
}
