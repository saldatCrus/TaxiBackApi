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

            Product product = new Product()
            {                 
                 id = 1,

                 name = "New Prodduct", 

                 comment="New Comment",

                 quantity= 5,

                 paidPrice= 100,

                 unitPrice= 50,

                 remoteCode="1234",

                 description= "New Super product, just buy this",

                 vatPercentage="20",

                 discountAmount="10",
            };

            Root root = new Root()
            {
                orderNumber = "1",

                products = new List<Product>() { product, product, product },

                createdAt = DateTime.Now
            };

            Order order = new Order() 
            {
                Product = product,

                Root = root
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
