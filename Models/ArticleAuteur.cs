using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class ArticleAuteur
    {


        public ArticleAuteur()
        {


        }


        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int AuteurId { get; set; }

        public Auteur Auteur { get; set; }

    }
}
