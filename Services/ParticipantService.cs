// ParticipantService
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

        public override async Task AddAsync(Participant entity)
        {
            _context.Participants.Add(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Participant entity)
        {
            _context.Participants.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await _context.Participants.FindAsync(id);
            if (entity != null)
            {
                _context.Participants.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
