using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class MembreComiteService : GenericCrudService<MembreComite>
    {
        public MembreComiteService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<MembreComite>> GetAllAsync()
        {
            return await _context.MembreComites.ToListAsync();
        }

        public override async Task<MembreComite> GetByIdAsync(int id)
        {
            return await _context.MembreComites.FindAsync(id);
        }

        public override async Task AddAsync(MembreComite membreComite)
        {
            _context.MembreComites.Add(membreComite);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(MembreComite membreComite)
        {
            _context.MembreComites.Update(membreComite);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var membreComite = await _context.MembreComites.FindAsync(id);
            if (membreComite != null)
            {
                _context.MembreComites.Remove(membreComite);
                await _context.SaveChangesAsync();
            }
        }
    }
}
