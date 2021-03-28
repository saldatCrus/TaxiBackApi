using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;
using TaxiBackApi.Data;
using Microsoft.EntityFrameworkCore;

namespace TaxiBackApi.Repositoryes
{
    public class OrderRepository : IOrdersRepository
    {
        private readonly AppDbContext Context;

        public OrderRepository(AppDbContext IncomingContext) 
        {
            this.Context = IncomingContext;
        }

        public async Task Create(Order order)
        {
            Context.Orders.Add(order);

            await Context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var OrderToDelate = await Context.Orders.FindAsync(id);

            Context.Orders.Remove(OrderToDelate);

            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await Context.Orders.ToListAsync();
        }

        public async Task<Order> Get(int id)
        {
            return await Context.Orders.FindAsync(id);
        }

        public async Task<Order> GetRawOrder() 
        {
            return await Context.Orders.FirstOrDefaultAsync(p => p.ConvertedJsonOrder == null);
        }
            
        public async Task Update(Order order)
        {
            Context.Entry(order).State = EntityState.Modified;

            await Context.SaveChangesAsync();
        }
    }
}
