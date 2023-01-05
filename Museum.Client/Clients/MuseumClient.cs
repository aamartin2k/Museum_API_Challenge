using Museum.Client.Interfaces;
using MuseumAPI.Mapping.Resources;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client.Clients
{
    class MuseumClient : BaseClient, IMuseumClient
    {
        public MuseumClient(string baseUrl, string resource) : base(baseUrl, resource) { }

        // Create
        public void Create(NewMuseumResource resource)
        {
            var request = new RestRequest(_resource, Method.POST);
            request.AddJsonBody(resource);
            _client.Execute(request);
        }

        // Read All
        public List<MuseumResource> Get()
        {
            var request = new RestRequest(_resource, Method.GET);
            var response = _client.Execute<List<MuseumResource>>(request);
            return response.Data;
        }
        // Read by ID
        public MuseumResource ListById(int id)
        {
            var request = new RestRequest(_resource + id, Method.GET);
            var response = _client.Execute<MuseumResource>(request);
            return response.Data;
        }
        // Read by Theme ID
        // api/Museums/Themes/100
        public List<MuseumResource> ListByThemeID(int id)
        {      
            var request = new RestRequest(_resource + "Themes/" + id, Method.GET);
            var response = _client.Execute<List<MuseumResource>>(request);
            return response.Data;
        }



        // Update
        public void Update(int id, MuseumResource resource)
        {
            var request = new RestRequest(_resource + id, Method.PUT);
            request.AddJsonBody(resource);
            _client.Execute(request);
        }

        // Delete
        public void Delete(int id)
        {
            var request = new RestRequest(_resource + id, Method.DELETE);
            _client.Execute(request);
        }

       

       
    }
}
