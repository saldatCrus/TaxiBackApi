using Microsoft.EntityFrameworkCore;
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
