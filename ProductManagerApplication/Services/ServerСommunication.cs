using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApplication.Services
{
    class ServerСommunication
    {
        private HttpClient httpClient;

        public ServerСommunication() 
        {
            httpClient = new HttpClient();
        }

        public async Task SendToTestControlller(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/testConnection", null);

            Console.WriteLine("отправлен запрос :");

        }

        public async Task SendToTalabatController(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/talabat/", new StringContent(JsonOrder, Encoding.UTF8, "application/json"));

        }

        public async Task SendToUberController(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/uber/", new StringContent(JsonOrder, Encoding.UTF8, "application/json"));

            Console.WriteLine("отправлен запрос в Убер");

        }

        public async Task SendToZomatoController(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/zomato/", new StringContent(JsonOrder, Encoding.UTF8, "application/json"));

            Console.WriteLine("отправлен запрос в Зомато");

        }
    }
}
