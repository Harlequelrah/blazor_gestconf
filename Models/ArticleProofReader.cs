namespace blazor_gestconf.Models
{
    public class ArticleProofReader
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int ProofReaderId { get; set; }
        public ProofReader ProofReader { get; set; }
    }
}




