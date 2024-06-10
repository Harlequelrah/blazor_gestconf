using blazor_gestconf.Services;
using System.ComponentModel.DataAnnotations;

namespace blazor_gestconf.Models
{
    public class Conference
    {


        public Conference(){

        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Le Nom n'est pas renseigné")]
        public string Nom { get; set; }
        [Required(ErrorMessage ="Le signe n'est pas renseigné")]
        public string Sigle { get; set; }
        [Required(ErrorMessage = "Le thème n'est pas renseigné")]
        public string Theme { get; set; }
        [Required(ErrorMessage ="Veuillez renseigner toutes les dates")]
        public DateTime DateSoumissionDebut { get; set; } = DateTime.Now.Date;
        [Required(ErrorMessage = "Veuillez renseigner toutes les dates")]
        public DateTime DateRemiseResultats { get;set; }= DateTime.Now.Date;
        [Required(ErrorMessage = "Veuillez renseigner toutes les dates")]
        public DateTime DateSoumissionFin { get; set; } = DateTime.Now.Date;
        [Required(ErrorMessage = "Veuillez renseigner toutes les dates")]
        public DateTime DateInscriptionDebut { get; set; }= DateTime.Now.Date;
        [Required(ErrorMessage = "Veuillez renseigner toutes les dates")]
        public DateTime DateInscriptionFin { get; set; } = DateTime.Now.Date;
        [Required(ErrorMessage = "Veuillez renseigner toutes les dates")]
        public DateTime DateConferenceDebut { get; set; }= DateTime.Now.Date;
        [Required(ErrorMessage = "Veuillez renseigner toutes les dates")]
        public DateTime DateConferenceFin { get; set; } = DateTime.Now.Date;
        [Required(ErrorMessage = "Veuillez renseigner toutes les dates")]

        public ICollection<ParticipantConference> Participants { get; set; } = new List<ParticipantConference>();
        public ICollection<Article> Articles { get; set; }
    }
}
