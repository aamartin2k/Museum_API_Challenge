using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;
using MuseumAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MuseumAPI.Domain.Services.Responses;

namespace MuseumAPI.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Article>> ListAsync()
        {
            return await _articleRepository.ListAsync();
        }

        public async Task<Article> ListByIdAsync(int id)
        {
            return await _articleRepository.ListByIdAsync(id);
        }

        public async Task<IEnumerable<Article>> ListByMuseumIdAsync(int id)
        {
            return await _articleRepository.ListByMuseumIdAsync(id);
        }



        public Task<ArticleResponse> SaveAsync(Article article)
        {
            throw new NotImplementedException();
        }

        
        public async Task<ArticleResponse> UpdateAsync(int id, Article article)
        {
            var existingArticle = await _articleRepository.ListByIdAsync(id);

            if (existingArticle == null)
                return new ArticleResponse("Article not found.");

            existingArticle.Name = article.Name;
            existingArticle.StatusId = article.StatusId;
            existingArticle.MuseumId = article.MuseumId;

            try
            {
                _articleRepository.Update(existingArticle);
                await _unitOfWork.SaveChangesCompleteAsync();

                return new ArticleResponse(existingArticle);
            }
            catch (Exception ex)
            {
                // Place for do logging
                return new ArticleResponse($"Exception occurred updating the article: {ex.Message}");
            }
        }


        public async Task<ArticleResponse> DeleteAsync(int id)
        {
            var existingArticle = await _articleRepository.ListByIdAsync(id);

            if (existingArticle == null)
                return new ArticleResponse("Article not found.");

            try
            {
                _articleRepository.Remove(existingArticle);
                await _unitOfWork.SaveChangesCompleteAsync();

                return new ArticleResponse(existingArticle);
            }
            catch (Exception ex)
            {
                // Place for do logging
                return new ArticleResponse($"Exception occurred deleting the article: {ex.Message}");
            }
        }
    }
}
