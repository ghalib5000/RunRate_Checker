﻿using System;
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
        double  ReqRate = 0, CurrentRate = 0, CurrentOver = 0,totalOvers=0;
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
        }
        public void runMethod (int i)
        {
            radder.Add_Runs(i);
            runsInput.Text = radder.updateTotalRuns();
            curRuns.Text = radder.updateCurrentRuns();
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
        private void A2r_Click(object sender, RoutedEventArgs e)
        {
            ballMethod();
            runMethod(2);
            checkRate();
        }

        private void A1r_Click(object sender, RoutedEventArgs e)
        {

            ballMethod();
            runMethod(1);
            checkRate();
        }
        private void adtb_Click(object sender, RoutedEventArgs e)
        {


            ballMethod();
            runMethod(0);
            checkRate();
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
                    reqRate.Text = rchecker.Check_Required_Rate();
                    curRate.Text = rchecker.Check_Current_Rate();

                    //ReqRate = inRuns/ totalOvers;
                    //    reqRate.Text = Convert.ToString(ReqRate);
                    //Check_Current_Rate();
                    //  curRate.Text = Convert.ToString(CurrentRate);
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