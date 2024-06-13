using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class AuteurService : GenericCrudService<Auteur>
    {
        public AuteurService(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Auteur>> GetAllAsync()
        {
            try
            {
                return await _context.Auteurs.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<Auteur>();
            }
        }

        public override async Task<Auteur> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Auteurs.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public override async Task<bool> AddAsync(Auteur auteur)
        {
            try
            {
                _context.Auteurs.Add(auteur);
                await _context.SaveChangesAsync();

                var roleResult = await _userManager.AddToRoleAsync(auteur, "Auteur");
                if (!roleResult.Succeeded)
                {
                    _context.Auteurs.Remove(auteur);
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


        public override async Task<bool> UpdateAsync(Auteur auteur)
        {
            try
            {
                _context.Auteurs.Update(auteur);
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
                var auteur = await _context.Auteurs.FindAsync(id);
                if (auteur != null)
                {
                    _context.Auteurs.Remove(auteur);
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
