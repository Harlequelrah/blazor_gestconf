using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ConferenceService : GenericCrudService<Conference>
    {
        public ConferenceService(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Conference>> GetAllAsync()
        {
            try
            {
                return await _context.Conferences.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<Conference>();
            }
        }

        public override async Task<Conference> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Conferences.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public override async Task<bool> AddAsync(Conference conference)
        {
            try
            {
                _context.Conferences.Add(conference);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
                return false;
            }
        }

        public override async Task<bool> UpdateAsync(Conference conference)
        {
            try
            {
                _context.Conferences.Update(conference);
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
                var conference = await _context.Conferences.FindAsync(id);
                if (conference != null)
                {
                    _context.Conferences.Remove(conference);
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
