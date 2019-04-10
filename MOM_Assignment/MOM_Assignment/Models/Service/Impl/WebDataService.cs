using MOM_Assignment.Models;
using MOM_Assignment.Models.Util;
using MOM_Assignment.Repository.Interface;
using MOM_Assignment.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM_Assignment.Service.Impl
{
   public class WebDataService : IWebDataService
    {
        private readonly IWebDataRepository webDataRepository;

        public WebDataService(IWebDataRepository _webDataRepository)
        {
            webDataRepository = _webDataRepository;
        }

        public async  Task<List<Record>> GetWebDataAsync(string startDate, string endDate)
        {
            try
            {
                return await webDataRepository.GetWebDataAsync(startDate, endDate);
            }
            catch (WebAPIConnectionCustomException ex)
            {
                throw ex;
            }
        }

        
    }
}
