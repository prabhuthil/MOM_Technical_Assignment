using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MOM_Assignment.Models.Service.Impl;
using MOM_Assignment.Service.Impl;

namespace MOM_AssignmentUnit.Test
{
    [TestClass]
    public class BusinessServiceitTest
    {
        [TestMethod]
        public void CompareAvgFCvsBankValidWithDataExecutesWithoutError()
        {
            try
            {
                var isExecuted = false;
                WebDataService webDataService = new WebDataService(new MOM_Assignment.Repository.Impl.WebDataRepository());
                string fromDate = "2013-01";
                string toDate = "2013-05";
                var result = webDataService.GetWebDataAsync(fromDate, toDate).Result;
                BusinessService businessService = new BusinessService(result);
                businessService.CompareAvgFCvsBank();
                isExecuted = true;
                Assert.IsTrue(isExecuted);
            }
            catch
            {
                Assert.Fail();

            }
        }
        [TestMethod]
        public void CompareAvgFCvsBankValidWithNULLExecutesWithoutError()
        {
            try
            {
                var isExecuted = false;
                
                BusinessService businessService = new BusinessService(null);
                businessService.CompareAvgFCvsBank();
                isExecuted = true;
                Assert.IsTrue(isExecuted);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CompareAvgFCvsBankValidWithZeroRecordExecutesWithoutError()
        {
            try
            {
                var isExecuted = false;
               
                BusinessService businessService = new BusinessService(new System.Collections.Generic.List<MOM_Assignment.Models.Record>());
                businessService.CompareAvgFCvsBank();
                isExecuted = true;
                Assert.IsTrue(isExecuted);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CCompareFCvsBankAndHighLightValidWithDataExecutesWithoutError()
        {
            try
            {
                var isExecuted = false;
                WebDataService webDataService = new WebDataService(new MOM_Assignment.Repository.Impl.WebDataRepository());
                string fromDate = "2013-01";
                string toDate = "2013-05";
                var result = webDataService.GetWebDataAsync(fromDate, toDate).Result;
                BusinessService businessService = new BusinessService(result);
                businessService.CompareFCvsBankAndHighLight();
                isExecuted = true;
                Assert.IsTrue(isExecuted);
            }
            catch
            {
                Assert.Fail();

            }
        }
        [TestMethod]
        public void CompareFCvsBankAndHighLightValidWithNULLExecutesWithoutError()
        {
            try
            {
                var isExecuted = false;

                BusinessService businessService = new BusinessService(null);
                businessService.CompareFCvsBankAndHighLight();
                isExecuted = true;
                Assert.IsTrue(isExecuted);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CompareFCvsBankAndHighLightValidWithZeroRecordExecutesWithoutError()
        {
            try
            {
                var isExecuted = false;

                BusinessService businessService = new BusinessService(new System.Collections.Generic.List<MOM_Assignment.Models.Record>());
                businessService.CompareFCvsBankAndHighLight();
                isExecuted = true;
                Assert.IsTrue(isExecuted);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CSlopeTredLineValidWithDataExecutesWithoutError()
        {
            try
            {
                var isExecuted = false;
                WebDataService webDataService = new WebDataService(new MOM_Assignment.Repository.Impl.WebDataRepository());
                string fromDate = "2013-01";
                string toDate = "2013-05";
                var result = webDataService.GetWebDataAsync(fromDate, toDate).Result;
                BusinessService businessService = new BusinessService(result);
                businessService.CompareFCvsBankAndHighLight();
                isExecuted = true;
                Assert.IsTrue(isExecuted);
            }
            catch
            {
                Assert.Fail();

            }
        }
        [TestMethod]
        public void SlopeTredLineValidWithNULLExecutesWithoutError()
        {
            try
            {
                var isExecuted = false;

                BusinessService businessService = new BusinessService(null);
                businessService.CompareFCvsBankAndHighLight();
                isExecuted = true;
                Assert.IsTrue(isExecuted);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void SlopeTredLineValidWithZeroRecordExecutesWithoutError()
        {
            try
            {
                var isExecuted = false;

                BusinessService businessService = new BusinessService(new System.Collections.Generic.List<MOM_Assignment.Models.Record>());
                businessService.CompareFCvsBankAndHighLight();
                isExecuted = true;
                Assert.IsTrue(isExecuted);
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
