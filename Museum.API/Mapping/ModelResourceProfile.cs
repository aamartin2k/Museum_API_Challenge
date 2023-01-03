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

        }
    }
}
