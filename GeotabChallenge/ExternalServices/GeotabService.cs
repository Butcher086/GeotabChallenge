using GeotabChallenge.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.ExternalServices
{
    public class GeotabService : IGeotabService
    {
        private readonly GeotabSettings _settings;

        public GeotabService(IOptions<GeotabSettings> settings)
        {
            _settings = settings.Value;            
        }

        public Task<string> GetVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
