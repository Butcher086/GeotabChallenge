
using GeotabChallenge.ExternalServices;
using GeotabChallenge.Models.Device;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.Services
{
    public class VehicleMonitoringService : IHostedService, IDisposable
    {
        private readonly ILogger<VehicleMonitoringService> _logger;
        private readonly IGeotabService _geotabService;
        private readonly ICsvWriterService _csvWriterService;
        private Timer _timer;        

        public VehicleMonitoringService(ILogger<VehicleMonitoringService> logger, IGeotabService geotabService, ICsvWriterService csvWriterService)
        {
            _geotabService = geotabService;
            _logger = logger;            
            _csvWriterService = csvWriterService;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Vehicle Monitoring Service is starting.");
            _timer = new Timer(async state => await CheckVehicles(await _geotabService.GetDevices()), null, TimeSpan.Zero , TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        private async Task CheckVehicles(IEnumerable<DeviceData> devices)
        {
            _logger.LogInformation("Checking vehicles...");
            try
            {
                var vehicles = await _geotabService.GetVehicles(devices);
                foreach (var vehicle in vehicles)
                {
                    await _csvWriterService.WriteVehicleToCsvAsync(vehicle);

                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error checking vehicles.");
            }            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Vehicle Monitoring Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
