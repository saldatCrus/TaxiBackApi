using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.SystemControls.SystemStrategys;
using TaxiBackApi.Models;
using Newtonsoft.Json;

namespace TaxiBackApi.SystemControls.SystemControls
{
    public class Talabat : ISystemStrategy
    {
        public PackagedOrder SystemProccesing(PackagedOrder InputPackagedOrder)
        {
            var DeserializatedJsonOrder = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(InputPackagedOrder.JsonOrder);

            foreach(Product product  in DeserializatedJsonOrder.Products) 
            {
                product.paidPrice = product.paidPrice * -1;
            }

            InputPackagedOrder.OrderNumber = DeserializatedJsonOrder.OrderNumber;

            InputPackagedOrder.ConvertedJsonOrder = JsonConvert.SerializeObject(DeserializatedJsonOrder);

            return InputPackagedOrder;
        }
    }
}
