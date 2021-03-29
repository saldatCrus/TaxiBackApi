using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaxiBackApi.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaxiBackApi.Data;
using TaxiBackApi.Repositoryes.Orders;
using TaxiBackApi.Repositoryes.Logs;
using Microsoft.Extensions.Logging;

namespace TaxiBackApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOrdersRepository, OrderRepository>();

            services.AddScoped<ILogRepository, LogRepository>();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DBaseOrderHandler>();

            services.AddScoped<Loger>();

            services.AddControllers();

            var logger = services.BuildServiceProvider().GetService<ILogger<DBaseOrderHandler>>();
            services.AddSingleton(typeof(ILogger), logger);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            var logger = app.ApplicationServices.CreateScope().ServiceProvider.GetService<ILogger<DBaseOrderHandler>>();                

            using (var scope = app.ApplicationServices.CreateScope())
            {
               AppDbContext dbContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

               IOrdersRepository ordersRepository = new OrderRepository(dbContext);

               ILogRepository logRepository = new LogRepository(dbContext);

               var InitialDbaseOrderHandler = new DBaseOrderHandler(ordersRepository, logRepository, logger);

               InitialDbaseOrderHandler.DBHandlerStart();
            };

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
