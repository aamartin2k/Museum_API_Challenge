using MuseumAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Services.Responses
{
    public class ArticleResponse : BaseResponse
    {
        public Article Article { get; private set; }

        private ArticleResponse(bool success, string message, Article article) : base(success, message)
        {
            Article = article;
        }

        // Success response constructor
        public ArticleResponse(Article article) : this(true, string.Empty, article)
        { }

        // Error response constructor
        public ArticleResponse(string message) : this(false, message, null)
        { }
    }
}
