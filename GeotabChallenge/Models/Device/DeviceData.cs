using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeotabChallenge.Models.Device
{
    public class DeviceData
    {
        public string vehicleIdentificationNumber { get; set; }
        public string engineVehicleIdentificationNumber { get; set; }
        public int odometerFactor { get; set; }
        public int odometerOffset { get; set; }
        public int engineHourOffset { get; set; }
        public string licensePlate { get; set; }
        public string licenseState { get; set; }
        public bool pinDevice { get; set; }
        public List<object> autoGroups { get; set; }
        public DateTime activeFrom { get; set; }
        public DateTime activeTo { get; set; }
        public string comment { get; set; }
        public List<Group> groups { get; set; }
        public string timeZoneId { get; set; }
        public string deviceType { get; set; }
        public string id { get; set; }
        public DateTime ignoreDownloadsUntil { get; set; }
        public int maxSecondsBetweenLogs { get; set; }
        public string name { get; set; }
        public int productId { get; set; }
        public string timeToDownload { get; set; }
        public string workTime { get; set; }
        public List<object> customProperties { get; set; }
        public List<object> mediaFiles { get; set; }
        public bool? isContinuousConnectEnabled { get; set; }
        public bool? obdAlertEnabled { get; set; }
        public List<int> auxWarningSpeed { get; set; }
        public List<bool> enableAuxWarning { get; set; }
        public bool? enableControlExternalRelay { get; set; }
        public int? externalDeviceShutDownDelay { get; set; }
        public int? immobilizeArming { get; set; }
        public bool? immobilizeUnit { get; set; }
        public List<bool> isAuxIgnTrigger { get; set; }
        public List<bool> isAuxInverted { get; set; }
        public int? accelerationWarningThreshold { get; set; }
        public int? accelerometerThresholdWarningFactor { get; set; }
        public int? brakingWarningThreshold { get; set; }
        public int? corneringWarningThreshold { get; set; }
        public bool? enableBeepOnDangerousDriving { get; set; }
        public bool? enableBeepOnRpm { get; set; }
        public bool? isActiveTrackingEnabled { get; set; }
        public bool? isDriverSeatbeltWarningOn { get; set; }
        public bool? isPassengerSeatbeltWarningOn { get; set; }
        public bool? isReverseDetectOn { get; set; }
        public bool? isIoxConnectionEnabled { get; set; }
        public int? rpmValue { get; set; }
        public int? seatbeltWarningSpeed { get; set; }
        public bool? disableBuzzer { get; set; }
        public bool? enableBeepOnIdle { get; set; }
        public bool? enableSpeedWarning { get; set; }
        public string engineType { get; set; }
        public int? idleMinutes { get; set; }
        public bool? isSpeedIndicator { get; set; }
        public int? minAccidentSpeed { get; set; }
        public int? speedingOff { get; set; }
        public int? speedingOn { get; set; }
        public string goTalkLanguage { get; set; }
        public int? fuelTankCapacity { get; set; }
        public List<object> customParameters { get; set; }
        public bool? enableMustReprogram { get; set; }
        public bool? ensureHotStart { get; set; }
        public int? gpsOffDelay { get; set; }
        public int? major { get; set; }
        public int? minor { get; set; }
        public int? parameterVersion { get; set; }
        public int? parameterVersionOnDevice { get; set; }
        public DeviceFlags deviceFlags { get; set; }
        public string serialNumber { get; set; }
        public List<string> devicePlans { get; set; }
        public List<DevicePlanBillingInfo> devicePlanBillingInfo { get; set; }
    }
}
