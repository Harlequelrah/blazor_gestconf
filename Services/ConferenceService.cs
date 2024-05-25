using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ConferenceService : GenericCrudService<Conference>
    {
        public ConferenceService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Conference>> GetAllAsync()
        {
            return await _context.Conferences.ToListAsync();
        }

        public override async Task<Conference> GetByIdAsync(int id)
        {
            return await _context.Conferences.FindAsync(id);
        }

        public override async Task AddAsync(Conference conference)
        {
            _context.Conferences.Add(conference);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Conference conference)
        {
            _context.Conferences.Update(conference);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
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
