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
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context) { }

   
        public async Task<IEnumerable<Article>> ListAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> ListByIdAsync(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        // Returns all Articles in the Museum by id
        public async Task<IEnumerable<Article>> ListByMuseumIdAsync(int id)
        {
            return await _context.Articles.Where(a => a.MuseumId == id).ToListAsync();
        }


        public async Task AddAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
        }

        public void Remove(Article article)
        {
            _context.Articles.Remove(article);
        }

        public void Update(Article article)
        {
            _context.Articles.Update(article);
        }
    }
}
