using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class Relecteur : Utilisateur
    {
        public Relecteur() : base()
        {
        }
        // public ICollection<ArticleRelecteur> Articles { get; set; }
        public ICollection<Relecture> Relectures { get; set; }

    }
}
