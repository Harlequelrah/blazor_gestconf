using blazor_gestconf.Services;
using System.Collections.Generic;

namespace blazor_gestconf.Models
{
    public class ArticleProofReader
    {
        private readonly IArticleProofReaderService _articleProofReaderService;

        public ArticleProofReader(IArticleProofReaderService articleProofReaderService)
        {
            _articleProofReaderService = articleProofReaderService;
        }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int ProofReaderId { get; set; }
        public ProofReader ProofReader { get; set; }

        // Correction : Ajout de la propriété Relecture
        public Relecture Relecture { get; set; }

    
    }
}
