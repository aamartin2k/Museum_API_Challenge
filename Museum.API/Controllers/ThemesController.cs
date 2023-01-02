﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MuseumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        // GET api/Themes
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Art", "Natural Science", "History" };
        }
    }
}