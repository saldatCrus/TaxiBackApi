using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Repositoryes.Orders;
using TaxiBackApi.Models;
using System.Diagnostics;

namespace TaxiBackApi.Servises
{
    public class ErrorLoger
    {
        private readonly IOrdersRepository iOrdersRepository;

        public ErrorLoger(IOrdersRepository ordersRepository)
        {
            iOrdersRepository = ordersRepository;
        }

        public async Task NewLog(Log Inputlog) 
        {
            Trace.WriteLine("Json пришёл успешно");
        }


    }
}
