using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiBackApi.Models
{
    public class Log
    {
        public int id { get; set; }

        public string EventName { get; set; }

        public string EventPlace { get; set; }

        public DateTime EventDataTime {get; set;}
    }
}
