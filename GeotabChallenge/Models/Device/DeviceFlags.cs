using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.Models.Device
{
    public class DeviceFlags
    {
        public List<string> activeFeatures { get; set; }
        public bool isActiveTrackingAllowed { get; set; }
        public bool isContinuousConnectAllowed { get; set; }
        public bool isEngineAllowed { get; set; }
        public bool isGarminAllowed { get; set; }
        public bool isHOSAllowed { get; set; }
        public bool isIridiumAllowed { get; set; }
        public bool isOdometerAllowed { get; set; }
        public bool isTripDetailAllowed { get; set; }
        public bool isUIAllowed { get; set; }
        public bool isVINAllowed { get; set; }
        public List<object> ratePlans { get; set; }
    }
}
