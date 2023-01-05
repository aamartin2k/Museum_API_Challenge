using AutoMapper;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;
using MuseumAPI.Mapping.Resources;

namespace MuseumAPI.Mapping.Resolvers
{
    public class StatusDescriptionResolver : IValueResolver<Article, ArticleResource, string>
    {
        private readonly IArticleStatusService _articleStatusService;

        public StatusDescriptionResolver(IArticleStatusService service)
        {
            _articleStatusService = service;
        }

        public string Resolve(Article source, ArticleResource destination, string destMember, ResolutionContext context)
        {
            var result = _articleStatusService.ListByIdAsync(source.StatusId).Result;
            return result.Description;
        }
    }
}
