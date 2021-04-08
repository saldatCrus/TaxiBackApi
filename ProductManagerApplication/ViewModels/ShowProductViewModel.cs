using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProductManagerApplication.Models;
using ProductManagerApplication.Services;
using System.Diagnostics;

namespace ProductManagerApplication.ViewModels
{
    class ShowProductViewModel : BindableBase
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        private static ServerСommunication _serverСommunication;

        public ShowProductViewModel(ServerСommunication InputserverСommunication) 
        {
            _serverСommunication = InputserverСommunication;
        }

        public ICommand GetAllLog => new DelegateCommand(async () =>
        {
            try
            {
                var InputProductList = await _serverСommunication.GetServerProducts();
                Products = new ObservableCollection<Product>(InputProductList);
            }
            catch (Exception ERROR)
            {
                Trace.WriteLine(ERROR.Message);
            }

        }); // кнопка для получения всех логов
    }
}
