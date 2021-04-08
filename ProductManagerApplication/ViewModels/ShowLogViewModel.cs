using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProductManagerApplication.Models;
using System.Net.Http;
using ProductManagerApplication.Services;
using System.Diagnostics;

namespace ProductManagerApplication.ViewModels
{
    class ShowLogViewModel : BindableBase
    {
        public ObservableCollection<Log> Logs { get; set; } = new ObservableCollection<Log>();

        private static ServerСommunication _serverСommunication;


        public ShowLogViewModel(ServerСommunication InputserverСommunication) 
        {
            _serverСommunication = InputserverСommunication;
        }


        public ICommand GetAllOrders => new DelegateCommand(async() =>
        {
            try 
            {
                var InputLogList = await _serverСommunication.GetServerExeptionLogs();
                Logs = new ObservableCollection<Log>(InputLogList);
            }
            catch(Exception ERROR)
            {
                Trace.WriteLine(ERROR.Message);
            }

        }); // кнопка для получения всех логов

       
    }  
}
