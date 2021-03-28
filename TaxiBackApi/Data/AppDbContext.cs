using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaxiBackApi.Models;

namespace TaxiBackApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) 
        {
            
        }

        public DbSet<Order> Orders { get; set; }
    }
}
