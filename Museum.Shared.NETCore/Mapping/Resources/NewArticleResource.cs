using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Mapping.Resources
{
    public class NewArticleResource
    {
        public string Name { get; set; }
        public int StatusId { get; set; }
        public int MuseumId { get; set; }

    }
}
