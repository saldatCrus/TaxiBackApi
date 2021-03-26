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
using TaxiBackApi.EntitySupportClass;
using Microsoft.EntityFrameworkCore;

namespace TaxiBackApi.Servises
{

    public class BaseHandler
    {
        private BackgroundWorker _bgWorker = new BackgroundWorker();

        public void SwitchDBHandler()
        {
            var dataBaseControls = new DataBaseControls();

            dataBaseControls.dBContext = new ApplicationDBContext(new DbContextOptions<ApplicationDBContext>());

            _bgWorker.DoWork += async (s, e) =>
            {

                while (true)
                {
                    var RawJsonOrder= dataBaseControls.FindRawOrder();

                    var Strategys =  new Dictionary<string, ISystemStrategy>
                    {
                    { "Talabat", new Talabat() },
                    { "Uber", new Uber() },
                    { "Zomato", new Zomato() },
                    };

                    var convertedJsonOrder = Strategys[RawJsonOrder.OrderType].SystemProccesing(RawJsonOrder.JsonOrder);

                    if (convertedJsonOrder != null) 
                    {
                        RawJsonOrder.OrderNumber = convertedJsonOrder.root.orderNumber;

                        RawJsonOrder.ConvertedJsonOrder = convertedJsonOrder;

                        dataBaseControls.EditOrder(RawJsonOrder);
                    }                    

                }
            };

            _bgWorker.RunWorkerAsync();
        }
    }
}
