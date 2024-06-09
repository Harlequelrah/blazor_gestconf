using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class EntrepriseService : GenericCrudService<Entreprise>
    {
        public EntrepriseService(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Entreprise>> GetAllAsync()
        {
            try
            {
                return await _context.Entreprises.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return new List<Entreprise>();
            }
        }

        public override async Task<Entreprise> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Entreprises.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public override async Task<bool> AddAsync(Entreprise entreprise)
        {
            try
            {
                _context.Entreprises.Add(entreprise);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public override async Task<bool> UpdateAsync(Entreprise entreprise)
        {
            try
            {
                _context.Entreprises.Update(entreprise);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entreprise = await _context.Entreprises.FindAsync(id);
                if (entreprise != null)
                {
                    _context.Entreprises.Remove(entreprise);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
