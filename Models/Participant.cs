﻿using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class Participant : Utilisateur
    {


        public ICollection<ParticipantConference> ParticipantConferences { get; set; }

        public Participant() : base()
        {

        }
    }
}
