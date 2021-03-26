using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiBackApi.Models;

namespace TaxiBackApi.EntitySupportClass
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            Database.EnsureCreated(); //Создание базы при первом обращений
        }
    }
}
