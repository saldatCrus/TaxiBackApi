using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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


        [HttpPost("getallproduct")]
        public async Task<IEnumerable<PackagedOrder>> GetAllProduct()
        {
            try
            {
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


        [HttpPost("getallexeptionlog")]
        public async Task<IEnumerable<Log>> GetAllLog()
        {
            try
            {
                return await iLogRepository.GetAll();
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
