using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;
using MuseumAPI.Mapping.Resources;

namespace MuseumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuseumThemeController : ControllerBase
    {
        private readonly IMuseumThemeService _museumThemeService;
        private readonly IMapper _mapper;

        public MuseumThemeController(IMuseumThemeService museumService, IMapper mapper)
        {
            _museumThemeService = museumService;
            _mapper = mapper;
        }


        // GET api/MuseumTheme
        [HttpGet]
        public async Task<IEnumerable<MuseumThemeResource>> ListAsync()
        {
            var themes = await _museumThemeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<MuseumTheme>, IEnumerable<MuseumThemeResource>>(themes);
            return resources;
        }

        // GET api/MuseumTheme/100
        [HttpGet("{id}")]
        public async Task<MuseumThemeResource> ListByIdAsync(int id)
        {
            var theme = await _museumThemeService.ListByIdAsync(id);
            var resource = _mapper.Map<MuseumTheme, MuseumThemeResource>(theme);
            return resource;
        }

    }
}