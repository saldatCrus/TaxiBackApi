using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.SystemControls.SystemStrategys;
using TaxiBackApi.Models;
using System.Diagnostics;

namespace TaxiBackApi.SystemControls.SystemControls
{
    public class Uber : ISystemStrategy
    {
        public ConvertedJsonOrder SystemProccesing(string Json)
        {
            var DeserializatedJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ConvertedJsonOrder>(Json);
            try 
            {
                throw new Exception("KEKWExeptionActivated");
            }
            catch (Exception ERROR)
            {
                Trace.WriteLine($"Кто то ошибся дверью: {ERROR.Message}");
            }
            return DeserializatedJson;

        }
    }
}
