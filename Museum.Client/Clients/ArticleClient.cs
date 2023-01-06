using Museum.Client.Interfaces;
using MuseumAPI.Mapping.Resources;
using RestSharp;
using System.Collections.Generic;

namespace Museum.Client.Clients
{
    class ArticleClient : BaseClient, IArticleClient
    {
       
        public ArticleClient(IRestClient client, string resource) : base(client, resource) { }



        // Create
        public void Create(NewArticleResource resource)
        {
            var request = new RestRequest(_resource, Method.POST);
            request.AddJsonBody(resource);
            _client.Execute(request);
        }

        // Read All
        public List<ArticleResource> Get()
        {
            var request = new RestRequest(_resource, Method.GET);
            var response = _client.Execute<List<ArticleResource>>(request);
            return response.Data;
        }
        // Read by ID
        public ArticleResource ListById(int id)
        {
            var request = new RestRequest(_resource + id, Method.GET);
            var response = _client.Execute<ArticleResource>(request);
            return response.Data;
        }
        // Read by Museum ID
        public List<ArticleResource> ListByMuseumID(int id)
        {
            var request = new RestRequest(_resource + "Museum/" + id, Method.GET);
            var response = _client.Execute<List<ArticleResource>>(request);
            return response.Data;
        }

        // Update
        public void Update(int id, ArticleResource resource)
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
