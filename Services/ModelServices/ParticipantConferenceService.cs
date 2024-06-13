using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;
using Microsoft.AspNetCore.Identity;

namespace blazor_gestconf.Services
{
    public class ParticipantConferenceService
    {
        protected readonly ApplicationDbContext _context;
        protected readonly UserManager<Utilisateur>? _userManager;


        public ParticipantConferenceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParticipantConference>> GetAllAsync()
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

        public async Task<ParticipantConference> GetByIdsAsync(int participantId, int conferenceId)
        {
            try
            {
                return await _context.ParticipantConferences
                    .SingleOrDefaultAsync(pc => pc.ParticipantId == participantId && pc.ConferenceId == conferenceId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdsAsync: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddConferenceToParticipantAsync(int participantId, int conferenceId)
        {
            try
            {
                var participantConference = new ParticipantConference
                {
                    ParticipantId = participantId,
                    ConferenceId = conferenceId
                };

                _context.ParticipantConferences.Add(participantConference);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"Error adding conference to participant: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(ParticipantConference participantConference)
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

        public async Task<bool> DeletesAsync(int participantId, int conferenceId)
        {
            try
            {
                var participantConference = await GetByIdsAsync(participantId, conferenceId);
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
        public async Task<List<Conference>> GetAllParticipantConference(int idParticipant)
        {
            return await _context.ParticipantConferences
                .Where(pc => pc.ParticipantId == idParticipant)
                .Select(pc => pc.Conference)
                .ToListAsync();

        }
    }
}
