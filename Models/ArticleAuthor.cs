using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class ArticleAuthor
    {
        private readonly IArticleAuthorService _ArticleAuthorService;

        public ArticleAuthor()
        {


        }


        // public ArticleAuthor(IArticleAuthorService articleAuthorService)
        // {
        //     _ArticleAuthorService = articleAuthorService;

        // }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
