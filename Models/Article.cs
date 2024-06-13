using blazor_gestconf.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace blazor_gestconf.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Titre { get; set; }
        [Required(ErrorMessage ="Description obligatoire")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Veuillez téléverser votre article en format Pdf")]
        public byte[] FichierPdf { get; set; }
        public string? Statut { get; set; } = "";
        public int ConferenceId { get; set; }

        [ForeignKey("ConferenceId")]
        public Conference Conference { get; set; }

        public ICollection<ArticleAuteur> Auteurs { get; set; } = new List<ArticleAuteur>();
        public ICollection<Relecture> Relectures { get; set; } = new List<Relecture>();
        public ICollection<ParticipantAvis> ParticipantAviss { get; set; }
        // public ICollection<ArticleRelecteur> Relecteurs { get; set; } = new List<ArticleRelecteur>();

        public Article(){

        }

        public Article(int  id, string title, string description, byte[] fichierPdf, string statut, int conferenceId)
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
