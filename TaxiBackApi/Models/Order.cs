using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiBackApi.Models
{
    class Order
    {
        public Product Product { get; set; }

        public Root Root { get; set;}
    }
}

