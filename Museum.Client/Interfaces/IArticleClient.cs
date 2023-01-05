using MuseumAPI.Mapping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client.Interfaces
{
    interface IArticleClient
    {
        List<ArticleResource> Get();
        void Create(ArticleResource resource);
        void Update(int id, ArticleResource resource);
        void Delete(int id);
    }
}
