using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagerApplication.ViewModels;
using ProductManagerApplication.Services;
using ProductManagerApplication.ViewModels.ProductAddViewModels;

namespace ProductManagerApplication
{
    class ViewModelLocator
    {
        private static ServiceProvider _provaider;


        public static void Init()
        {
            var services = new ServiceCollection();

            //My ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<WellcomeViewModel>();
            services.AddTransient<AddProductViewModel>();
            services.AddTransient<ShowProductViewModel>();
            services.AddTransient<ShowLogViewModel>();

            services.AddScoped<ProductBasketViewModel>();
            services.AddTransient<ProductChangeViewModel>();


            // My service
            services.AddSingleton<NavigationService>();
            services.AddSingleton<EventBus>();
            services.AddSingleton<MessageBus>();
            services.AddSingleton<ServerСommunication>();

            _provaider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provaider.GetRequiredService(item.ServiceType);
            }
        }

        public MainViewModel MainViewModel => _provaider.GetRequiredService<MainViewModel>();

        public WellcomeViewModel WellcomeViewModel => _provaider.GetRequiredService<WellcomeViewModel>();

        public ShowProductViewModel ShowProductViewModel => _provaider.GetRequiredService<ShowProductViewModel>();

        public AddProductViewModel AddProductViewModel => _provaider.GetRequiredService<AddProductViewModel>();

        public ShowLogViewModel ShowLogViewModel => _provaider.GetRequiredService<ShowLogViewModel>();

        public ProductBasketViewModel ProductBasketViewModel => _provaider.GetRequiredService<ProductBasketViewModel>();

        public ProductChangeViewModel ProductChangeViewModel => _provaider.GetRequiredService<ProductChangeViewModel>();

    }
}
