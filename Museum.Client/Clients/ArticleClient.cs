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
    class ArticleClient : BaseClient, IArticleClient
    {
        public ArticleClient(string baseUrl, string resource) : base(baseUrl,  resource) { }

        public void Create(ArticleResource resource)
        {
            var request = new RestRequest(_resource, Method.POST);
            request.AddJsonBody(resource);
            _client.Execute(request);
        }

        public void Delete(int id)
        {
            var request = new RestRequest(_resource + id, Method.DELETE);
            _client.Execute(request);
        }

        public List<ArticleResource> Get()
        {
            var request = new RestRequest(_resource, Method.GET);
            var response = _client.Execute<List<ArticleResource>>(request);
            return response.Data;
        }

        public void Update(int id, ArticleResource resource)
        {
            var request = new RestRequest(_resource + id, Method.PUT);
            request.AddJsonBody(resource);
            _client.Execute(request);
        }
    }
}
