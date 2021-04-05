using DevExpress.Mvvm;
using ProductManagerApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ProductManagerApplication.Pages;

namespace ProductManagerApplication.ViewModels
{
    class MainViewModel : BindableBase
    {

        public Page MemberTrackPage { get; set; }



        public MainViewModel(NavigationService navigation) 
        {
            navigation.OnPageChanged += page => MemberTrackPage = page;
            navigation.Navigate(new WellcomePage()); //Frame NAvigator 
        }

        public ICommand WellcomePageButton => new DelegateCommand(() => 
        {
            MemberTrackPage = new WellcomePage();
        }); // Кнопка для перехода на страницу Wellcome

        public ICommand AddProductPageBindingButton => new DelegateCommand(() =>
        {
            MemberTrackPage = new AddProductPage();
        }); //Кнопка для перехода на страницу добавления продуктов

        public ICommand ShowProductPageButton => new DelegateCommand(() =>
        {
            MemberTrackPage = new ShowProductPage();
        }); //Кнопка для перехода на страицу просмотра продуктов

        public ICommand ShowLogPageButton => new DelegateCommand(() =>
        {
            MemberTrackPage = new ShowLogPage();
        }); //Кнопка для перехода на страницу просмотра логов
    }
}
