using AutoMapper;
using MuseumAPI.Domain.Models;
using MuseumAPI.Mapping.Resolvers;
using MuseumAPI.Mapping.Resources;

namespace MuseumAPI.Mapping
{
    public class ModelResourceProfile : Profile
    {
        public ModelResourceProfile()
        {
            CreateMap<Museum, MuseumResource>();
            //CreateMap<Article, ArticleResource>();

            CreateMap<Article, ArticleResource>()
                .ForMember(dest => dest.StatusDescription,
                opt => opt.MapFrom<StatusDescriptionResolver>());

        }
    }

}

