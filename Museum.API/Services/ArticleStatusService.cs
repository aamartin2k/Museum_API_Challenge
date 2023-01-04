using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Repositories;
using MuseumAPI.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuseumAPI.Services
{
    public class ArticleStatusService : IArticleStatusService
    {
        private readonly IArticleStatusRepository _articleStatusRepository;

        public ArticleStatusService(IArticleStatusRepository articleStatus)
        {
            _articleStatusRepository = articleStatus;
        }

        public async Task<IEnumerable<ArticleStatus>> ListAsync()
        {
            return await _articleStatusRepository.ListAsync();
        }
    }
}
