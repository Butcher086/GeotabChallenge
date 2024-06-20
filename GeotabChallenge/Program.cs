using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using GeotabChallenge.Models;
using GeotabChallenge.ExternalServices;

namespace GeotabChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
        }

        static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((context, config) =>
        {
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        }).
        ConfigureServices((context, services) =>
        {
            services.Configure<GeotabSettings>(context.Configuration.GetSection("ApiSettings"));
            services.AddSingleton<IGeotabService, GeotabService>();            
        });
    }
}
