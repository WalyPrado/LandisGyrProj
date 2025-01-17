﻿using LandisGyrProj.Classes;
using LandisGyrProj.Enums;

namespace LandisGyrProj.Logic
{
    public class Storage
    {
        private List<Endpoint> endpoints { get; set; }
        public Storage()
        {
            endpoints = new List<Endpoint>();
        }

        protected string Save(Endpoint endpoint)
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

        protected string Edit(Endpoint endpoint, State state)
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

        protected string Delete(Endpoint endpoint)
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

        protected List<Endpoint> GetAll()
        {
            return endpoints;
        }

        protected Endpoint FindBySerial(string serial)
        {
            Endpoint? endpoint = endpoints.FirstOrDefault(x => x.endpointSerialNumber == serial);

            return endpoint ?? new Endpoint();
        }
    }
}
