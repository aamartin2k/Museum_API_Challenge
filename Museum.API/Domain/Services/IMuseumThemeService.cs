using MuseumAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Services
{
    public interface IMuseumThemeService
    {
        Task<IEnumerable<MuseumTheme>> ListAsync();

        Task<MuseumTheme> ListByIdAsync(int id);
    }
}
