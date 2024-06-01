using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class AdministrateurService : GenericCrudService<Administrateur>
    {
        public AdministrateurService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Administrateur>> GetAllAsync()
        {
            return await _context.Administrateurs.ToListAsync();
        }

        public override async Task<Administrateur> GetByIdAsync(int id)
        {
            return await _context.Administrateurs.FindAsync(id);
        }

        public override async Task AddAsync(Administrateur administrateur)
        {
            _context.Administrateurs.Add(administrateur);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Administrateur administrateur)
        {
            _context.Administrateurs.Update(administrateur);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var administrateur = await _context.Administrateurs.FindAsync(id);
            if (administrateur != null)
            {
                _context.Administrateurs.Remove(administrateur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
