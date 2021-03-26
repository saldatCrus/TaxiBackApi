using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace TaxiBackApi.Controllers
{
    [ApiController]
    [Route(template: "/api/order")]
    public class TakeAndSafeController : ControllerBase
    {
        

        [HttpPost("talabat")]
        public void TalabatTakeAndSafe(object Json)
        {
            Trace.WriteLine("Талабат на связи");
            if (Json != null) Trace.WriteLine("Json пришёл успешно");
            else Trace.WriteLine("Json не пришёл");

            //DataBaseContext. = DataBaseContext;

            //dataBaseControls.CreateOrderOnDB(Json, "Talabat");




        }

        [HttpPost("zomato")]
        public void ZomatoTakeAndSafe(string Json)
        {
            Trace.WriteLine("Зомато на связи");
            if (Json != null) Trace.WriteLine("Zomato пришёл успешно");

            //dataBaseControls.dBContext = new ApplicationDBContext(new DbContextOptions<ApplicationDBContext>());

            //dataBaseControls.CreateOrderOnDB(Json, "Zomato");
        }

        [HttpPost("uber")]
        public void UberTakeAndSafe([FromBody]string Json)
        {
            Trace.WriteLine("Убер на связи");
            if (Json != null) Trace.WriteLine("Uber пришёл успешно");

            //dataBaseControls.dBContext = new ApplicationDBContext(new DbContextOptions<ApplicationDBContext>());

            //dataBaseControls.CreateOrderOnDB(Json, "Uber");
        }

        [HttpPost("testConnection")]
        public string TestConnectionMetod()
        {
            Trace.WriteLine("Тест прошёл успешно");
            return "Пепегас, полёт нормальный, слышу вас хорошо кхххх....";
        }
    }
}
