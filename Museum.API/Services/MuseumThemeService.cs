using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Repositories;
using MuseumAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Services
{
    public class MuseumThemeService : IMuseumThemeService
    {
        private readonly IMuseumThemeRepository _museumThemeRepository;


        public MuseumThemeService(IMuseumThemeRepository museumRepository)
        {
            _museumThemeRepository = museumRepository;
        }


        public async Task<IEnumerable<MuseumTheme>> ListAsync()
        {
            return await _museumThemeRepository.ListAsync();
        }
    }
}
