using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiBackApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string OrderType { get; set; }

        public int OrderNumber { get; set; }

        public string JsonOrder { get; set; }

        public ConvertedJsonOrder ConvertedJsonOrder { get; set;  }

        public DateTime DateTime { get; set; }
    }
}
