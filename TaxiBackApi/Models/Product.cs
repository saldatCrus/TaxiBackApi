using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiBackApi.Models
{
    public class Product
    {
        public int id { get; set; }

        public string name { get; set; }

        public string comment { get; set; }

        public int quantity { get; set; }

        public int paidPrice { get; set; }

        public int unitPrice { get; set; }

        public string remoteCode { get; set; }

        public string description { get; set; }

        public string vatPercentage { get; set; }

        public string discountAmount { get; set; }
    }
}
