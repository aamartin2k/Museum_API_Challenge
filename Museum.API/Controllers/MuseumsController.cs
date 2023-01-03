using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;
using MuseumAPI.Mapping.Resources;

namespace MuseumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuseumsController : ControllerBase
    {
        // fields
        private readonly IMapper _mapper;
        private readonly IMuseumService _museumService;

        // Constructor
        public MuseumsController(IMuseumService museumService, IMapper mapper)
        {
            _museumService = museumService;
            _mapper = mapper;
        }


        // GET api/Museums
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "Museum 1", "Museum 2", "Museum 3", "Museum 4" };
        //}

        //
        [HttpGet]
        public async Task<IEnumerable<MuseumResource>> ListAsync()
        {
            var categories = await _museumService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Museum>, IEnumerable<MuseumResource>>(categories);

            return resources;
        }
    }
}
