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

        // GET api/Museums
        [HttpGet]
        public async Task<IEnumerable<MuseumResource>> ListAsync()
        {
            var museums = await _museumService.ListAsync();

            Console.WriteLine("*** _museumService: " + museums.Count());

            var resources = _mapper.Map<IEnumerable<Museum>, IEnumerable<MuseumResource>>(museums);

            return resources;
        }

        // GET api/Museums/100
        [HttpGet("{id}")]
        public async Task<MuseumResource> ListByIdAsync(int id)
        {
            var museum = await _museumService.ListByIdAsync(id);
            var resource = _mapper.Map<Museum, MuseumResource>(museum);

            return resource;
        }

        
    }
}
