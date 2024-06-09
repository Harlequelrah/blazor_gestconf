using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class UniversiteService : GenericCrudService<Universite>
    {
        public UniversiteService(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Universite>> GetAllAsync()
        {
            try
            {
                return await _context.Universites.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return new List<Universite>();
            }
        }

        public override async Task<Universite> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Universites.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public override async Task<bool> AddAsync(Universite universite)
        {
            try
            {
                _context.Universites.Add(universite);
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

        public override async Task<bool> UpdateAsync(Universite universite)
        {
            try
            {
                _context.Universites.Update(universite);
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
                var universite = await _context.Universites.FindAsync(id);
                if (universite != null)
                {
                    _context.Universites.Remove(universite);
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
