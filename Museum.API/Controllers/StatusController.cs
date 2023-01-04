using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;

namespace MuseumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IArticleStatusService _articleStatusService;

        public StatusController(IArticleStatusService articleStatus)
        {
            _articleStatusService = articleStatus;
        }


        // GET api/Status
        [HttpGet]
        public async Task<IEnumerable<ArticleStatus>> ListAsync()
        {
            var status = await _articleStatusService.ListAsync();
            return status;
        }

        // GET api/Status/100
        [HttpGet("{id}")]
        public async Task<ArticleStatus> ListByIdAsync(int id)
        {
            var status = await _articleStatusService.ListByIdAsync(id);
            return status;
        }
    }
}
