// RelectureService
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class RelectureService : GenericCrudService<Relecture>
    {
        public RelectureService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Relecture>> GetAllAsync()
        {
            return await _context.Relectures.ToListAsync();
        }

        public override async Task<Relecture> GetByIdAsync(int id)
        {
            return await _context.Relectures.FindAsync(id);
        }

        public override async Task AddAsync(Relecture entity)
        {
            _context.Relectures.Add(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Relecture entity)
        {
            _context.Relectures.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await _context.Relectures.FindAsync(id);
            if (entity != null)
            {
                _context.Relectures.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
