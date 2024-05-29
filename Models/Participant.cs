using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class Participant : User
    {


        public ICollection<ParticipantConference> Conferences { get; set; } = new List<ParticipantConference>();

        public Participant() : base()
        {

        }
    }
}
