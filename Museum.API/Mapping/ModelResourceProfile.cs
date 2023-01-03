using AutoMapper;
using MuseumAPI.Domain.Models;
using MuseumAPI.Mapping.Resources;

namespace MuseumAPI.Mapping
{
    public class ModelResourceProfile : Profile
    {
        public ModelResourceProfile()
        {
            CreateMap<Museum, MuseumResource>();
            CreateMap<Article, ArticleResource>(); 

            //CreateMap<Article, ArticleResource>()
            //    .ForMember(src => src.UrlStatus,
            //    opt => opt.MapFrom(src => src.Id));

        }
    }
}
