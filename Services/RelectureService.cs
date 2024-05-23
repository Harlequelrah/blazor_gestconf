using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class RelectureService : IRelectureService
{
    private readonly AppDbContext _context;

    public RelectureService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Relecture>> GetRelecturesServiceAsync()
    {
        return await _context.Relectures.ToListAsync();
    }

    public async Task<Relecture> GetRelectureServiceByIdAsync(int id)
    {
        return await _context.Relectures.FindAsync(id);
    }

    public async Task AddRelectureServiceAsync(Relecture relecture)
    {
        _context.Relectures.Add(relecture);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRelectureServiceAsync(Relecture relecture)
    {
        _context.Relectures.Update(relecture);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRelectureAsync(int id)
    {
        var relecture = await _context.Relectures.FindAsync(id);
        if (relecture != null)
        {
            _context.Relectures.Remove(relecture);
            await _context.SaveChangesAsync();
        }
    }
}

}
