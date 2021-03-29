using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;
using TaxiBackApi.Data;
using Microsoft.EntityFrameworkCore;

namespace TaxiBackApi.Repositoryes.Orders
{
    public class OrderRepository : IOrdersRepository
    {
        private readonly AppDbContext Context;

        public OrderRepository(AppDbContext IncomingContext) 
        {
            this.Context = IncomingContext;
        }

        /// <summary>
        /// This method Add element of Order on DataBase
        /// </summary>
        public async Task Create(PackagedOrder order)
        {
            Context.PackageOrders.Add(order);

            await Context.SaveChangesAsync();

        }

        /// <summary>
        /// This method Delete element of order from DataBase
        /// </summary>
        public async Task Delete(int id)
        {
            var OrderToDelate = Context.PackageOrders.Find(id);

            Context.PackageOrders.Remove(OrderToDelate);

            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// This method show all elements of order L on DataBase
        /// </summary>
        public async Task<IEnumerable<PackagedOrder>> Get()
        {
            return await Context.PackageOrders.ToListAsync();
        }

        /// <summary>
        /// This method show element of Order on DataBase by his Id 
        /// </summary>
        public async Task<PackagedOrder> Get(int id)
        {
            return await Context.PackageOrders.FindAsync(id);
        }

        /// <summary>
        /// This method show element of Order(Unprocessed) on DataBase by his Id 
        /// </summary>
        public async Task<PackagedOrder> GetRawOrder() 
        {
            return await Context.PackageOrders.FirstOrDefaultAsync(p => p.ConvertedJsonOrder == null);
        }

        /// <summary>
        /// This method change element of Order on DataBase
        /// </summary>
        public void Update(PackagedOrder order)
        {

            Context.Entry(order).State = EntityState.Modified;
            Context.SaveChanges();

        }
    }
}
