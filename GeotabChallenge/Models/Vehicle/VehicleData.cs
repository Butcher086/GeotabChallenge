using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.Models.Vehicle
{
    public class VehicleData
    {
        public string Id { get; set; }
        public string TimeStamp { get; set; }
        public string VIN { get; set; }
        public string Coordinates { get; set; }
        public string Odometer { get; set; }
        public string LicensePlate { get; set; }
    }
}
