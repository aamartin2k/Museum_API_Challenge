using MuseumAPI.Mapping.Resources;
using System.Collections.Generic;

namespace Museum.Client.Interfaces
{
    interface IArticleClient
    {
        List<ArticleResource> Get();
        void Create(NewArticleResource resource);
        void Update(int id, ArticleResource resource);
        void Delete(int id);

        ArticleResource ListById(int id);
        List<ArticleResource> ListByMuseumID(int id);
    };
}
