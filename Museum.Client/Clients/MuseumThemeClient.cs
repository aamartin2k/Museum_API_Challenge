using Museum.Client.Interfaces;
using MuseumAPI.Mapping.Resources;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Museum.Client.Clients
{
    class MuseumThemeClient : BaseClient, IMuseumThemeClient
    {

        public MuseumThemeClient(IRestClient client, string resource) : base(client, resource) { }


        public void Create(MuseumThemeResource resource)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        // Read All
        public List<MuseumThemeResource> Get()
        {
            var request = new RestRequest(_resource, Method.GET);
            var response = _client.Execute<List<MuseumThemeResource>>(request);
            return response.Data;
        }

        public void Update(int id, MuseumThemeResource resource)
        {
            throw new NotImplementedException();
        }
    }
}
