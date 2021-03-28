using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.SystemControls.SystemStrategys;
using TaxiBackApi.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace TaxiBackApi.SystemControls.SystemControls
{
    public class Uber : ISystemStrategy
    {
        public PackagedOrder SystemProccesing(PackagedOrder InputPackagedOrder)
        {
            var DeserializatedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(InputPackagedOrder.JsonOrder);
            try 
            {
                throw new Exception("KEKWExeptionActivated");
            }
            catch (Exception ERROR)
            {
                Trace.WriteLine($"Кто то ошибся дверью: {ERROR.Message}");
            }

            InputPackagedOrder.OrderNumber = DeserializatedJson.OrderNumber;

            InputPackagedOrder.ConvertedJsonOrder = JsonConvert.SerializeObject(DeserializatedJson);

            return InputPackagedOrder ;

        }
    }
}
