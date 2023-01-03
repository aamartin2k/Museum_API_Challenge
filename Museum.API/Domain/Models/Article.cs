using System;
using System.Collections.Generic;

namespace MuseumAPI.Domain.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // 
        public int StatusId { get; set; }

        public int MuseumId { get; set; }
        public Museum Museum { get; set; }


    }
}
