using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ArticleRelecteurService : GenericCrudService<ArticleRelecteur>
    {
        public ArticleRelecteurService(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<ArticleRelecteur>> GetAllAsync()
        {
            try
            {
                return await _context.ArticleRelecteurs.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
                return new List<ArticleRelecteur>();
            }
        }

        public override  async Task<ArticleRelecteur> GetByIdsAsync(int articleId, int relecteurId)
        {
            try
            {
                return await _context.ArticleRelecteurs.FirstOrDefaultAsync(ar => ar.ArticleId == articleId && ar.RelecteurId == relecteurId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public override async Task<bool> AddAsync(ArticleRelecteur articleRelecteur)
        {
            try
            {
                _context.ArticleRelecteurs.Add(articleRelecteur);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAsync: {ex.Message}");
                return false;
            }
        }

        public override async Task<bool> UpdateAsync(ArticleRelecteur articleRelecteur)
        {
            try
            {
                _context.ArticleRelecteurs.Update(articleRelecteur);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAsync: {ex.Message}");
                return false;
            }
        }

        public  override async Task<bool> DeletesAsync(int articleId, int relecteurId)
        {
            try
            {
                var articleRelecteur = await _context.ArticleRelecteurs.FirstOrDefaultAsync(ar => ar.ArticleId == articleId && ar.RelecteurId == relecteurId);
                if (articleRelecteur != null)
                {
                    _context.ArticleRelecteurs.Remove(articleRelecteur);
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
