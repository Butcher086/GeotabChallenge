﻿using GeotabChallenge.Models.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.Services
{
    public interface IVehiclesService
    {
        Task GetVehicles();
        Task WriteVehiclesToCsv(IEnumerable<DeviceData> devices);
    }
}
