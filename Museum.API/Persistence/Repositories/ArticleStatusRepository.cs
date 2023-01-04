using Microsoft.EntityFrameworkCore;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Repositories;
using MuseumAPI.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuseumAPI.Persistence.Repositories
{
    public class ArticleStatusRepository : BaseRepository, IArticleStatusRepository
    {
        public ArticleStatusRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<ArticleStatus>> ListAsync()
        {
            return await _context.Status.ToListAsync();
        }

        public async Task<ArticleStatus> ListByIdAsync(int id)
        {
            return await _context.Status.FindAsync(id);
        }
    }
}
