using MuseumAPI.Mapping.Resources;
using System.Collections.Generic;

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
