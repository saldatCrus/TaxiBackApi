using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiBackApi.Controllers
{
    [ApiController]
    [Route(template: "/api/order")]
    public class TakeAndSafeController : Controller
    {
        [HttpPost("talabat")]
        public void TalabatTakeAndSafe(string Json)
        {
            Trace.WriteLine("Талабат на связи");
            if (Json != null) Trace.WriteLine("Json пришёл успешно");
            else Trace.WriteLine("Json не пришёл");
        }

        [HttpPost("zomato")]
        public void ZomatoTakeAndSafe(string Json)
        {
            Trace.WriteLine("Зомато на связи");
            if (Json != null) Trace.WriteLine("Zomato пришёл успешно");
        }

        [HttpPost("uber")]
        public void UberTakeAndSafe(string Json)
        {
            Trace.WriteLine("Убер на связи");
            if (Json != null) Trace.WriteLine("Uber пришёл успешно");
        }

        [HttpPost("testConnection")]
        public string TestConnectionMetod()
        {
            Trace.WriteLine("Тест прошёл успешно");
            return "Пепегас, полёт нормальный, слышу вас хорошо кхххх....";
        }
    }
}
