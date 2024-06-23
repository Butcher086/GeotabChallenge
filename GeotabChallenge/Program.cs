using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using GeotabChallenge.Models;
using GeotabChallenge.ExternalServices;
using GeotabChallenge.Services;

namespace GeotabChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var geotabService = host.Services.GetRequiredService<IGeotabService>();
            var devicesService = host.Services.GetRequiredService<IDevicesService>();
            //var vehiclesService = host.Services.GetRequiredService<IVehiclesService>();
            var csvWriterService = host.Services.GetRequiredService<ICsvWriterService>();            

            //var devices = devicesService.GetDevices().Result;            

            //var vehicles = geotabService.GetVehicles(devices).Result;
            //foreach (var vehicle in vehicles)
            //{
            //    csvWriterService.WriteVehicleToCsvAsync(vehicle).Wait();
            //}
            host.Run();

        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<GeotabSettings>(context.Configuration.GetSection("GeotabSettings"));
                services.AddTransient<IGeotabService, GeotabService>();
                services.AddTransient<IVehiclesService, VehiclesService>();
                services.AddTransient<IDevicesService, DevicesService>();
                services.AddTransient<ICsvWriterService, CsvWriterService>();

                services.AddHostedService<VehicleMonitoringService>();
            });
    }
}
