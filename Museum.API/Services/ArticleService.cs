using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;
using MuseumAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuseumAPI.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;


        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<Article>> ListAsync()
        {
            return await _articleRepository.ListAsync();
        }

        public async Task<Article> ListByIdAsync(int id)
        {
            return await _articleRepository.ListByIdAsync(id);
        }
    }
}
