// ConferenceService
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

        public override async Task AddAsync(Conference entity)
        {
            _context.Conferences.Add(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Conference entity)
        {
            _context.Conferences.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await _context.Conferences.FindAsync(id);
            if (entity != null)
            {
                _context.Conferences.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
