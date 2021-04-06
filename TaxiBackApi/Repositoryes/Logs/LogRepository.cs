using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxiBackApi.Data;
using TaxiBackApi.Models;

namespace TaxiBackApi.Repositoryes.Logs
{
    public class LogRepository : ILogRepository
    {
        private readonly AppDbContext Context;

        public LogRepository(AppDbContext IncomingContext)
        {
            this.Context = IncomingContext;
        }

        /// <summary>
        /// This method Add element of Log on DataBase
        /// </summary>
        public async Task Create(Log InputLog)
        {
            Context.logs.Add(InputLog);

            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// This method Delete element of Log from DataBase
        /// </summary>
        public async Task Delete(int id)
        {
            var OrderToDelate = Context.logs.Find(id);

            Context.logs.Remove(OrderToDelate);

            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// This method show all elements of Log on DataBase
        /// </summary>
        public async Task<IEnumerable<Log>> GetAll()
        {
            return await Context.logs.ToListAsync();
        }

        /// <summary>
        /// This method show element of Log on DataBase by his Id 
        /// </summary>
        public async Task<Log> Get(int id)
        {
            return await Context.logs.FindAsync(id);
        }

        /// <summary>
        /// This method change element of Log on DataBase
        /// </summary>
        public void Update(Log InputLog)
        {
            Context.Entry(InputLog).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
