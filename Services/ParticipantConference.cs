using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ParticipantConferenceService : GenericCrudService<ParticipantConference>
    {
        public ParticipantConferenceService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<ParticipantConference>> GetAllAsync()
        {
            try
            {
                return await _context.ParticipantConferences.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<ParticipantConference>();
            }
        }

        public override async Task<ParticipantConference> GetByIdAsync(int id)
        {
            try
            {
                return await _context.ParticipantConferences.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public override async Task<bool> AddAsync(ParticipantConference participantConference)
        {
            try
            {
                _context.ParticipantConferences.Add(participantConference);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
                return false;
            }
        }

        public override async Task<bool> UpdateAsync(ParticipantConference participantConference)
        {
            try
            {
                _context.ParticipantConferences.Update(participantConference);
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
                var participantConference = await _context.ParticipantConferences.FindAsync(id);
                if (participantConference != null)
                {
                    _context.ParticipantConferences.Remove(participantConference);
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
