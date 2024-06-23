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

            var newEntry = $"{vehicleData.Id},{vehicleData.TimeStamp},{vehicleData.VIN},{vehicleData.Coordinates},{vehicleData.Odometer},{vehicleData.LicensePlate}";
            if (File.Exists(filepath))
            {
                var existingEntries = await File.ReadAllLinesAsync(filepath);
                if (existingEntries.Contains(newEntry))
                {
                    using (var writer = new StreamWriter(filepath, append:true))
                    {
                        await writer.WriteLineAsync(newEntry);
                    }
                    Console.WriteLine($"Vehicle data for {vehicleData.Id} updated.");
                }
            }
            else
            {
                using (var writer = new StreamWriter(filepath))
                {
                    await writer.WriteLineAsync("Id,TimeStamp,VIN,Coordinates,Odometer,LicensePlate");
                    await writer.WriteLineAsync(newEntry);
                }
                Console.WriteLine($"Vehicle data file for {vehicleData.Id} created.");
            }            
        }
    }
}
