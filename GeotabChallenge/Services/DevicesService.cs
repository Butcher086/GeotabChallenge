using GeotabChallenge.ExternalServices;
using GeotabChallenge.Models.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.Services
{
    internal class DevicesService : IDevicesService
    {
        private readonly IGeotabService _geotabService;
        public DevicesService(IGeotabService geotabService)
        {
            _geotabService = geotabService;
        }

        public async Task<IEnumerable<DeviceData>> GetDevices()
        {
            var data = await _geotabService.GetDevices();
            return data;
        }
    }
}
