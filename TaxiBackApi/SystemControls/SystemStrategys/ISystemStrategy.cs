using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;
using TaxiBackApi.Servises;
using TaxiBackApi.Repositoryes.Logs;
using Microsoft.Extensions.Logging;

namespace TaxiBackApi.SystemControls.SystemStrategys
{
    interface ISystemStrategy
    {
        /// <summary>
        /// Interface that implements system(Talabat,Uber,Zomato) methods 
        /// </summary>
        public Task<PackagedOrder> SystemProccesing(PackagedOrder InputPackagedOrder, ILogRepository logRepository, ILogger iLogger);
       
    }
}
