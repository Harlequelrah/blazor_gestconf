using blazor_gestconf.Services;
namespace blazor_gestconf.Models
{
    public class Relecture
    {
        public Relecture()
        {
        }

        public int Id { get; set; }


        public int RelecteurId { get; set; }
        public Relecteur Relecteur { get; set; }
        public int ArticleRelecteurId { get; set; }
        public ArticleRelecteur ArticleRelecteur { get; set; }
        public int NoteFond { get; set; }
        public int NoteForme { get; set; }
        public int NotePertinenceScientifique { get; set; }
        public string? Justification { get; set; }
        public string? Comments { get; set; }
    }
}
