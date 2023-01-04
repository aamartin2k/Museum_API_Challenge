using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;

namespace MuseumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly IMuseumThemeService _museumThemeService;

        public ThemesController(IMuseumThemeService museumService)
        {
            _museumThemeService = museumService;
        }


        // GET api/Themes
        [HttpGet]
        public async Task<IEnumerable<MuseumTheme>> ListAsync()
        {
            var themes = await _museumThemeService.ListAsync();
            return themes;
        }

        // GET api/Themes/100
        [HttpGet("{id}")]
        public async Task<MuseumTheme> ListByIdAsync(int id)
        {
            var theme = await _museumThemeService.ListByIdAsync(id);
            return theme;
        }

    }
}