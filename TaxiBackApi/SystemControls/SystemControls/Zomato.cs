using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.SystemControls.SystemStrategys;
using TaxiBackApi.Models;

namespace TaxiBackApi.SystemControls.SystemControls
{
    public class Zomato : ISystemStrategy
    {
        public ConvertedJsonOrder SystemProccesing(string Json)
        {
            var DeserializatedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ConvertedJsonOrder>(Json);

            for (int i = 0; i >= DeserializatedJson.root.products.Count; i++)
            {
                DeserializatedJson.root.products[i].paidPrice = DeserializatedJson.root.products[i].paidPrice/DeserializatedJson.root.products[i].quantity;
            }

            return DeserializatedJson;
        }
    }
}
