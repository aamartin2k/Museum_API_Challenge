using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuseumAPI.Common;
using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;
using MuseumAPI.Mapping.Resources;

namespace MuseumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        // fields
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;

        // Constructor
        public ArticlesController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        // GET api/Articles
        [HttpGet]
        public async Task<IEnumerable<ArticleResource>> ListAsync()
        {
            var articles = await _articleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleResource>>(articles);

            return resources;
        }

        // GET api/Articles/100
        [HttpGet("{id}")]
        public async Task<ArticleResource> ListByIdAsync(int id)
        {
            var article = await _articleService.ListByIdAsync(id);
            var resource = _mapper.Map<Article, ArticleResource>(article);

            return resource;
        }

        // GET api/Articles/Museum/100
        // Retrieve all Museum’s articles.
        [HttpGet("Museum/{id}")]
        public async Task<IEnumerable<ArticleResource>> ListByMuseumIdAsync(int id)
        {
            var articles = await _articleService.ListByMuseumIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleResource>>(articles);

            return resources;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewArticleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var article = _mapper.Map<NewArticleResource, Article>(resource);
            var result = await _articleService.SaveAsync(article);

            if (!result.Success)
                return BadRequest(result.Message);

            var articleResource = _mapper.Map<Article, ArticleResource>(result.Article);
            return Ok(articleResource);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] NewArticleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var article = _mapper.Map<NewArticleResource, Article>(resource);
            var result = await _articleService.UpdateAsync(id, article);

            if (!result.Success)
                return BadRequest(result.Message);

            var articleResource = _mapper.Map<Article, ArticleResource>(result.Article);
            return Ok(articleResource);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _articleService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var articleResource = _mapper.Map<Article, ArticleResource>(result.Article);
            return Ok(articleResource);
        }

    }
}