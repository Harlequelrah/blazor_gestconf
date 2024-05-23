using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ConferenceService : IConferenceService
{
    private readonly AppDbContext _context;

    public ConferenceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Conference>> GetConferencesAsync()
    {
        return await _context.Conferences.ToListAsync();
    }

    public async Task<Conference> GetConferenceByIdAsync(int id)
    {
        return await _context.Conferences.FindAsync(id);
    }

    public async Task AddConferenceAsync(Conference conference)
    {
        _context.Conferences.Add(conference);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateConferenceAsync(Conference conference)
    {
        _context.Conferences.Update(conference);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteConferenceAsync(int id)
    {
        var conference = await _context.Conferences.FindAsync(id);
        if (conference != null)
        {
            _context.Conferences.Remove(conference);
            await _context.SaveChangesAsync();
        }
    }
}

}
