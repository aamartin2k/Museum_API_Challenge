using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;
using MuseumAPI.Mapping.Resources;
using MuseumAPI.Common;

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

        // GET
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

        // POST
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewMuseumResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var museum = _mapper.Map<NewMuseumResource, Museum>(resource);
            var result = await _museumService.SaveAsync(museum);

            if (!result.Success)
                return BadRequest(result.Message);

            var museumResource = _mapper.Map<Museum, MuseumResource>(result.Museum);
            return Ok(museumResource);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] NewMuseumResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var museum = _mapper.Map<NewMuseumResource, Museum>(resource);
            var result = await _museumService.UpdateAsync(id, museum);

            if (!result.Success)
                return BadRequest(result.Message);

            var museumResource = _mapper.Map<Museum, MuseumResource>(result.Museum);
            return Ok(museumResource);
        }


    }
}
