namespace blazor_gestconf.Models
{
    public class Article
    {
        private int Id { get; set; }
        private string? Title { get; set; }
        private string? Description { get; set; }
        private string? FichierPdf { get; set; }
        
        public List<ArticleAuthor> Authors { get; set; }
        public List<ArticleAuthor> ProofReaders { get; set; }

        private int ConferenceId { get; set; }
    }
}
