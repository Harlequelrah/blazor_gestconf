using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ParticipantService : GenericCrudService<Participant>
    {
        public ParticipantService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Participant>> GetAllAsync()
        {
            return await _context.Participants.ToListAsync();
        }

        public override async Task<Participant> GetByIdAsync(int id)
        {
            return await _context.Participants.FindAsync(id);
        }

        public override async Task AddAsync(Participant participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Participant participant)
        {
            _context.Participants.Update(participant);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
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
