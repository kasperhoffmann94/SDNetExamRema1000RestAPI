using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rema1000RestAPI.Persistency;

namespace Rema1000RestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            SetupDbContext(host);

            host.Start();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static void SetupDbContext(IHost host)
        {
            IServiceScope scope = host.Services.CreateScope();

            IServiceProvider services = scope.ServiceProvider;

            try
            {
                SetupDatabaseContext(services.GetRequiredService<DBContext>());
            }
            catch (Exception exception)
            {
                LogException(exception, services.GetRequiredService<ILogger<Program>>());
            }
        }

        private static void SetupDatabaseContext(DBContext databaseContext)
        {
            databaseContext.Database.Migrate();
            databaseContext.Database.EnsureCreated();
            //TestData.Seed(databaseContext);
        }


        private static void LogException(Exception exception, ILogger logger)
        {
            logger.LogError(exception, "An error occurred creating the DB");
            Console.WriteLine(exception.ToString());
        }
    }
}
