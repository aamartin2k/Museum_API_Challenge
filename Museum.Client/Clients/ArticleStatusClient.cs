using Museum.Client.Interfaces;
using MuseumAPI.Mapping.Resources;
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

        public List<ArticleStatusResource> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ArticleStatusResource resource)
        {
            throw new NotImplementedException();
        }
    }
}
