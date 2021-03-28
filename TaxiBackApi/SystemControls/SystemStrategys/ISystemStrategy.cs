using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;

namespace TaxiBackApi.SystemControls.SystemStrategys
{
    interface ISystemStrategy
    {
        public PackagedOrder SystemProccesing(PackagedOrder InputPackagedOrder);
    }
}
