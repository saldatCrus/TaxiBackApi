using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagerApplication.Pages.ProductAddPages;
using System.Windows.Controls;
using System.Windows.Input;
using ProductManagerApplication.Services;
using ProductManagerApplication.Events;

namespace ProductManagerApplication.ViewModels
{
    class AddProductViewModel : BindableBase
    {
        private readonly EventBus _eventBus;

        public Page MemberProductTrackPage { get; set; }

        public bool AddButtomIsEnable { get; set; }

        public string AddProductStatus { get; set; }

        public AddProductViewModel(NavigationService navigation,EventBus InputEventBus ) 
        {
            navigation.OnPageChanged += page => MemberProductTrackPage = page;
            navigation.Navigate(new ProductChangePage()); //Frame Navigator 

            _eventBus = InputEventBus;

            AddButtomIsEnable = true;

            _eventBus.Subscribe<CommunicationSuccess>(async @event => 
            {
                AddProductStatus = "Заказ успешно создан и отправлен";
            });

        }

        public ICommand AddProductToBasket => new DelegateCommand(async() =>
        {
            await _eventBus.Publish(new AddProductOnBasket());

            AddProductStatus = "Продукт добавлен в каризну";

            MemberProductTrackPage = new ProductChangePage();
        }); // Открытие страницы для редактирования заказа

        public ICommand ShowBasket => new DelegateCommand(() =>
        {
            MemberProductTrackPage = new ProductBasketPage();

            AddButtomIsEnable = false;
        }); //Открытие страницы корзины
    }
}
