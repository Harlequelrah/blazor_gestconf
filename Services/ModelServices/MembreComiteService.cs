using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class MembreComiteService : GenericCrudService<MembreComite>
    {
        public MembreComiteService(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<MembreComite>> GetAllAsync()
        {
            try
            {
                return await _context.MembreComites.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<MembreComite>();
            }
        }

        public override async Task<MembreComite> GetByIdAsync(int id)
        {
            try
            {
                return await _context.MembreComites.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public override async Task<bool> AddAsync(MembreComite membreComite)
        {
            try
            {
                _context.MembreComites.Add(membreComite);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
                return false;
            }
        }

        public override async Task<bool> UpdateAsync(MembreComite membreComite)
        {
            try
            {
                _context.MembreComites.Update(membreComite);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAsync: {ex.Message}");
                return false;
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var membreComite = await _context.MembreComites.FindAsync(id);
                if (membreComite != null)
                {
                    _context.MembreComites.Remove(membreComite);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteAsync: {ex.Message}");
                return false;
            }
        }
    }
}
