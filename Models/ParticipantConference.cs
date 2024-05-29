using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class ParticipantConference
    {


        public ParticipantConference()
        {


        }


        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }

    }
}
