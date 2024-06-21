using GeotabChallenge.ExternalServices;
using GeotabChallenge.Models.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.Services
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IGeotabService _geotabService;
        private readonly ICsvWriterService _csvWriterService;

        public VehiclesService(IGeotabService geotabService, ICsvWriterService csvWriterService)
        {
            _geotabService = geotabService;
            _csvWriterService = csvWriterService;
        }
        public async Task GetVehicles()
        {
            //var vechicles = await _geotabService.GetVehicles();
            
        }

        public async Task WriteVehiclesToCsv(IEnumerable<DeviceData> devices)
        {
            var vechicles = await _geotabService.GetVehicles(devices);
            
            foreach (var vehicle in vechicles)
            {
                await _csvWriterService.WriteVehicleToCsvAsync(vehicle);
            }
        }
    }
}
