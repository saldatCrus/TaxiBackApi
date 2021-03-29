using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using TaxiBackApi.SystemControls.SystemStrategys;
using TaxiBackApi.SystemControls.SystemControls;
using TaxiBackApi.Repositoryes.Orders;
using TaxiBackApi.Repositoryes.Logs;
using Microsoft.Extensions.Logging;

namespace TaxiBackApi.Servises
{

    public class DBaseOrderHandler
    {
        private readonly IOrdersRepository iOrdersRepository;

        private readonly ILogRepository iLogRepository;

        private readonly ILogger iLogger;

        public DBaseOrderHandler(IOrdersRepository ordersRepository, ILogRepository logRepository, ILogger Inputlogger)
        {
            iOrdersRepository = ordersRepository;

            iLogRepository = logRepository;

            iLogger = Inputlogger;
        }

        private BackgroundWorker _bgWorker = new BackgroundWorker();

        /// <summary>
        /// This method includes a background worker 
        /// <para>How to stop it? KEKW</para>
        /// </summary>
        public void DBHandlerStart()
        {
            _bgWorker.DoWork += async (s, e) =>
            {
                while (true)
                {
                    try { 
                    Trace.WriteLine("Сервис работает");

                    var RawOrder = await iOrdersRepository.GetRawOrder();

                    if (RawOrder != null)
                    {
                        var Strategys = new Dictionary<string, ISystemStrategy>
                        {
                        { "Talabat", new Talabat() },
                        { "Uber", new Uber() },
                        { "Zomato", new Zomato() }
                        };

                        
                        RawOrder = Strategys[RawOrder.OrderType].SystemProccesing(RawOrder, iLogRepository, iLogger).Result;

                        iOrdersRepository.Update(RawOrder);

                    }                

                    Thread.Sleep(5000);
                    }
                    catch(Exception ERROR)
                    {
                        var loger = new Loger(iLogRepository);

                        await loger.DbExeptionHandler(iLogger, ERROR);

                        await loger.FileExeptionHandler(ERROR);
                    }

                }
            };

            _bgWorker.RunWorkerAsync();
        }
    }
}
