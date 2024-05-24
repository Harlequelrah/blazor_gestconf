using System.ComponentModel.DataAnnotations.Schema;
using blazor_gestconf.Services;
using System.Collections.Generic;

namespace blazor_gestconf.Models
{
    public class ArticleProofReader
    {
        private readonly IArticleProofReaderService _articleProofReaderService;

        public ArticleProofReader()
        {

        }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int ProofReaderId { get; set; }
        public ProofReader ProofReader { get; set; }

        [ForeignKey("Relecture")]
        public int? RelectureId { get; set; } // Permet de stocker la clé étrangère de Relecture
        public Relecture Relecture { get; set; }
    }
}
