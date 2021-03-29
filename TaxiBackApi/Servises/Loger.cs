using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Repositoryes.Logs;
using TaxiBackApi.Models;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using TaxiBackApi.Repositoryes.Orders;
using System.IO;

namespace TaxiBackApi.Servises
{
    public class Loger
    {
        private readonly ILogRepository iLogRepository;

        public Loger(ILogRepository logRepository)
        {
            iLogRepository = logRepository;
        }

        /// <summary>
        /// Method for implementing exceptions and writing to database
        /// <paramref name="exception"/> it your Exception
        /// </summary>
        public async Task DbExeptionHandler(ILogger Inputlogger, Exception exception)
        {
            Inputlogger.LogError($"ERROR : [{exception.Message}] at [{DateTime.Now}]");

            await iLogRepository.Create(new Log
            {
                EventDataTime = DateTime.Now,

                EventName = exception.Message,

                EventPlace = exception.StackTrace.ToString()
            });
        }

        /// <summary>
        /// Method for implementing exceptions and writing to File
        /// <paramref name="exception"/> it your Exception
        /// </summary>
        public async Task FileExeptionHandler(Exception exception)
        {
            using (StreamWriter sw = new StreamWriter("AppLog.txt", true, System.Text.Encoding.Default))
            {
                await sw.WriteLineAsync($"ERROR: [{exception.Message}] ON: [{exception.StackTrace}] AT: [{DateTime.Now}]");
            }
        }
    }
}
