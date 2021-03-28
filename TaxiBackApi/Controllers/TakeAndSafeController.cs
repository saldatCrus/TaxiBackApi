using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxiBackApi.Data;
using Microsoft.EntityFrameworkCore;
using TaxiBackApi.Repositoryes;
using TaxiBackApi.Models;

namespace TaxiBackApi.Controllers
{
    [ApiController]
    [Route(template: "/api/order")]
    public class TakeAndSafeController : ControllerBase
    {
        private readonly IOrdersRepository iOrdersRepository;

        public TakeAndSafeController(IOrdersRepository ordersRepository)
        {
            iOrdersRepository = ordersRepository;
        }

        [HttpPost("talabat")]
        public async void TalabatTakeAndSafe(object Json)
        {
            if (Json != null) 
            {
                Trace.WriteLine("Json пришёл успешно");

                var Order = new Order()
                {
                    OrderNumber = 0,
                    OrderType = "Talaban",
                    JsonOrder = Convert.ToString(Json),
                    ConvertedJsonOrder = null,
                    DateTime = DateTime.Now,
                };

                await iOrdersRepository.Create(Order);


            }                
            else Trace.WriteLine("Json не пришёл");
        }

        [HttpPost("zomato")]
        public async void ZomatoTakeAndSafe(string Json)
        {
            if (Json != null) 
            {
                Trace.WriteLine("Json пришёл успешно");

                //var DbControls = new DbControls(DbInitial.GetAppdbContent());

                //DbControls.AddOrder(new Models.Order
                //{
                //    OrderNumber = 0,
                //    OrderType = "Zomato",
                //    JsonOrder = Convert.ToString(Json),
                //    ConvertedJsonOrder = null,
                //    DateTime = DateTime.Now,
                //});
            } 
            else Trace.WriteLine("Json не пришёл");
        }

        [HttpPost("uber")]
        public async void UberTakeAndSafe([FromBody]string Json)
        {
            if (Json != null) 
            {
                Trace.WriteLine("Uber пришёл успешно");

                //var DbControls = new DbControls(DbInitial.GetAppdbContent());

                //DbControls.AddOrder(new Models.Order
                //{
                //    OrderNumber = 0,
                //    OrderType = "Uber",
                //    JsonOrder = Convert.ToString(Json),
                //    ConvertedJsonOrder = null,
                //    DateTime = DateTime.Now,
                //});

            } 
            else Trace.WriteLine("Json не пришёл");

           
        }

        [HttpPost("testConnection")]
        public string TestConnectionMetod()
        {
            Trace.WriteLine("Тест прошёл успешно");
            return "Пепегас, полёт нормальный, слышу вас хорошо кхххх....";
        }
    }
}
