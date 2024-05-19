namespace blazor_gestconf.Models
{
    public class ArticleAuthor
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}




