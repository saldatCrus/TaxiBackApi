using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using TaxiTest.Models;

namespace TaxiTest
{
    class Program
    {
        private static HttpClient httpClient;

        static void Main(string[] args)
        {

            Product product1 = new Product()
            {                 
                 id = 1,

                 name = "Papas House Pasta", 

                 comment= "no green peppers, no pepperoni and no Turkey ham. Instead add grilled chicken",

                 quantity= 1,

                 paidPrice= 24,

                 unitPrice= 24,

                 remoteCode= "ProdId_33bf1315-3c0c-4df5-952b-f45a5cb1e501",

                 description= "New Super product, just buy this",

                 vatPercentage=":",

                 discountAmount=":",
            };

            Product product2 = new Product()
            {
                id = 2,

                name = "Cheesesticks",

                comment = ":",

                quantity = 1,

                paidPrice = 21,

                unitPrice = 21,

                remoteCode = "ProdId_ddb762ea-5dd4-4a40-bdda-63f699c38aa3_77aa67ad-37bc-4ee7-8d2a-4320e3c04098",

                description = "New Super product, just buy this",

                vatPercentage = ":",

                discountAmount = ":",
            };

            Product product3 = new Product()
            {
                id = 3,

                name = "Tiramisu",

                comment = ":",

                quantity = 2,

                paidPrice = 30,

                unitPrice = 30,

                remoteCode = "ProdId_70bbd461-bc1c-49fa-a23e-0718d8536284",

                description = ":",

                vatPercentage = ":",

                discountAmount = ":",
            };

            Product product4 = new Product()
            {
                id = 4,

                name = "Pepperoni Rolls",

                comment = ":",

                quantity = 1,

                paidPrice = 23,

                unitPrice = 23,

                remoteCode = "ProdId_27d21751-b288-4682-b0d4-0dee7284d7ed_5eaee492-c695-4657-8ad7-d1fdf0ac0c24",

                description = "New Super product, just buy this",

                vatPercentage = ":",

                discountAmount = ":",
            };

            Order order = new Order()
            {
                OrderNumber = DateTime.Now.Second,

                Products = new List<Product> {product1, product2, product3, product4 }
            };            

            string JsonOrder = JsonConvert.SerializeObject(order);

            httpClient = new HttpClient();

            int i = 0;

            while (true) 
            {
                Console.WriteLine("Ведите номер запроса [1] - Talaban; [2] - Zomato; [3] - Uber; [4] - Test");

                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case (1): Console.WriteLine("Ответ: " + Convert.ToString(CheckTalabatControlller(JsonOrder).Result)); break;

                    case (2): Console.WriteLine("Ответ: " + Convert.ToString(CheckZomatoControlller(JsonOrder).Result)); break;

                    case (3): Console.WriteLine("Ответ: " + Convert.ToString(CheckUberControlller(JsonOrder).Result)); break;

                    case (4): Console.WriteLine("Ответ: " + Convert.ToString(CheckTestControlller(JsonOrder).Result)); break;
                };

                Console.ReadKey();
            }


        }

        static async Task<bool> CheckTestControlller(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/testConnection", null);

            Console.WriteLine("отправлен запрос :");

            var responseString = await Json.Content.ReadAsStringAsync();

            Console.WriteLine(responseString.ToString());

            return Json.IsSuccessStatusCode;

        }

        static async Task<bool> CheckTalabatControlller(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/talabat/", new StringContent(JsonOrder, Encoding.UTF8, "application/json"));

            Console.WriteLine("отправлен запрос в талабат");

            return Json.IsSuccessStatusCode;

        }

        static async Task<bool> CheckUberControlller(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/uber/", new StringContent(JsonOrder, Encoding.UTF8, "application/json"));

            Console.WriteLine("отправлен запрос в Убер");

            return Json.IsSuccessStatusCode;

        }

        static async Task<bool> CheckZomatoControlller(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/zomato/", new StringContent(JsonOrder, Encoding.UTF8, "application/json"));

            Console.WriteLine("отправлен запрос в Зомато");

            return Json.IsSuccessStatusCode;

        }
    }
}
