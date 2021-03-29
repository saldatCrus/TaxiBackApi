using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TaxiBackApi.Repositoryes.Orders;
using TaxiBackApi.Repositoryes.Logs;
using TaxiBackApi.Models;
using TaxiBackApi.Servises;
using Microsoft.Extensions.Logging;

namespace TaxiBackApi.Controllers
{
    [ApiController]
    [Route(template: "/api/order")]
    public class TakeAndSafeController : ControllerBase
    {
        private readonly IOrdersRepository iOrdersRepository;

        private readonly ILogRepository iLogRepository;

        private readonly ILogger<TakeAndSafeController> iLogger;

        public TakeAndSafeController(IOrdersRepository ordersRepository, ILogRepository logRepository, ILogger<TakeAndSafeController> Inputlogger)
        {
            iOrdersRepository = ordersRepository;

            iLogRepository = logRepository;

            iLogger = Inputlogger;
        }

        [HttpPost("talabat")]
        public async Task TalabatTakeAndSafe(object Json)
        {

            try
            {
                if (Json != null)
                {
                    Trace.WriteLine("Json пришёл успешно");

                    await iOrdersRepository.Create(new PackagedOrder()
                    {
                        OrderNumber = 0,
                        OrderType = "Talabat",
                        JsonOrder = Convert.ToString(Json),
                        ConvertedJsonOrder = null,
                        DateTime = DateTime.Now,
                    });


                }
                else Trace.WriteLine("Json не пришёл");
            }
            catch (Exception ERROR)
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }
        }

        [HttpPost("zomato")]
        public async void ZomatoTakeAndSafe(object Json)
        {
            try
            {
                if (Json != null)
                {
                    Trace.WriteLine("Json пришёл успешно");

                    await iOrdersRepository.Create(new PackagedOrder()
                    {
                        OrderNumber = 0,
                        OrderType = "Zomato",
                        JsonOrder = Convert.ToString(Json),
                        ConvertedJsonOrder = null,
                        DateTime = DateTime.Now,
                    });
                }
                else Trace.WriteLine("Json не пришёл");
            }
            catch(Exception ERROR) 
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }
        }

        [HttpPost("uber")]
        public async void UberTakeAndSafe(object Json)
        {
            try
            {
                if (Json != null)
                {
                    Trace.WriteLine("Uber пришёл успешно");

                    await iOrdersRepository.Create(new PackagedOrder()
                    {
                        OrderNumber = 0,
                        OrderType = "Uber",
                        JsonOrder = Convert.ToString(Json),
                        ConvertedJsonOrder = null,
                        DateTime = DateTime.Now,
                    });

                }
                else Trace.WriteLine("Json не пришёл");
            }
            catch(Exception ERROR) 
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }
           
        }

        [HttpPost("testConnection")]
        public async Task<string> TestConnectionMetod()
        {
            try
            {
                throw new Exception("KEKWExeptionActivated(Test)");
            }
            catch (Exception ERROR)
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }
            Trace.WriteLine("Тест прошёл успешно");
            return "Пепегас, полёт нормальный, слышу вас хорошо кхххх....";

        }
    }
}
