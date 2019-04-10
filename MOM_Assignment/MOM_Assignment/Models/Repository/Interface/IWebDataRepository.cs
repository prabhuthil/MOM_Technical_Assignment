using MOM_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM_Assignment.Repository.Interface
{
    // You need interface to keep your repository usage abstracted
    // from concrete implementation as this is the whole point of 
    // repository pattern.
    public interface IWebDataRepository
    {
        Task<List<Record>> GetWebDataAsync(string startDate, string endDate);
    }
}
