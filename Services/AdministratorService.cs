using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class AdministratorService : IAdministratorService
{
    private readonly AppDbContext _context;

    public AdministratorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Administrator>> GetAdministratorsAsync()
    {
        return await _context.Administrators.ToListAsync();
    }

    public async Task<Administrator> GetAdministratorByIdAsync(int id)
    {
        return await _context.Administrators.FindAsync(id);
    }

    public async Task AddAdministratorAsync(Administrator administrator)
    {
        _context.Administrators.Add(administrator);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAdministratorAsync(Administrator administrator)
    {
        _context.Administrators.Update(administrator);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAdministratorAsync(int id)
    {
        var administrator = await _context.Administrators.FindAsync(id);
        if (administrator != null)
        {
            _context.Administrators.Remove(administrator);
            await _context.SaveChangesAsync();
        }
    }
}

}
