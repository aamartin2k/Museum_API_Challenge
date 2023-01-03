﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.WriteLine("*** _articleService: " + articles.Count());

            var resources = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleResource>>(articles);

            return resources;
        }

        // GET api/Museums/100
        [HttpGet("{id}")]
        public async Task<ArticleResource> ListByIdAsync(int id)
        {
            var article = await _articleService.ListByIdAsync(id);
            var resource = _mapper.Map<Article, ArticleResource>(article);

            return resource;
        }

    }
}