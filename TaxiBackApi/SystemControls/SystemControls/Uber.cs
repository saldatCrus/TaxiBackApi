using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.SystemControls.SystemStrategys;
using TaxiBackApi.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using TaxiBackApi.Repositoryes.Logs;
using Microsoft.Extensions.Logging;
using TaxiBackApi.Servises;

namespace TaxiBackApi.SystemControls.SystemControls
{
    public class Uber : ISystemStrategy
    {
        /// <summary>
        /// Method for conversions raw order to Cooked order KEKW;
        /// Method for processing the Uber system;
        /// Try for get Exception
        /// </summary>
        public async Task<PackagedOrder> SystemProccesing(PackagedOrder InputPackagedOrder, ILogRepository iLogRepository, ILogger iLogger)
        {
            var DeserializatedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(InputPackagedOrder.JsonOrder); 

            InputPackagedOrder.OrderNumber = DeserializatedJson.OrderNumber;

            InputPackagedOrder.ConvertedJsonOrder = JsonConvert.SerializeObject(DeserializatedJson);
            try
            {
                throw new Exception("KEKWExeptionActivated(UBER)");
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
