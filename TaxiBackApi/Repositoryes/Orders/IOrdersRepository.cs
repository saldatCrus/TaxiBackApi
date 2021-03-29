using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;

namespace TaxiBackApi.Repositoryes.Orders
{
    /// <summary>
    /// Interface for implimentation metods of order
    /// </summary>
    public interface IOrdersRepository
    {
        Task<IEnumerable<PackagedOrder>> Get();

        Task<PackagedOrder> Get(int id);

        Task<PackagedOrder> GetRawOrder();

        Task Create(PackagedOrder order);

        void Update(PackagedOrder order);

        Task Delete(int id);

    }
}
