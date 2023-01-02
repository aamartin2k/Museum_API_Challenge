using System;
using System.Collections.Generic;

namespace MuseumAPI.Domain.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int StatusId { get; set; }
        public ArticleStatus Status { get; set; }

        //links for drive client behavior 
        public string Url { get; set; }
    }
}
