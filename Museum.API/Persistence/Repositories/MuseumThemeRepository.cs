using Microsoft.EntityFrameworkCore;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Repositories;
using MuseumAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Persistence.Repositories
{
    public class MuseumThemeRepository : BaseRepository, IMuseumThemeRepository
    {
        public MuseumThemeRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<MuseumTheme>> ListAsync()
        {
            return await _context.Themes.ToListAsync();
        }

        public async Task<MuseumTheme> ListByIdAsync(int id)
        {
            return await _context.Themes.FindAsync(id);
        }
    }
}
