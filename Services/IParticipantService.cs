using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public interface IParticipantService
{
    Task<List<Participant>> GetParticipantsAsync();
    Task<Participant> GetParticipantByIdAsync(int id);
    Task AddParticipantAsync(Participant participant);
    Task UpdateParticipantAsync(Participant participant);
    Task DeleteParticipantAsync(int id);
}

}
