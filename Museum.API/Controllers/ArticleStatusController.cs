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
    public class ArticleStatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArticleStatusService _articleStatusService;

        public ArticleStatusController(IArticleStatusService articleStatus, IMapper mapper)
        {
            _articleStatusService = articleStatus;
            _mapper = mapper;
        }


        // GET api/Status
        [HttpGet]
        public async Task<IEnumerable<ArticleStatusResource>> ListAsync()
        {
            var status = await _articleStatusService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ArticleStatus>, IEnumerable<ArticleStatusResource>>(status);
            return resources;
        }

        // GET api/Status/100
        [HttpGet("{id}")]
        public async Task<ArticleStatusResource> ListByIdAsync(int id)
        {
            var status = await _articleStatusService.ListByIdAsync(id);
            var resource = _mapper.Map<ArticleStatus, ArticleStatusResource>(status);
            return resource;
        }
    }
}
