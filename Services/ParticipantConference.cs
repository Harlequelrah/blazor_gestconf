using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ParticipantConferenceService : GenericCrudService<ParticipantConference>
    {
        public ParticipantConferenceService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<ParticipantConference>> GetAllAsync()
        {
            return await _context.ParticipantConferences.ToListAsync();
        }

        public override async Task<ParticipantConference> GetByIdAsync(int id)
        {
            return await _context.ParticipantConferences.FindAsync(id);
        }

        public override async Task AddAsync(ParticipantConference ParticipantConference)
        {
            _context.ParticipantConferences.Add(ParticipantConference);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(ParticipantConference ParticipantConference)
        {
            _context.ParticipantConferences.Update(ParticipantConference);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var ParticipantConference = await _context.ParticipantConferences.FindAsync(id);
            if (ParticipantConference != null)
            {
                _context.ParticipantConferences.Remove(ParticipantConference);
                await _context.SaveChangesAsync();
            }
        }
    }
}
