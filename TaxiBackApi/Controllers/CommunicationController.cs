using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;
using TaxiBackApi.Repositoryes.Logs;
using TaxiBackApi.Repositoryes.Orders;
using TaxiBackApi.Servises;

namespace TaxiBackApi.Controllers
{
    [Route("api/communication")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly IOrdersRepository iOrdersRepository;

        private readonly ILogRepository iLogRepository;

        private readonly ILogger<TakeAndSafeController> iLogger;

        public CommunicationController(IOrdersRepository ordersRepository, ILogRepository logRepository, ILogger<TakeAndSafeController> Inputlogger)
        {
            iOrdersRepository = ordersRepository;

            iLogRepository = logRepository;

            iLogger = Inputlogger;
        }

        /// <summary>
        /// Отправить все заказы которые были сделаны
        /// </summary>
        [HttpGet("getallproduct")]
        public async Task<List<Product>> GetAllOrders()
        {
            try
            {
                Trace.WriteLine("Ордеры отправлены");

                var InputOrders = await iOrdersRepository.GetAll();

                var ProductToSend = new List<Product>();

                foreach (var Order in InputOrders) 
                {
                  var order = JsonConvert.DeserializeObject<Order>(Order.ConvertedJsonOrder);

                    foreach (var Product in order.Products)
                    {
                        ProductToSend.Add(Product);

                        Trace.WriteLine(Product.name);
                    }

                }

                return ProductToSend;
            }
            catch (Exception ERROR)
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }

            return null;
        }

        /// <summary>
        /// Отправить логи об ошибках на приложение
        /// </summary>
        [HttpGet("getallexeptionlog")]
        public async Task<List<Log>> GetAllLog() //
        {
            try
            {
                Trace.WriteLine("Логи отправлены");

                var InputLogs = await iLogRepository.GetAll();

                foreach(var log in InputLogs) 
                {
                    Trace.WriteLine(log.EventDataTime, log.EventName);
                }

                return  InputLogs.ToList();
            }
            catch (Exception ERROR)
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }

            return null;
        }

    }
}
