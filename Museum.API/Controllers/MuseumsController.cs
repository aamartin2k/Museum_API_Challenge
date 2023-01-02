using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;

namespace MuseumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuseumsController : ControllerBase
    {
        //
        private readonly IMuseumService _museumService;

        // Constructor
        public MuseumsController(IMuseumService museumService)
        {
            _museumService = museumService;
        }


        // GET api/Museums
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Museum 1", "Museum 2", "Museum 3", "Museum 4" };
        }

        //
        public async Task<IEnumerable<Museum>> ListAsync()
        {
            var categories = await _museumService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            return resources;
        }
    }
}
