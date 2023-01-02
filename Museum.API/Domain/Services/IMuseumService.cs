using MuseumAPI.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Services
{
    public interface IMuseumService
    {
        Task<IEnumerable<Museum>> ListAsync();
    }
}
