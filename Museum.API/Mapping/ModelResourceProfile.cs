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
            CreateMap<Article, ArticleResource>()
                .ForMember(dest => dest.StatusDescription,
                opt => opt.MapFrom<StatusDescriptionResolver>());

            CreateMap<Museum, MuseumResource>()
                .ForMember(dest => dest.ThemeDescription,
                    opt => opt.MapFrom<ThemeDescriptionResolver>())
                .ForMember(dest => dest.UrlArticles,
                    opt => opt.MapFrom(s => "/api/Articles/Museum/" + s.Id));
                // Hardcoded IS Bad. Just to demonstrate a very simple use of HATEOAS.

            CreateMap<ArticleStatus, ArticleStatusResource>();
            CreateMap<MuseumTheme, MuseumThemeResource>();

        }
    }

}

