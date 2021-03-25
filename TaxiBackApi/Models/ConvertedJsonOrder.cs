using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiBackApi.Models
{
    public class ConvertedJsonOrder
    {
        public class Product
        {
            public string id { get; set; }

            public string name { get; set; }

            public string comment { get; set; }

            public string quantity { get; set; }

            public string paidPrice { get; set; }

            public string unitPrice { get; set; }

            public string remoteCode { get; set; }

            public string description { get; set; }

            public string vatPercentage { get; set; }

            public string discountAmount { get; set; }
        }

        public class Root
        {
            public string orderNumber { get; set; }

            public List<Product> products { get; set; }

            public DateTime createdAt { get; set; }
        }
    }
}

