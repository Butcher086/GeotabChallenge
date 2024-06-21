using GeotabChallenge.Models.Device;
using GeotabChallenge.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.ExternalServices
{
    public interface IGeotabService
    {
        Task<IEnumerable<DeviceData>> GetDevices();        
        Task<IEnumerable<VehicleData>> GetVehicles(IEnumerable<DeviceData> devices);
    }
}
