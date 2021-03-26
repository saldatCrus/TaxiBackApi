using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi;
using TaxiBackApi.Models;

namespace TaxiBackApi.EntitySupportClass
{
    public class DataBaseControls
    {
        public ApplicationDBContext dBContext{get;set;}

        public List<Order> GetOrders()
        {
            return dBContext.Orders.ToList();
        }

        public void CreateOrderOnDB(object order, string OrderType)
        {
            var NewRawOrder = new Order();

            NewRawOrder.OrderId = 0;

            NewRawOrder.OrderType = OrderType;

            NewRawOrder.OrderNumber = 0;

            NewRawOrder.JsonOrder = order.ToString();

            NewRawOrder.DateTime = DateTime.Now;

            dBContext.Orders.Add(NewRawOrder);

            dBContext.SaveChangesAsync();   
        }

        public void EditOrder(Order order)
        {
            dBContext.Orders.Update(order);

            dBContext.SaveChanges();           
        }

        public Order FindRawOrder() 
        {
            Order RawOrder = dBContext.Orders.FirstOrDefault(x => x.ConvertedJsonOrder == null);

            if (RawOrder != null) return RawOrder;
            else return null;
        } 
    }
}
