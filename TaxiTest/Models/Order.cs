using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiTest.Models
{
    class Order
    {
        public int OrderNumber { get; set; }

        public List<Product> Products { get; set; }

        public DateTime createdAt {get; set;}
    }
}

