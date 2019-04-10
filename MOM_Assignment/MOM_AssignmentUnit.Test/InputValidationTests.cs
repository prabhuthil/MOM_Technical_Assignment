using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOM_Assignment.Models.Util;

namespace MOM_AssignmentUnit.Test
{
    [TestClass]
    public class InputValidationTests
    {
        [TestMethod]
        public void ValidateInputDatesValidReturnsTrue()
        {
            string input1, input2;
            string inputDates = "Jan-2012 Dec-2013";
            var result = Helper.ValidateInputDates(inputDates,out input1,out input2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateInputDatesValidSmallLetterMonthReturnsTrue()
        {
            string input1, input2;
            string inputDates = "jan-2012 dec-2013";
            var result = Helper.ValidateInputDates(inputDates, out input1, out input2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateInputDatesInValidReturnsFalse()
        {
            string input1, input2;
            string inputDates = "Jan-2012Dec-2013";
            var result = Helper.ValidateInputDates(inputDates, out input1, out input2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateInputDatesInValidFormatReturnsFalse()
        {
            string input1, input2;
            string inputDates = "01-2012 01-2013";
            var result = Helper.ValidateInputDates(inputDates, out input1, out input2);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateInputDatesInValidFromDateGreaterThenToDateReturnsFalse()
        {
            string input1, input2;
            string inputDates = "Jan-2012 Jan-2011";
            var result = Helper.ValidateInputDates(inputDates, out input1, out input2);

            Assert.IsFalse(result);
        }
    }
}
