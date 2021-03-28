using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Create(Log order)
        {
            
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Log>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Log> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async void Update(Log order)
        {
            throw new NotImplementedException();
        }
    }
}
