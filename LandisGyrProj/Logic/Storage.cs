using LandisGyrProj.Classes;
using LandisGyrProj.Enums;

namespace LandisGyrProj.Logic
{
    public class Storage
    {
        List<Endpoint> endpoints { get; set; }
        public Storage()
        {
            endpoints = new List<Endpoint>();
        }

        public string Save(Endpoint endpoint)
        {
            try
            {
                endpoints.Add(endpoint);

                return "Endpoint has been saved successfully!";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Edit(Endpoint endpoint, State state)
        {
            try
            {
                var index = endpoints.IndexOf(endpoint);

                endpoints[index].switchState = state;

                return string.Format("The State of endpoint {0} has been altered to {1}!", endpoints[index].endpointSerialNumber, state);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Delete(Endpoint endpoint)
        {
            try
            {
                endpoints.Remove(endpoint);

                return string.Format("The endpoint {0} has been excluded successfully!", endpoint.endpointSerialNumber);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Endpoint> GetAll()
        {
            return endpoints;
        }

        public Endpoint FindBySerial(string serial)
        {
            Endpoint? endpoint = endpoints.FirstOrDefault(x => x.endpointSerialNumber == serial);

            return endpoint ?? new Endpoint();
        }
    }
}
