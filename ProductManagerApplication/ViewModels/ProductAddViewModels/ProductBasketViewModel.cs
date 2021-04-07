using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagerApplication.Services;
using ProductManagerApplication.Models;
using ProductManagerApplication.Messages;
using ProductManagerApplication.Events;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Data;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProductManagerApplication.ViewModels.ProductAddViewModels
{
    class ProductBasketViewModel : BindableBase
    {
        public ObservableCollection<SellSystem> SalesSystems { get; set; } = new ObservableCollection<SellSystem>();

        public ObservableCollection<Product> ProductsOnBasket { get; set; } = new ObservableCollection<Product>();

        public object ObservableCollectionLocker = new object();

        public SellSystem SelectedSalesSystem { get; set; }

        private readonly MessageBus _messageBus;

        private readonly EventBus _eventBus;

        private static ServerСommunication _serverСommunication;

        public bool SendProductToBackApiIsEnabled { get; set; }

        public bool IsCommunicationSuccess { get; set; }

        public ProductBasketViewModel(MessageBus messageBus, EventBus InputEventBus, ServerСommunication InputserverСommunication)
        {
            BindingOperations.EnableCollectionSynchronization(ProductsOnBasket, ObservableCollectionLocker);

            _serverСommunication = InputserverСommunication;

            _messageBus = messageBus;

            _eventBus = InputEventBus;

            SalesSystems.Add(new SellSystem() { id = 1, Name = "Talabat" });
            SalesSystems.Add(new SellSystem() { id = 2, Name = "Zamato" });
            SalesSystems.Add(new SellSystem() { id = 3, Name = "Uber" });

            _messageBus.Receive<ProductModelMessage>(this, async InputProduct =>
            {
                await Task.Run(() =>
                {
                    lock (ObservableCollectionLocker) ProductsOnBasket.Add(InputProduct.Product);
                });

            });

            if (ProductsOnBasket == null)
            {
                SendProductToBackApiIsEnabled = false;
            }
            else SendProductToBackApiIsEnabled = true;

        }

        public ICommand RemoveItem => new DelegateCommand<Product>((product) =>
        {
            ProductsOnBasket.Remove(product);

        }, (product) => product != null); // Кнопка для удаления заказа

        public ICommand SendProductToBackApi => new DelegateCommand(async() =>
        {
            Order order = new Order()
            {
                OrderNumber = DateTime.Now.Second,

                Products = new List<Product>(ProductsOnBasket)

            };

            string JsonOrder = JsonConvert.SerializeObject(order);

            switch (SelectedSalesSystem.Name)
            {
                case ("Talabat"): await _serverСommunication.SendToTalabatController(JsonOrder); break;
                case ("Zamato"): await _serverСommunication.SendToZomatoController(JsonOrder); break;
                case ("Uber"): await _serverСommunication.SendToUberController(JsonOrder); break;
            }

            ProductsOnBasket = new ObservableCollection<Product>();

            await _eventBus.Publish(new CommunicationSuccess());

        });



    }     
    
}
