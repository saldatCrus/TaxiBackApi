using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;

namespace TaxiBackApi.Data
{
    public class DbControls
    {
        private readonly AppDbContent appDbContent;

        public DbControls(AppDbContent appDbContent) 
        {
            this.appDbContent = appDbContent;
        }

        public Order GetRawOrder() 
        {
            return appDbContent.Orders.FirstOrDefault(p => p.ConvertedJsonOrder == null);
        }

        public AddOrder(Order order)
        {
            return appDbContent.Orders(add);
        }
    }
}
