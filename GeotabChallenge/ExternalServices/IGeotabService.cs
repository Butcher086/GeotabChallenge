using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.ExternalServices
{
    public interface IGeotabService
    {
        Task<string> GetVehicles();
    }
}
