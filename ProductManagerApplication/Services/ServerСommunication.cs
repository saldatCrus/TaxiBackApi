using ProductManagerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProductManagerApplication.Services
{
    class ServerСommunication
    {
        private HttpClient httpClient;

        public ServerСommunication()
        {
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Метод для проверки связи с сервером
        /// </summary>
        public async Task SendToTestControlller(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/testConnection", null);

        }

        /// <summary>
        /// Метод для отправки заказа в систему Talabat
        /// </summary>
        public async Task SendToTalabatController(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/talabat/", new StringContent(JsonOrder, Encoding.UTF8, "application/json"));

        }

        /// <summary>
        /// Метод для отправки заказа в систему Uber
        /// </summary>
        public async Task SendToUberController(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/uber/", new StringContent(JsonOrder, Encoding.UTF8, "application/json"));


        }

        /// <summary>
        /// Метод для отправки заказа в систему Zomato
        /// </summary>
        public async Task SendToZomatoController(string JsonOrder)
        {
            var Json = await httpClient.PostAsync(requestUri: $"http://localhost:5000/api/order/zomato/", new StringContent(JsonOrder, Encoding.UTF8, "application/json"));


        }

        /// <summary>
        /// Метод для получения логов об ошибках на сервере
        /// </summary>
        public async Task<List<Log>> GetServerExeptionLogs()
        {
            var Json = await httpClient.GetAsync(requestUri: $"http://localhost:5000/api/communication/getallexeptionlog/");

            var responseString = await Json.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Log>>(responseString).ToList();

        }

        /// <summary>
        /// Метод для получения заказов с сервера
        /// </summary>
        public async Task<List<Product>> GetServerProducts()
        {
            var Json = await httpClient.GetAsync(requestUri: $"http://localhost:5000/api/communication/getallproduct/");

            var responseString = await Json.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Product>>(responseString);

        }
    }
}
