using MuseumAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> ListAsync();
        Task<Article> ListByIdAsync(int id);

        Task<IEnumerable<Article>> ListByMuseumIdAsync(int id);

        Task AddAsync(Article article);
        void Update(Article article);
        void Remove(Article article); 
    }
}
