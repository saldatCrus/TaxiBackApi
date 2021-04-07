using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        [HttpPost("getallorders")]
        public async Task<IEnumerable<PackagedOrder>> GetAllOrders()
        {
            try
            {
                Trace.WriteLine("Ордеры отправлены");

                return await iOrdersRepository.GetAll();
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
        [HttpPost("getallexeptionlog")]
        public async Task<List<Log>> GetAllLog()
        {
            try
            {
                Trace.WriteLine("Логи отправлены");
                return iLogRepository.GetAll().Result.ToList();
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
