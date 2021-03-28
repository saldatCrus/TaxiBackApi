using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;

namespace TaxiBackApi.Repositoryes
{
    public  interface IOrdersRepository
    {
        Task<IEnumerable<Order>> Get();

        Task<Order> Get(int id);

        Task<Order> GetRawOrder();

        Task Create(Order order);

        Task Update(Order order);

        Task Delete(int id);

    }
}
