using MarkdownLog;
using MOM_Assignment.Models.Service.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM_Assignment.Models.Service.Impl
{
    public class BusinessService : IBusinessService
    {
        private List<Record> records;
        public BusinessService(List<Record> _records)
        {
            records = _records;
        }

        public void CompareAvgFCvsBank()
        {
            if (records != null && records.Count > 0)
            {
                var avgFc_fd_3m = records.Average(a => a.fc_fixed_deposits_3m);
                var avgFc_fd_6m = records.Average(a => a.fc_fixed_deposits_6m);
                var avgFc_fd_12m = records.Average(a => a.fc_fixed_deposits_12m);
                var avgFc_Sd = records.Average(a => a.fc_savings_deposits);
                var avgBank_fd_3m = records.Average(a => a.banks_fixed_deposits_3m);
                var avgBank_fd_6m = records.Average(a => a.banks_fixed_deposits_6m);
                var avgBank_fd_12m = records.Average(a => a.banks_fixed_deposits_12m);
                var avgBank_sd = records.Average(a => a.banks_savings_deposits);


                List<string> lstStrSingle = new List<string>() { "output" };
                Console.WriteLine("");
                Console.WriteLine("Compare the overall average of financial companies rates against bank rates");
                Console.WriteLine("");
                Console.WriteLine(
                    lstStrSingle.Select(a => new
                    {
                        Avg_Fc_fd_3m = avgFc_fd_3m,
                        Avg_Bank_fd_3m = avgBank_fd_3m,
                        Avg_Fc_fd_6m = avgFc_fd_6m,
                        Avg_Bank_fd_6m = avgBank_fd_6m,
                        Avg_Fc_fd_12m = avgFc_fd_12m,
                        Avg_Bank_fd_12m = avgBank_fd_12m,
                        Avg_Fc_Sd = avgFc_Sd,
                        Avg_Bank_sd = avgBank_sd
                    }).ToMarkdownTable()
                    );
            }
            else
            {
                Console.WriteLine("No records Available during this period");
            }
        }

        public void CompareFCvsBankAndHighLight()
        {
            if (records != null && records.Count > 0)
            {
                Console.WriteLine("Compare the financial companies rates against bank and see on which months financial companies have a higher rate");
                Console.WriteLine("");
                Console.WriteLine(
    records.Select(s => new
    {
        Month = s.end_of_month,
        Fc_Fd3m = s.fc_fixed_deposits_3m,
        Bank_Fd3m = s.banks_fixed_deposits_3m,
        HigerRate3m = s.higher_fd_3m,
        Fc_Fd6m = s.fc_fixed_deposits_6m,
        Bank_Fd6m = s.banks_fixed_deposits_6m,
        HigerRate6m = s.higher_fd_6m,
        Fc_Fd12m = s.fc_fixed_deposits_12m,
        Bank_Fd12m = s.banks_fixed_deposits_12m,
        HigerRate12m = s.higher_fd_12m,
        Fc_SD = s.fc_savings_deposits,
        Bank_SD = s.banks_savings_deposits,
        HigerRate_SD = s.higher_sd,

    }).ToMarkdownTable());
            }
            else
            {

                Console.WriteLine("No records Available during this period");
            }
        }

        public void SlopeTredLine()
        {
            if (records != null && records.Count > 0)
            {
                double intercept, slope;
                string FC_fd_3m_slop, FC_fd_6m_slop, FC_fd_12m_slop, FC_SD_slop;
                string Bank_fd_3m_slop, Bank_fd_6m_slop, Bank_fd_12m_slop, Bank_SD_slop;

                var date_x = records.Select(a => double.Parse(a.end_of_month.Replace("-", ""))).ToArray();

                //Get the input of toDate and fromDate result of Financial Companies to compare and obtain the trend of the rates slope
                var fc_fd_3m_y = records.Select(a => a.fc_fixed_deposits_3m).ToArray();
                CalulateSlopTrend(date_x, fc_fd_3m_y, out intercept, out slope, out FC_fd_3m_slop);

                var fc_fd_6m_y = records.Select(a => a.fc_fixed_deposits_6m).ToArray();
                CalulateSlopTrend(date_x, fc_fd_6m_y, out intercept, out slope, out FC_fd_6m_slop);

                var fc_fd_12m_y = records.Select(a => a.fc_fixed_deposits_12m).ToArray();
                CalulateSlopTrend(date_x, fc_fd_12m_y, out intercept, out slope, out FC_fd_12m_slop);

                var fc_sd_y = records.Select(a => a.fc_savings_deposits).ToArray();
                CalulateSlopTrend(date_x, fc_sd_y, out intercept, out slope, out FC_SD_slop);

                var Bank_fd_3m_y = records.Select(a => a.banks_fixed_deposits_3m).ToArray();
                CalulateSlopTrend(date_x, Bank_fd_3m_y, out intercept, out slope, out Bank_fd_3m_slop);

                var Bank_fd_6m_y = records.Select(a => a.banks_fixed_deposits_6m).ToArray();
                CalulateSlopTrend(date_x, Bank_fd_6m_y, out intercept, out slope, out Bank_fd_6m_slop);

                var Bank_fd_12m_y = records.Select(a => a.banks_fixed_deposits_12m).ToArray();
                CalulateSlopTrend(date_x, Bank_fd_12m_y, out intercept, out slope, out Bank_fd_12m_slop);

                var Bank_sd_y = records.Select(a => a.banks_savings_deposits).ToArray();
                CalulateSlopTrend(date_x, Bank_sd_y, out intercept, out slope, out Bank_SD_slop);

                List<string> lstStrSingle = new List<string>() { "output" };
                Console.WriteLine("");
                Console.WriteLine(" interest rates slope are on an upward or downward trend during this period");
                Console.WriteLine("");
                Console.WriteLine(
                    lstStrSingle.Select(a => new
                    {
                        Fc_fd3m = FC_fd_3m_slop,
                        Bank_fd3m = Bank_fd_3m_slop,
                        Fc_fd6m = FC_fd_6m_slop,
                        Bank_fd6m = Bank_fd_6m_slop,
                        Fc_fd12m = FC_fd_12m_slop,
                        Bank_fd12m = Bank_fd_12m_slop,
                        Fc_Sd = FC_SD_slop,
                        Bank_sd = Bank_SD_slop
                    }).ToMarkdownTable()
                    );
            }
            else
            {

                Console.WriteLine("No records Available during this period");
            }
        }
        /// <summary>
        /// Fits a line to a collection of (x,y) points.
        /// </summary>
        /// <param name="xVals">The x-axis values.</param>
        /// <param name="yVals">The y-axis values.</param>
        /// <param name="rSquared">The r^2 value of the line.</param>
        /// <param name="yIntercept">The y-intercept value of the line (i.e. y = ax + b, yIntercept is b).</param>
        /// <param name="slope">The slop of the line (i.e. y = ax + b, slope is a).</param>
         void CalulateSlopTrend(
            double[] xVals,
            double[] yVals,
            out double yIntercept,
            out double slope,
            out string str_slope)
        {
            if (xVals.Length != yVals.Length)
            {
                throw new Exception("Input values should be with the same length.");
            }

            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double sumCodeviates = 0;

            for (var i = 0; i < xVals.Length; i++)
            {
                var x = xVals[i];
                var y = yVals[i];
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }

            var count = xVals.Length;
            var ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            var ssY = sumOfYSq - ((sumOfY * sumOfY) / count);

            var rNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            var rDenom = (count * sumOfXSq - (sumOfX * sumOfX)) * (count * sumOfYSq - (sumOfY * sumOfY));
            var sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            var meanX = sumOfX / count;
            var meanY = sumOfY / count;
           // var dblR = rNumerator / Math.Sqrt(rDenom);

            //rSquared = dblR * dblR;
            yIntercept = meanY - ((sCo / ssX) * meanX);
            slope = sCo / ssX;

            var first = (slope * xVals.First()) + yIntercept;
            var Last = (slope * xVals.Last()) + yIntercept;

           // string str_slop = "";


            if (first > Last)
                str_slope = "Downward";
            else if (first < Last)
                str_slope = "Upward";
            else
                str_slope = "Flat";
        }
    }
}
    

