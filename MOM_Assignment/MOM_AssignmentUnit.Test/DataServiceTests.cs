using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOM_Assignment.Models.Util;
using MOM_Assignment.Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOM_Assignment.Models.Util;
namespace MOM_AssignmentUnit.Test
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void GetWebDataAsyncValidReternsCount5()
        {
            
            WebDataService webDataService = new WebDataService(new MOM_Assignment.Repository.Impl.WebDataRepository());
            string fromDate = "2013-01";
            string toDate = "2013-05";
            var result = webDataService.GetWebDataAsync(fromDate, toDate).Result;

            Assert.IsTrue(5 == result.Count);
        }
        //[TestMethod]
        //[ExpectedException(typeof(WebAPIConnectionCustomException))]
        //public void GetWebDataAsyncInValidDateReternsException()
        //{
        //    try
        //    {
        //        WebDataService webDataService = new WebDataService(new MOM_Assignment.Repository.Impl.WebDataRepository());
        //        string fromDate = "2013-0144";
        //        string toDate = "2013-05";
        //        var result = webDataService.GetWebDataAsync(fromDate, toDate);
        //        Assert.IsTrue(result.Exception.InnerException is WebAPIConnectionCustomException);

        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.IsTrue(ex is  WebAPIConnectionCustomException );
        //    }
        //}
    }
}
