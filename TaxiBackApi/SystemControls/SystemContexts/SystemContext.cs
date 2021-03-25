using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;
using TaxiBackApi.SystemControls.SystemStrategys;

namespace TaxiBackApi.SystemControls.SystemContexts
{
    class SystemContext
    {
        public ConvertedJsonOrder DoProcessing(ISystemStrategy systemStrategy, string Json) 
        {
            if (systemStrategy != null)
            {
                return systemStrategy.SystemProccesing(Json);
            }
            else return null;
        }
    }
}
