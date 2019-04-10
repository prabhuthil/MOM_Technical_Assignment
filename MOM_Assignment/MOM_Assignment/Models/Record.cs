using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM_Assignment.Models
{
    public class Record
    {
        [DisplayName("Month")]
        public string end_of_month { get; set; }
        // public string prime_lending_rate { get; set; }
        
            [DisplayName("Bank_Fd3m")]
        public double banks_fixed_deposits_3m { get; set; }
        [DisplayName("Bank_Fd6m")]
        public double banks_fixed_deposits_6m { get; set; }
        [DisplayName("Bank_Fd12m")]
        public double banks_fixed_deposits_12m { get; set; }
        [DisplayName("Bank_SD")]
        public double banks_savings_deposits { get; set; }

        //   public string fc_hire_purchase_motor_3y { get; set; }
        //  public string fc_housing_loans_15y { get; set; }
        [DisplayName("Fc_Fd3m")]
        public double fc_fixed_deposits_3m { get; set; }
        [DisplayName("Fc_Fd6m")]
        public double fc_fixed_deposits_6m { get; set; }
        [DisplayName("Fc_Fd12m")]
        public double fc_fixed_deposits_12m { get; set; }
        [DisplayName("Fc_SD")]
        public double fc_savings_deposits { get; set; }
        public string timestamp { get; set; }
        
            [DisplayName("HigerRate3m")]
        public string higher_fd_3m
        {
            get { return   fc_fixed_deposits_3m> banks_fixed_deposits_3m ? "FC" : "Bank"; }
        }
        [DisplayName("HigerRate6m")]
        public string higher_fd_6m
        {
            get { return fc_fixed_deposits_6m > banks_fixed_deposits_6m ? "FC" : "Bank"; }
        }
        [DisplayName("HigerRate12m")]
        public string higher_fd_12m
        {
            get { return fc_fixed_deposits_12m > banks_fixed_deposits_12m ? "FC" : "Bank"; }
        }
        [DisplayName("HigerRateSD")]
        public string higher_sd 
        {
            get { return fc_savings_deposits > banks_savings_deposits ? "FC" : "Bank"; }
        }
    }
   
}
