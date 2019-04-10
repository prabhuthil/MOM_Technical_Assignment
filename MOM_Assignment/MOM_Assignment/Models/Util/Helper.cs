using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM_Assignment.Models.Util
{
  public static  class Helper
    {

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
     public   static bool ValidateInputDates(string input, out string from, out string to)
        {
            from = "";
            to = "";

            if (input.Length != 17)
                return false;

            var arrInputs = input.Split(' ');
            if (arrInputs.Length != 2)
                return false;

            var input1 = "01-" + arrInputs[0];
            var input2 = "01-" + arrInputs[1];

            DateTime dt1;

            bool isValid = DateTime.TryParseExact(
                input1,
                "dd-MMM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt1);

            if (!isValid)
                return false;

           
            DateTime dt2;
            isValid = DateTime.TryParseExact(
                input2,
                "dd-MMM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt2);

            if (!isValid)
                return false;

            if(dt1 > dt2)
                return false;

            from = dt1.ToString("yyyy-MM");
            to = dt2.ToString("yyyy-MM");

            return true;
        }
    }
}
