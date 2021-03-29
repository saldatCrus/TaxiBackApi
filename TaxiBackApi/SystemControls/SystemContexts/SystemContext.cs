using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;
using TaxiBackApi.Repositoryes.Logs;
using TaxiBackApi.SystemControls.SystemStrategys;

namespace TaxiBackApi.SystemControls.SystemContexts
{
    class SystemContext
    {
        /// <summary>
        ///  Интерфейс ISystem всегда хотел быть стратегией, но что то пошло не так.... 
        /// </summary>
        public Task<PackagedOrder> DoProcessing(ISystemStrategy systemStrategy, PackagedOrder InputPackagedOrder, ILogRepository logRepository, ILogger iLogger) 
        {
            if (systemStrategy != null)
            {
                return systemStrategy.SystemProccesing(InputPackagedOrder,  logRepository, iLogger);
            }
            else return null;
        }
    }
}
