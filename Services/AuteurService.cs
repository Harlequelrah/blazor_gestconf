using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class AuteurService : GenericCrudService<Auteur>
    {
        public AuteurService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Auteur>> GetAllAsync()
        {
            return await _context.Auteurs.ToListAsync();
        }

        public override async Task<Auteur> GetByIdAsync(int id)
        {
            return await _context.Auteurs.FindAsync(id);
        }

        public override async Task AddAsync(Auteur auteur)
        {
            _context.Auteurs.Add(auteur);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Auteur auteur)
        {
            _context.Auteurs.Update(auteur);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var auteur = await _context.Auteurs.FindAsync(id);
            if (auteur != null)
            {
                _context.Auteurs.Remove(auteur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
