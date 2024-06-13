using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ArticleAuteurService : GenericCrudService<ArticleAuteur>
    {
        public ArticleAuteurService(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<ArticleAuteur>> GetAllAsync()
        {
            try
            {
                return await _context.ArticleAuteurs.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<ArticleAuteur>();
            }
        }

        public override async Task<ArticleAuteur> GetByIdsAsync(int articleId, int auteurId)
        {
            try
            {
                return await _context.ArticleAuteurs
                    .SingleOrDefaultAsync(aa => aa.ArticleId == articleId && aa.AuteurId == auteurId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public  override async Task<bool> AddAsync(ArticleAuteur articleAuteur)
        {
            try
            {
                _context.ArticleAuteurs.Add(articleAuteur);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
                return false;
            }
        }



        public override async Task<bool> UpdateAsync(ArticleAuteur articleAuteur)
        {
            try
            {
                _context.ArticleAuteurs.Update(articleAuteur);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAsync: {ex.Message}");
                return false;
            }
        }

        public  override async Task<bool> DeletesAsync(int articleId, int auteurId)
        {
            try
            {
                var articleAuteur = await GetByIdsAsync(articleId, auteurId);
                if (articleAuteur != null)
                {
                    _context.ArticleAuteurs.Remove(articleAuteur);
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
