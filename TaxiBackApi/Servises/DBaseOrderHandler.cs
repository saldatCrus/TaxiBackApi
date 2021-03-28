using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaxiBackApi.SystemControls.SystemStrategys;
using TaxiBackApi.SystemControls.SystemControls;
using TaxiBackApi.SystemControls.SystemContexts;
using TaxiBackApi.Models;
using Microsoft.EntityFrameworkCore;
using TaxiBackApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.IO;
using TaxiBackApi.Repositoryes;

namespace TaxiBackApi.Servises
{

    public class DBaseOrderHandler
    {
        private readonly IOrdersRepository iOrdersRepository;

        public DBaseOrderHandler(IOrdersRepository ordersRepository)
        {
            iOrdersRepository = ordersRepository;
        }

        private BackgroundWorker _bgWorker = new BackgroundWorker();


        public void DBHandlerStart()
        {
            _bgWorker.DoWork += async (s, e) =>
            {
                while (true)
                {
                    Trace.WriteLine("Сервис работает");

                    var RawOrder = await iOrdersRepository.GetRawOrder();

                    if (RawOrder != null)
                    {
                        var Strategys = new Dictionary<string, ISystemStrategy>
                        {
                        { "Talabat", new Talabat() },
                        { "Uber", new Uber() },
                        { "Zomato", new Zomato() },
                        };

                        var convertedJsonOrder = Strategys[RawOrder.OrderType].SystemProccesing(RawOrder.JsonOrder);

                        if (convertedJsonOrder != null)
                        {
                            RawOrder.OrderNumber = convertedJsonOrder.root.orderNumber;

                            RawOrder.ConvertedJsonOrder = convertedJsonOrder;

                            await iOrdersRepository.Update(RawOrder);

                        }
                    }                

                    
                    Thread.Sleep(5000);
                }
            };

            _bgWorker.RunWorkerAsync();
        }
    }
}
