using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class Participant : User
    {
        private readonly IParticipantService _participantService;

        // public Participant(IParticipantService participantService):base()
        // {
        //     _participantService = participantService;
        // }



        public Participant() : base()
        {

        }
    }
}
