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
            Console.WriteLine("Нажмите кнопку для проверки");

            Console.ReadKey();

            Product product = new Product()
            {                 
                 id = "1",

                 name = "New Prodduct", 

                 comment="New Comment",

                 quantity="Hight",

                 paidPrice= "100",

                 unitPrice= "50",

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

            string JsonOrder = JsonSerializer.Serialize<Order>(order);

            httpClient = new HttpClient();

            while (true)
            {
                Console.WriteLine("Ответ: " + Convert.ToString(CheckTestControlller(JsonOrder).Result));

                Thread.Sleep(5000);
            }
        }

        static async Task<bool> CheckTestControlller(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/testConnection", null);

            Console.WriteLine("отправлен запрос :");

            var responseString = await Json.Content.ReadAsStringAsync();

            Console.WriteLine(responseString.ToString());

            Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/talabat/",new StringContent(JsonOrder));

            Console.WriteLine("отправлен запрос в талабат");

            return Json.IsSuccessStatusCode;

        }
    }
}
