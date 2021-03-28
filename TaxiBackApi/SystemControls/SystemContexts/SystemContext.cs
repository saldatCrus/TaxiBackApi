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
        public PackagedOrder DoProcessing(ISystemStrategy systemStrategy, PackagedOrder InputPackagedOrder) 
        {
            if (systemStrategy != null)
            {
                return systemStrategy.SystemProccesing(InputPackagedOrder);
            }
            else return null;
        }
    }
}
