using Microsoft.EntityFrameworkCore;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Repositories;
using MuseumAPI.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuseumAPI.Persistence.Repositories
{
    public class MuseumRepository : BaseRepository, IMuseumRepository
    {
        public MuseumRepository(AppDbContext context) : base(context) { }



        public async Task<IEnumerable<Museum>> ListAsync()
        {
            return await _context.Museums.ToListAsync();
        }

        public async Task<Museum> ListByIdAsync(int id)
        {
            return await _context.Museums.FindAsync(id);
        }
    }
}
