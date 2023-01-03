using MuseumAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Services
{
    public interface IMuseumThemeService
    {
        Task<IEnumerable<MuseumTheme>> ListAsync();
    }
}
