using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagerApplication.Models;

namespace ProductManagerApplication.Messages
{
    class ProductModelMessage : IMessage
    {
        public ProductModelMessage(Product InputProduct) 
        {
            Product = InputProduct;
        }

        public Product Product { get; set; }
    }
}
