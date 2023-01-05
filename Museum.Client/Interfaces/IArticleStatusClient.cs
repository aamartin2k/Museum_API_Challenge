using MuseumAPI.Mapping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client.Interfaces
{
    interface IArticleStatusClient
    {
        List<ArticleStatusResource> Get();
        void Create(ArticleStatusResource resource);
        void Update(int id, ArticleStatusResource resource);
        void Delete(int id);
    }
}
