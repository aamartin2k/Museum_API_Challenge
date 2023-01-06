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
    class ArticleStatusClient : BaseClient, IArticleStatusClient
    {

        public ArticleStatusClient(string baseUrl, string resource) : base(baseUrl, resource) { }


        public void Create(ArticleStatusResource resource)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        // Read All
        public List<ArticleStatusResource> Get()
        {
            var request = new RestRequest(_resource, Method.GET);
            var response = _client.Execute<List<ArticleStatusResource>>(request);
            return response.Data;
        }

        public void Update(int id, ArticleStatusResource resource)
        {
            throw new NotImplementedException();
        }
    }
}
