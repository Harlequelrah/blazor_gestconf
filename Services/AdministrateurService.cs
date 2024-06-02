using System;
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
            try
            {
                return await _context.Administrateurs.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<Administrateur>();
            }
        }

        public override async Task<Administrateur> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Administrateurs.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public override async Task<bool> AddAsync(Administrateur administrateur)
        {
            try
            {
                // Ajouter l'administrateur
                _context.Administrateurs.Add(administrateur);
                await _context.SaveChangesAsync();

                // Attribuer le rôle d'administrateur à l'utilisateur
                var roleResult = await _userManager.AddToRoleAsync(administrateur, "Administrateur");
                if (!roleResult.Succeeded)
                {
                    // Si l'attribution du rôle échoue, vous pouvez gérer l'erreur ici
                    // Vous pouvez également annuler la création de l'administrateur en supprimant l'administrateur créé précédemment du contexte
                    _context.Administrateurs.Remove(administrateur);
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


        public override async Task<bool> UpdateAsync(Administrateur administrateur)
        {
            try
            {
                _context.Administrateurs.Update(administrateur);
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
                var administrateur = await _context.Administrateurs.FindAsync(id);
                if (administrateur != null)
                {
                    _context.Administrateurs.Remove(administrateur);
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
