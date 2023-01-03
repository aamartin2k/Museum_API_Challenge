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
    }
}
