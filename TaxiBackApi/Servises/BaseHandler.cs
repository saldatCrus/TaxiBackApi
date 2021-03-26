using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaxiBackApi.SystemControls.SystemStrategys;
using TaxiBackApi.SystemControls.SystemControls;
using TaxiBackApi.SystemControls.SystemContexts;
using TaxiBackApi.Models;

namespace TaxiBackApi.Servises
{

    public class BaseHandler
    {
        private BackgroundWorker _bgWorker = new BackgroundWorker();

        

        public void SwitchDBHandler(bool Status, int interval, string Json)
        {

            string Whatsystem = "talabat";

            _bgWorker.DoWork += async (s, e) =>
            {
                while (Status == true)
                {
                    var Strategys =  new Dictionary<string, ISystemStrategy>
                    {
                    { "Talabat", new Talabat() },
                    { "Uber", new Uber() },
                    { "Zomato", new Zomato() },
                    };

                    var convertedJsonOrder = Strategys[Whatsystem].SystemProccesing(Json);


                }
            };

            _bgWorker.RunWorkerAsync();
        }
    }
}
