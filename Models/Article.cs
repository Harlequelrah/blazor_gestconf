    using blazor_gestconf.Services;
using System.Collections.Generic;
namespace blazor_gestconf.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string FichierPdf { get; set; }
        public string Statut { get; set; }
        public int ConferenceId { get; set; }

        public ICollection<ArticleAuteur> Auteurs { get; set; } = new List<ArticleAuteur>();
        public ICollection<ArticleRelecteur> Relecteurs { get; set; } = new List<ArticleRelecteur>();

        public Article(){

        }
        public Article(int id, string title, string description, string fichierPdf, string statut, int conferenceId)
        {
            Id = id;
            Titre = title;
            Description = description;
            FichierPdf = fichierPdf;
            Statut = statut;
            ConferenceId = conferenceId;
        }


    }
}
