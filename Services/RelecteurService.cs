using System;
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
            try
            {
                return await _context.Relecteurs.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<Relecteur>();
            }
        }

        public override async Task<Relecteur> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Relecteurs.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        
        public override async Task<bool> AddAsync(Relecteur relecteur)
        {
            try
            {
                _context.Relecteurs.Add(relecteur);
                await _context.SaveChangesAsync();

                var roleResult = await _userManager.AddToRoleAsync(relecteur, "Relecteur");
                if (!roleResult.Succeeded)
                {
                    _context.Relecteurs.Remove(relecteur);
                    await _context.SaveChangesAsync();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
                return false;
            }
        }


        public override async Task<bool> UpdateAsync(Relecteur Relecteur)
        {
            try
            {
                _context.Relecteurs.Update(Relecteur);
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
                var Relecteur = await _context.Relecteurs.FindAsync(id);
                if (Relecteur != null)
                {
                    _context.Relecteurs.Remove(Relecteur);
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
