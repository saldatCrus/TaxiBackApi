using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApplication.Models
{
    public class PackagedOrder
    {
        public int Id { get; set; }

        public string OrderType { get; set; }

        public int OrderNumber { get; set; }

        public string JsonOrder { get; set; }

        public string ConvertedJsonOrder { get; set; }

        public DateTime DateTime { get; set; }
    }
}
