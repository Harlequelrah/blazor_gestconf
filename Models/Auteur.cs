using blazor_gestconf.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace blazor_gestconf.Models
{
    public class Auteur : Utilisateur
    {

        public int UniversiteId { get; set; }
        [ForeignKey("UniversiteId")] // Spécifie la clé étrangère
        public Universite Universite { get; set; }

        public int EntrepriseId { get; set; }
        [ForeignKey("EntrepriseId")] // Spécifie la clé étrangère
        public Entreprise Entreprise { get; set; }
        public ICollection<ArticleAuteur> Articles { get; set; } = new List<ArticleAuteur>();



        public Auteur():base(){}
        public Auteur(int universite, int entreprise) : base()
        {
            UniversiteId = universite;
            EntrepriseId = entreprise;
        }


    }
}
