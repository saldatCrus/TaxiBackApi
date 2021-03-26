using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TaxiBackApi.EntitySupportClass;
using Microsoft.EntityFrameworkCore;

namespace TaxiBackApi.Controllers
{
    [ApiController]
    [Route(template: "/api/order")]
    public class TakeAndSafeController : Controller
    {
        

        [HttpPost("talabat")]
        public void TalabatTakeAndSafe(object Json)
        {
            Trace.WriteLine("Талабат на связи");
            if (Json != null) Trace.WriteLine("Json пришёл успешно");
            else Trace.WriteLine("Json не пришёл");

            var dataBaseControls = new DataBaseControls();

            var DataBaseContext = new ApplicationDBContext(new DbContextOptions<ApplicationDBContext>());

            dataBaseControls.dBContext = DataBaseContext;

            dataBaseControls.CreateOrderOnDB(Json, "Talabat");




        }

        [HttpPost("zomato")]
        public void ZomatoTakeAndSafe(string Json)
        {
            Trace.WriteLine("Зомато на связи");
            if (Json != null) Trace.WriteLine("Zomato пришёл успешно");

            var dataBaseControls = new DataBaseControls();

            dataBaseControls.dBContext = new ApplicationDBContext(new DbContextOptions<ApplicationDBContext>());

            dataBaseControls.CreateOrderOnDB(Json, "Zomato");
        }

        [HttpPost("uber")]
        public void UberTakeAndSafe([FromBody]string Json)
        {
            Trace.WriteLine("Убер на связи");
            if (Json != null) Trace.WriteLine("Uber пришёл успешно");

            var dataBaseControls = new DataBaseControls();

            dataBaseControls.dBContext = new ApplicationDBContext(new DbContextOptions<ApplicationDBContext>());

            dataBaseControls.CreateOrderOnDB(Json, "Uber");
        }

        [HttpPost("testConnection")]
        public string TestConnectionMetod()
        {
            Trace.WriteLine("Тест прошёл успешно");
            return "Пепегас, полёт нормальный, слышу вас хорошо кхххх....";
        }
    }
}
