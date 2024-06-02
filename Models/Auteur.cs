using blazor_gestconf.Services;
using System.Collections.Generic;

namespace blazor_gestconf.Models
{
    public class Auteur : Utilisateur
    {

        public string Universite { get; set; }
        public string Entreprise { get; set; }
        public ICollection<ArticleAuteur> Articles { get; set; } = new List<ArticleAuteur>();



        // public Auteur(int id, string name, string email, string password, string university, string entreprise)
        //     : base(id, name, email, password)
        // {
        //     Universite = university;
        //     Entreprise = entreprise;
        // }

        public Auteur():base(){}
        public Auteur(string universite, string entreprise) : base()
        {
            Universite = universite;
            Entreprise = entreprise;
        }


    }
}
