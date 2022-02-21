using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageInNET5
{
    public class Program
    {
        //Schritt 1: Aufruf der Main-Methode
        public static void Main(string[] args)
        {

            //Schritt 4 -> Build
            //Danach public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            //Schritt 5 -> Run
            CreateHostBuilder(args).Build().Run();
        }


        //Schritt 2: Aufruf der Hilfs-Methode
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //Schritt3: Startup -> ConfigureServices(IServiceCollection collection)
                });
    }
}
