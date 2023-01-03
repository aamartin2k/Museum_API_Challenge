using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Mapping.Resources
{
    public class ArticleResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int StatusId { get; set; }
        public int MuseumId { get; set; }

        //links for drive client behavior
        public string UrlStatus { get; set; }
    }
}
