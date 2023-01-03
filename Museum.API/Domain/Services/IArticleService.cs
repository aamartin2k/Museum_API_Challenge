using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> ListAsync();
        Task<Article> ListByIdAsync(int id);

        Task<IEnumerable<Article>> ListByMuseumIdAsync(int id);


        Task<ArticleResponse> SaveAsync(Article article);
        Task<ArticleResponse> UpdateAsync(int id, Article article);
        Task<ArticleResponse> DeleteAsync(int id);
    }
}
