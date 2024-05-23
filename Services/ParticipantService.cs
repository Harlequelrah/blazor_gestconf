using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ParticipantService : IParticipantService
{
    private readonly AppDbContext _context;

    public ParticipantService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Participant>> GetParticipantsAsync()
    {
        return await _context.Participants.ToListAsync();
    }

    public async Task<Participant> GetParticipantByIdAsync(int id)
    {
        return await _context.Participants.FindAsync(id);
    }

    public async Task AddParticipantAsync(Participant participant)
    {
        _context.Participants.Add(participant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateParticipantAsync(Participant participant)
    {
        _context.Participants.Update(participant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteParticipantAsync(int id)
    {
        var participant = await _context.Participants.FindAsync(id);
        if (participant != null)
        {
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();
        }
    }
}

}
