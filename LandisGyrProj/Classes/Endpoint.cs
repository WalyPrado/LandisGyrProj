using LandisGyrProj.Enums;

namespace LandisGyrProj.Classes
{
    public class Endpoint
    {
        public string endpointSerialNumber { get; set; }
        public int meterModelId { get; set; }
        public int meterNumber { get; set; }
        public int meterFirmwareVersion { get; set; }
        public State switchState { get; set; }

        public Endpoint()
        {
            endpointSerialNumber = string.Empty;
            meterModelId = 0;
            meterNumber = 0;
            meterFirmwareVersion = 0;
            switchState = 0;
        }
    }
}
