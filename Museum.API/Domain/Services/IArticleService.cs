using MuseumAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> ListAsync();

        Task<Article> ListByIdAsync(int id);
    }
}
