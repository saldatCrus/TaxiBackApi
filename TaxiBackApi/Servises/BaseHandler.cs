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

namespace TaxiBackApi.Servises
{

    public class BaseHandler
    {
        private BackgroundWorker _bgWorker = new BackgroundWorker();

        public void SwitchDBHandler(bool Status, int interval)
        {
            _bgWorker.DoWork += async (s, e) =>
            {
                while (Status == true)
                {
                   



                }
            };

            _bgWorker.RunWorkerAsync();
        }
    }
}
