using MOM_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM_Assignment.Service.Interface
{
   public interface IWebDataService
    {
        Task<List<Record>> GetWebDataAsync(string startDate, string endDate);
    }
}
