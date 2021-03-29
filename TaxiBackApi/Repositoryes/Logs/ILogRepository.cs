using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;

namespace TaxiBackApi.Repositoryes.Logs
{
    /// <summary>
    /// Interface for implimentation metods of log
    /// </summary>
    public interface ILogRepository
    {
        Task<IEnumerable<Log>> Get();

        Task<Log> Get(int id);

        Task Create(Log order);

        void Update(Log order);

        Task Delete(int id);
    }
}
