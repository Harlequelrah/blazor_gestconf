using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class ProofReader : User
    {
        private readonly IProofReaderService _proofReaderService;

        public ProofReader(IProofReaderService proofReaderService):base()
        {
            _proofReaderService = proofReaderService;
        }

        public ProofReader() : base()
        {
        }
        public ICollection<ArticleProofReader> Articles { get; set; }
        public ICollection<Relecture> Relectures { get; set; }

    }
}
