namespace blazor_gestconf.Models
{
    public class Relecture
    {
        private int id { set; get; }
        private int articleId { get; set; }
        private int proofReaderId { get; set; }
        private int noteFond { get; set; }
        private int noteForme { get; set; }
        private int notePertinenceScientifique { get; set; }
        private string? Justification { get; set; }
        private string? Comments { get; set; }
        private string? Statut { get; set; }
    }
}
