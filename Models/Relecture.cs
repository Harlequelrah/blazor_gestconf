using blazor_gestconf.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace blazor_gestconf.Models
{
    public class Relecture
    {
        public Relecture()
        {
        }

        // public int Id { get; set; }

        public int ArticleId { get; set; }
        [Required(ErrorMessage ="Titre obligatioire")]

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
        public int RelecteurId { get; set; }

        [ForeignKey("AuteurId")]
        public Auteur Auteur { get; set; }
        public int  AuteurId { get; set; }

        [ForeignKey("RelecteurId")]
        public Relecteur Relecteur { get; set; }
        // public ArticleRelecteur ArticleRelecteur { get; set; }
        public int NoteFond { get; set; }
        public int NoteForme { get; set; }
        public int NotePertinenceScientifique { get; set; }
        public string? Justification { get; set; }
        public string? Avis { get; set; }
    }
}
