using System;
using System.Collections.Generic;

namespace MuseumAPI.Domain.Models
{
    public class Museum
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int ThemeId { get; set; }
        
        public IList<Article> Articles { get; set; } = new List<Article>();
    }
}
