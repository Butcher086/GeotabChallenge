using GeotabChallenge.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geotab.Checkmate;
using Geotab.Checkmate.ObjectModel;
using Newtonsoft.Json;
using GeotabChallenge.Models.Device;
using GeotabChallenge.Models.Vehicle;

namespace GeotabChallenge.ExternalServices
{
    public class GeotabService : IGeotabService
    {
        private readonly GeotabSettings _settings;
        private readonly API _api;

        public GeotabService(IOptions<GeotabSettings> settings)
        {
            _settings = settings.Value;
            _api = new API(_settings.User, _settings.Pass, null, _settings.Database, _settings.Server);
            InitializeAsync().Wait();
        }

        private async Task InitializeAsync()
        {
            try
            {
                await _api.AuthenticateAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error during API authentication.", ex);
            }            
        }

        public async Task<IEnumerable<DeviceData>> GetDevices()
        {
            var response = await _api.CallAsync<object>("Get", typeof(Device));  
            var devices = JsonConvert.DeserializeObject<List<DeviceData>>(response.ToString());            

            return devices;
        }  
        
        public async Task<IEnumerable<VehicleData>> GetVehicles(IEnumerable<DeviceData> devices)
        {
            var vehicles = new List<VehicleData>();

            foreach (var device in devices)
            {
                vehicles.Add(new VehicleData
                {
                    Id = device.vehicleIdentificationNumber,
                    TimeStamp = device.workTime,
                    VIN = device.vehicleIdentificationNumber,
                    Coordinates = device.timeZoneId,
                    Odometer = device.odometerFactor.ToString(),
                    LicensePlate = device.licensePlate
                });

            }
            return vehicles;
        }
    }
}
