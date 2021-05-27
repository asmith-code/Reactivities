using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        /// <summary>
        /// Check to see if we have a database and if not - create from migrations 
        /// </summary>
        /// <param name="args"></param>
        public static async Task Main(string[] args) //not really necessary to make async as program is only run once and doesn't need to be scalabe
        {
            var host = CreateHostBuilder(args).Build(); //previously CreateHostBuilder(args).Build().Run();

            using var scope = host.Services.CreateScope(); //using key word says that after the 'Main' function has run the scope variable will be disposed of by the framework
                                                           //scope should host any services we create in this method and be disposed of afterwards

            var services = scope.ServiceProvider;

            try 
            {
                var context = services.GetRequiredService<DataContext>(); //we have already added Data Context as a service in startup.cs - now we use locator pattern to retrieve it 
                await context.Database.MigrateAsync(); //originally Migrate() - changed after 'Main' changed from void to 'async Task'
                await Seed.SeedData(context);

            } catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }

            await host.RunAsync();//make sure to actually run the application! --changed to async from just Run();
        }                                                   

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
