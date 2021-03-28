using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiBackApi.Models
{
    public class Root
    {
        public int RootId { get; set; }

        public int orderNumber { get; set; }

        public List<Product> products { get; set; }

        public DateTime createdAt { get; set; }
    }
}
