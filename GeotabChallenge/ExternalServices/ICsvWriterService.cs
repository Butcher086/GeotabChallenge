using GeotabChallenge.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.ExternalServices
{
    public interface ICsvWriterService
    {
        Task WriteVehicleToCsvAsync(VehicleData vehicleData);
    }
}
