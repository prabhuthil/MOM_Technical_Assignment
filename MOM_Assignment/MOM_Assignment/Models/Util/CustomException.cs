using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM_Assignment.Models.Util
{
   public  class CustomException : Exception
    {
        public CustomException()
        {
        }
        public CustomException(string message)
            : base(message)
        {
        }

    }

   public  class WebAPIConnectionCustomException : Exception
    {
        public WebAPIConnectionCustomException()
        {
        }
        public WebAPIConnectionCustomException(string message)
            : base(message)
        {
        }

    }
}
