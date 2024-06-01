using blazor_gestconf.Services;
using System.Collections.Generic;

namespace blazor_gestconf.Models
{
    public class Auteur : Utilisateur
    {

        public string Universite { get; set; }
        public string Entreprise { get; set; }
        public ICollection<ArticleAuthor> Articles { get; set; } = new List<ArticleAuthor>();

        public Auteur(int id, string name, string email, string password, string university, string entreprise)
            : base(id, name, email, password)
        {
            Universite = university;
            Entreprise = entreprise;
        }

        public Auteur():base(){}


    }
}
