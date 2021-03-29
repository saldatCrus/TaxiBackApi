using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.SystemControls.SystemStrategys;
using TaxiBackApi.Models;
using Newtonsoft.Json;
using TaxiBackApi.Servises;
using TaxiBackApi.Repositoryes.Logs;
using Microsoft.Extensions.Logging;

namespace TaxiBackApi.SystemControls.SystemControls
{
    public class Talabat : ISystemStrategy
    {
        /// <summary>
        /// Method for conversions raw order to Cooked order KEKW;
        /// Method for processing the Talabat system
        /// </summary>
        public async Task<PackagedOrder> SystemProccesing(PackagedOrder InputPackagedOrder, ILogRepository iLogRepository, ILogger iLogger)
        {
            var DeserializatedJsonOrder = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(InputPackagedOrder.JsonOrder);

            try
            {
                foreach (Product product in DeserializatedJsonOrder.Products)
                {
                    product.paidPrice = product.paidPrice * -1;
                }

                InputPackagedOrder.OrderNumber = DeserializatedJsonOrder.OrderNumber;

                InputPackagedOrder.ConvertedJsonOrder = JsonConvert.SerializeObject(DeserializatedJsonOrder);
            }
            catch(Exception ERROR) 
            {
                var loger = new Loger(iLogRepository);

                await loger.DbExeptionHandler(iLogger, ERROR);

                await loger.FileExeptionHandler(ERROR);
            }

            return InputPackagedOrder;
        }
    }
}
