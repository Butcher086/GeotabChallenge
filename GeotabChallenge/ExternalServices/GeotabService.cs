using GeotabChallenge.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geotab.Checkmate;
using Geotab.Checkmate.ObjectModel;

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

        public async Task<string> GetVehicles()
        {
            var vehicles = await _api.CallAsync<object>("Get", typeof(Device));
            Console.WriteLine("vehicles: " + vehicles);
            return vehicles.ToString();
        }
    }
}
