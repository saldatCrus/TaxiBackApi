using DevExpress.Mvvm;
using ProductManagerApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagerApplication.Events;
using ProductManagerApplication.Messages;
using ProductManagerApplication.Models;

namespace ProductManagerApplication.ViewModels.ProductAddViewModels
{
    class ProductChangeViewModel : BindableBase
    {
        private readonly MessageBus _messageBus;

        private readonly EventBus _eventBus;

        public string ProductName { get; set; }

        public string ProductComment { get; set; }

        public int ProductQuantity { get; set; }

        public double PaidPrice { get; set; }

        public int ProductUnitPrice {get;set;}

        public string ProductRemoteCode { get; set; }

        public string ProductDescription { get; set; }

        public string ProductVatPercentage { get; set; }

        public string ProductDiscountAmount { get; set; }

        public ProductChangeViewModel(MessageBus messageBus, EventBus InputEventBus) 
        {
            _messageBus = messageBus;

            _eventBus = InputEventBus;

            Random RandomNuberId = new Random();

            _eventBus.Subscribe<AddProductOnBasket>(async @event => 
            {
                if (ProductName != null && ProductComment != null && ProductRemoteCode != null && ProductDescription !=null && ProductVatPercentage != null && ProductDiscountAmount != null) 
                {
                    await _messageBus.SendTo<ProductBasketViewModel>(new ProductModelMessage(new Product()
                    {
                        id = RandomNuberId.Next(0, 100000),

                        name = ProductName,

                        comment = ProductComment,

                        quantity = ProductQuantity,

                        paidPrice = PaidPrice,

                        unitPrice = ProductUnitPrice,

                        remoteCode = ProductRemoteCode,

                        description = ProductDescription,

                        vatPercentage = ProductVatPercentage,

                        discountAmount = ProductDiscountAmount

                    }));
                }
               
            });
        }

    }
}
