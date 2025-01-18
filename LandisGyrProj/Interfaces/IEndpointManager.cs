using LandisGyrProj.Classes;

namespace LandisGyrProj.Interfaces
{
    public interface IEndpointManager
    {
        public void SaveEndpoint();
        public void EditEndpoint();
        public void DeleteEndpoint();
        public void FindEndpointBySerial();
        public void ListAllEndpoints();
    }
}
