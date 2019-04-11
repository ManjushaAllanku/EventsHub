using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EventCatalaogApi.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventCatalaogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host=  CreateWebHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                var Services = scope.ServiceProvider;
                var context = Services.GetRequiredService<EventCatalogContext>();
                EventCatalogSeed.EventSeed(context);
            }
                host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
