using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class ArticleAuthor
    {
        private readonly IArticleAuthorService _articleAuthorService;

        public ArticleAuthor(IArticleAuthorService articleAuthorService)
        {
            _articleAuthorService = articleAuthorService;
        }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
