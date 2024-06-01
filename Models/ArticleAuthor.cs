using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class ArticleAuthor
    {
        

        public ArticleAuthor()
        {


        }


        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int AuthorId { get; set; }
        public Auteur Author { get; set; }

    }
}
