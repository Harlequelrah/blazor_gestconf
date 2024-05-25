using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class AdministratorService : GenericCrudService<Administrator>
    {
        public AdministratorService(AppDbContext context) : base(context)
        {
        }

        // Implémentation des méthodes CRUD spécifiques à Administrator
        public override async Task<List<Administrator>> GetAllAsync()
        {
            return await _context.Administrators.ToListAsync();
        }

        public override async Task<Administrator> GetByIdAsync(int id)
        {
            return await _context.Administrators.FindAsync(id);
        }

        public override async Task AddAsync(Administrator administrator)
        {
            _context.Administrators.Add(administrator);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Administrator administrator)
        {
            _context.Administrators.Update(administrator);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var administrator = await _context.Administrators.FindAsync(id);
            if (administrator != null)
            {
                _context.Administrators.Remove(administrator);
                await _context.SaveChangesAsync();
            }
        }
    }

    // Faire de même pour les autres classes d'entité...
}
