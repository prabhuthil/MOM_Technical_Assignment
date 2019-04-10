using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM_Assignment.Models.Service.Interface
{
   public interface IBusinessService
    {
        void CompareFCvsBankAndHighLight();

        void CompareAvgFCvsBank();

        void SlopeTredLine();

    }
}
