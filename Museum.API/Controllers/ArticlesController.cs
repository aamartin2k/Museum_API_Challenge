using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MuseumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        // GET api/Articles
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Article 1", "Article 2", "Article 3" };
        }
    }
}