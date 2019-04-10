using MOM_Assignment.Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOM_Assignment.Repository.Impl;
using System.Globalization;
using MOM_Assignment.Models.Util;
using MOM_Assignment.Models.Service.Impl;

namespace MOM_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = "Apr-2015 May-2018"; //args[0];
            var input = args[0];
            string fromDate, toDate;

        var validationResult =    Helper.ValidateInputDates(input, out fromDate, out toDate);
            if (validationResult)
            {

                WebDataService webDataService = new WebDataService(new WebDataRepository());

                var result = webDataService.GetWebDataAsync(fromDate, toDate).Result;
                BusinessService businessService = new BusinessService(result);
                businessService.CompareFCvsBankAndHighLight();
                businessService.CompareAvgFCvsBank();
                businessService.SlopeTredLine();
            }
            else
            {
                Console.WriteLine("Input validation failed");
            }

            Console.ReadKey();
        }

        //bool ValidateInputLength(string input)
        //{
        //    //input format  Jan-2017 Jan-2018
        //    return input.Length == 17;
        //}

    
    }
}
