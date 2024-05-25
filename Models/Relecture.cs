using blazor_gestconf.Services;
namespace blazor_gestconf.Models
{
    public class Relecture
    {
        public Relecture()
        {
        }

        public int Id { get; set; }

        public int ProofReaderId { get; set; }
        public ProofReader ProofReader { get; set; }
        public int ArticleProofReaderId { get; set; }
        public ArticleProofReader ArticleProofReader { get; set; }
        public int NoteFond { get; set; }
        public int NoteForme { get; set; }
        public int NotePertinenceScientifique { get; set; }
        public string? Justification { get; set; }
        public string? Comments { get; set; }
    }
}
