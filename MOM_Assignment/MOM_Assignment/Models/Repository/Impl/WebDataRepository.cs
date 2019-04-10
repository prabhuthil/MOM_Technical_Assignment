using MOM_Assignment.Models;
using MOM_Assignment.Models.Util;
using MOM_Assignment.Repository.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MOM_Assignment.Repository.Impl
{
    public class WebDataRepository : IWebDataRepository
    {
        private static readonly string address = @"https://eservices.mas.gov.sg/api/action/datastore/search.json?resource_id=5f2b18a8-0883-4769-a635-879c63d3caac&limit={0}&between[end_of_month]={1},{2}";


        public async Task<List<Record>> GetWebDataAsync(string startDate, string endDate)
        {
            try
            {
                DateTime stDate = DateTime.Parse(startDate + "-01");
                DateTime enDate = DateTime.Parse(endDate + "-28");
                int mns = Helper.GetMonthDifference(stDate, enDate);


                var result = await GetStringAsync(string.Format(address, mns + 1, startDate, endDate));

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var webResponse = JsonConvert.DeserializeObject<RootObject>(result, settings);
                return webResponse.result.records;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ...");
                throw new WebAPIConnectionCustomException();
            }
        }

        private static async Task<string> GetStringAsync(string url)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    return await httpClient.GetStringAsync(url);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ...");
                throw new WebAPIConnectionCustomException();
            }
        }

    }
}
