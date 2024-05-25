using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class ProofReader : User
    {



        public ProofReader() : base()
        {
            Relectures = new List<Relecture>();
        }
        public ICollection<ArticleProofReader> Articles { get; set; }
        public ICollection<Relecture> Relectures { get; set; }

    }
}
