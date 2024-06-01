using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services.Administrateur
{
    public class AdministrateurService:IAdministrateurService
    {
        private readonly AppDbContext _context;
        private readonly ILogger? _logger;
        public AdministrateurService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Administrateur>> GetAdmin()
        {
            return await _context.Administrateurs.ToListAsync();
        }

        public async Task<Models.Administrateur> GetAdminById(int id)
        {

            return await _context.Administrateurs.FindAsync(id);
        }

        public async Task InsererUnAdmin(Models.Administrateur admin)
        {
            _context.Administrateurs.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task EditerUnAdmin(Models.Administrateur admin)
        {
            _context.Administrateurs.Update(admin);
            await _context.SaveChangesAsync();
        }

        public async Task SupprimerUnAdmin(int id)
        {
            var admin = await GetAdminById(id);
            if (admin != null)
            {
                _context.Administrateurs.Remove(admin);
                await _context.SaveChangesAsync();
            }
        }
    }
}
