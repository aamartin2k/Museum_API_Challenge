using Microsoft.EntityFrameworkCore;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Repositories;
using MuseumAPI.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Museum>> ListByThemeIdAsync(int id)
        {
            return await _context.Museums.Where(a => a.ThemeId == id).ToListAsync();
        }

        public async Task AddAsync(Museum museum)
        {
            await _context.Museums.AddAsync(museum);
        }
        public void Remove(Museum museum)
        {
            _context.Museums.Remove(museum);
        }

        public void Update(Museum museum)
        {
            _context.Museums.Update(museum);
        }

       
    }
}
