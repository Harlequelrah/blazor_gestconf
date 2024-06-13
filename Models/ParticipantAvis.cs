using System.ComponentModel.DataAnnotations;

namespace blazor_gestconf.Models
{
    public class ParticipantAvis
    {
        public int ParticipantId {  get; set; }
        public int ArticleId { get; set; }
        [Required(ErrorMessage ="Veuillez doner un avis s'il vous plaît")]
        public string Avis { get; set; }
        public Participant Participant { get; set; }
        public Article Article { get; set; }
    }
}
