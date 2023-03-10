using AutoMapper;
using MuseumAPI.Domain.Models;
using MuseumAPI.Mapping.Resources;

namespace MuseumAPI.Mapping
{
    public class ResourceModelProfile : Profile
    {
      
        public ResourceModelProfile()
        {
            CreateMap<NewMuseumResource, Museum>();

            CreateMap<NewArticleResource, Article>();
        }

    }
}
