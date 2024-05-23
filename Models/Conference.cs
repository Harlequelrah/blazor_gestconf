using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class Conference
    {
        private readonly IConferenceService _conferenceService;

        public Conference(IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }

        private int Id { get; set; }
        private string? Name { get; set; }
        private string? Sigle { get; set; }
        private string? Theme { get; set; }
        private DateTime? DateSoumissionDebut { get; set; }
        private DateTime? DateRemiseResultats { get;set; }
        private DateTime? DateSoumissionFin { get; set; }
        private DateTime? DateInscriptionDebut { get; set; }
        private DateTime? DateInscriptionFin { get; set; }
        private DateTime? DateConferenceDebut { get; set; }
        private DateTime? DateConferenceFin { get; set; }
    }
}
