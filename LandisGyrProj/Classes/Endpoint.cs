using LandisGyrProj.Enums;

namespace LandisGyrProj.Classes
{
    public class Endpoint
    {
        public string endpointSerialNumber { get; set; }
        public MeterModel meterModelId { get; set; }
        public int meterNumber { get; set; }
        public string meterFirmwareVersion { get; set; }
        public State switchState { get; set; }

        public Endpoint()
        {
            endpointSerialNumber = string.Empty;
            meterModelId = 0;
            meterNumber = 0;
            meterFirmwareVersion = string.Empty;
            switchState = 0;
        }
    }
}
