using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiTest.Models
{
    class Root
    {
        public string orderNumber { get; set; }

        public List<Product> products { get; set; }

        public DateTime createdAt { get; set; }
    }
}
