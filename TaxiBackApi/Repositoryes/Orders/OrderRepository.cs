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

        public async Task Create(PackagedOrder order)
        {
            Context.PackageOrders.Add(order);

            await Context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var OrderToDelate = Context.PackageOrders.Find(id);

            Context.PackageOrders.Remove(OrderToDelate);

            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PackagedOrder>> Get()
        {
            return await Context.PackageOrders.ToListAsync();
        }

        public async Task<PackagedOrder> Get(int id)
        {
            return await Context.PackageOrders.FindAsync(id);
        }

        public async Task<PackagedOrder> GetRawOrder() 
        {
            return await Context.PackageOrders.FirstOrDefaultAsync(p => p.ConvertedJsonOrder == null);
        }
            
        public void Update(PackagedOrder order)
        {

            Context.Entry(order).State = EntityState.Modified;
            Context.SaveChanges();

        }
    }
}
