using GeotabChallenge.ExternalServices;
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

        public VehiclesService(IGeotabService geotabService)
        {
            _geotabService = geotabService;
        }
        public async Task GetVehicles()
        {
            var data = await _geotabService.GetVehicles();
            Console.WriteLine("data: " + data);
        }
    }
}
