namespace blazor_gestconf.Models
{
    public class Article
    {
        private int id { get; set; }
        private string? title { get; set; }
        private string? description { get; set; }
        private string? FichierPdf { get; set; }
        private string? Statut { get; set; }
        private int authorId { get; set; }
        private int conferenceId { get; set; }
    }
}
