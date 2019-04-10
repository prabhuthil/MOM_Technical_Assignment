using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOM_Assignment.Models
{
    public class Result
    {
        public List<string> resource_id { get; set; }
        public int limit { get; set; }
        public string total { get; set; }
        public List<Record> records { get; set; }
    }
}
