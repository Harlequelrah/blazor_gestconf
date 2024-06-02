using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ParticipantService : GenericCrudService<Participant>
    {
        public ParticipantService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Participant>> GetAllAsync()
        {
            try
            {
                return await _context.Participants.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<Participant>();
            }
        }

        public override async Task<Participant> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Participants.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public override async Task<bool> AddAsync(Participant participant)
        {
            try
            {
                _context.Participants.Add(participant);
                await _context.SaveChangesAsync();

                var roleResult = await _userManager.AddToRoleAsync(participant, "Participant");
                if (!roleResult.Succeeded)
                {
                    _context.Participants.Remove(participant);
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


        public override async Task<bool> UpdateAsync(Participant participant)
        {
            try
            {
                _context.Participants.Update(participant);
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
                var participant = await _context.Participants.FindAsync(id);
                if (participant != null)
                {
                    _context.Participants.Remove(participant);
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
