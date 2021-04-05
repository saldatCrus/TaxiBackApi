using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApplication.Models
{
    class Order
    {
        public int OrderNumber { get; set; }

        public List<Product> Products { get; set; }

        public DateTime createdAt { get; set; }
    }
}
