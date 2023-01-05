using AutoMapper;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;
using MuseumAPI.Mapping.Resources;

namespace MuseumAPI.Mapping.Resolvers
{
    public class ThemeDescriptionResolver : IValueResolver<Museum, MuseumResource, string>
    {
        private readonly IMuseumThemeService  _museumThemeService;

        public ThemeDescriptionResolver(IMuseumThemeService service)
        {
            _museumThemeService = service;
        }

        public string Resolve(Museum source, MuseumResource destination, string destMember, ResolutionContext context)
        {
            var result = _museumThemeService.ListByIdAsync(source.ThemeId).Result;
            return result.Description;
        }


    }
}
