using System.ComponentModel.DataAnnotations.Schema;
using blazor_gestconf.Services;
using System.Collections.Generic;

namespace blazor_gestconf.Models
{
    public class ArticleRelecteur
    {


        public ArticleRelecteur()
        {

        }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int RelecteurId { get; set; }
        public Relecteur Relecteur { get; set; }

       public int? RelectureId { get; set; }  //Permet de stocker la clé étrangère de Relecture
        public Relecture Relecture { get; set; }
    }
}
