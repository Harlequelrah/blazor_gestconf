using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class RelecteurService : GenericCrudService<Relecteur>
    {
        public RelecteurService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Relecteur>> GetAllAsync()
        {
            return await _context.Relecteurs.ToListAsync();
        }

        public override async Task<Relecteur> GetByIdAsync(int id)
        {
            return await _context.Relecteurs.FindAsync(id);
        }

        public override async Task AddAsync(Relecteur Relecteur)
        {
            _context.Relecteurs.Add(Relecteur);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Relecteur Relecteur)
        {
            _context.Relecteurs.Update(Relecteur);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var Relecteur = await _context.Relecteurs.FindAsync(id);
            if (Relecteur != null)
            {
                _context.Relecteurs.Remove(Relecteur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
