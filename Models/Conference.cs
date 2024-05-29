using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class Conference
    {


        public Conference(){

        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Sigle { get; set; }
        public string? Theme { get; set; }
        public DateTime? DateSoumissionDebut { get; set; }
        public DateTime? DateRemiseResultats { get;set; }
        public DateTime? DateSoumissionFin { get; set; }
        public DateTime? DateInscriptionDebut { get; set; }
        public DateTime? DateInscriptionFin { get; set; }
        public DateTime? DateConferenceDebut { get; set; }
        public DateTime? DateConferenceFin { get; set; }

        public ICollection<ParticipantConference> Participants { get; set; } = new List<ParticipantConference>();
    }
}
