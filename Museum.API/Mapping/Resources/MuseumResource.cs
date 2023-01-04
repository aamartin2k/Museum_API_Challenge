using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Mapping.Resources
{
    public class MuseumResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ThemeId { get; set; }

        //links for drive client behavior
        // GET api/Articles/Museum/100  Retrieve all Museum’s articles.
        //Just to demonstrate a very simple use of HATEOAS.
        public string UrlArticles { get; set; }
    }
}
