using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class ProofReader : User
    {
        private readonly IProofReaderService _ProofReaderService;

        // public ProofReader(IProofReaderService proofReaderService):base()
        // {
        //     _ProofReaderService = proofReaderService?? throw new ArgumentNullException(nameof(proofReaderService));
        //     _ProofReaderService = proofReaderService;
        //     Articles = new List<ArticleProofReader>();
        //     Relectures = new List<Relecture>();
        // }

        public ProofReader() : base()
        {
        }
        public ICollection<ArticleProofReader> Articles { get; set; }
        public ICollection<Relecture> Relectures { get; set; }

    }
}
