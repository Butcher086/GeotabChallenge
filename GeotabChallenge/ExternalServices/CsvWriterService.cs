using GeotabChallenge.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.ExternalServices
{
    public class CsvWriterService : ICsvWriterService
    {
        public async Task WriteVehicleToCsvAsync(VehicleData vehicleData)
        {
            var filepath = Path.Combine("Vehicles", $"{vehicleData.Id}.csv");
            Directory.CreateDirectory(Path.GetDirectoryName(filepath));

            using (var writer = new StreamWriter(filepath))
            {
                await writer.WriteLineAsync("Id,TimeStamp,VIN,Coordinates,Odometer,LicensePlate");
                await writer.WriteLineAsync($"{vehicleData.Id},{vehicleData.TimeStamp},{vehicleData.VIN},{vehicleData.Coordinates},{vehicleData.Odometer},{vehicleData.LicensePlate}");
            }
            Console.WriteLine($"Vehicle data written to {filepath}");
        }
    }
}
