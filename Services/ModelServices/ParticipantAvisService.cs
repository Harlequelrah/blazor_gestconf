using blazor_gestconf.Data;
using blazor_gestconf.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace blazor_gestconf.Services.ModelServices
{
    public class ParticipantAvisService
    {
        protected readonly ApplicationDbContext _context;
        protected readonly UserManager<Utilisateur>? _userManager;


        public ParticipantAvisService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Participant>> GetParticipantsByArticleIdAsync(int articleId)
        {
            return await _context.ParticipantAviss
                .Where(pa => pa.ArticleId == articleId)
                .Include(pa => pa.Participant)
                .Select(pa => pa.Participant)
                .ToListAsync();
        }   

        public async Task GiveAvis(int participantId, int articleId, string avis)
        {
            try
            {
                // Vérifier si un avis existe déjà
                var existingAvis = await _context.ParticipantAviss
                    .FirstOrDefaultAsync(pa => pa.ParticipantId == participantId && pa.ArticleId == articleId);

                if (existingAvis != null)
                {
                    // Gérer le cas où l'avis existe déjà
                    throw new InvalidOperationException("Un avis pour cet article de ce participant existe déjà.");
                }

                var participantAvis = new ParticipantAvis()
                {
                    ParticipantId = participantId,
                    ArticleId = articleId,
                    Avis = avis // Assurez-vous que la propriété Avis est correctement assignée
                };

                _context.ParticipantAviss.Add(participantAvis);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Gérer les exceptions et les journaux
                Console.WriteLine($"Erreur: {ex.Message}");
                throw; // Rethrow l'exception pour la gestion en aval si nécessaire
            }
        }

        public async Task<List<ParticipantAvis>> ShowAllAvis(int articleId)
        {
            return await _context.ParticipantAviss
                .Where(pa=>pa.ArticleId==articleId)
                .Include(pa=>pa.Participant)
                .Include(pa=>pa.Article)
                .ToListAsync();
        }
    }
}
