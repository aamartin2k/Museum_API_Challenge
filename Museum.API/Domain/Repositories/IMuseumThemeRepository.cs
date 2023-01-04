using MuseumAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Repositories
{
    public interface IMuseumThemeRepository
    {
        Task<IEnumerable<MuseumTheme>> ListAsync();

        Task<MuseumTheme> ListByIdAsync(int id);
    }
}
