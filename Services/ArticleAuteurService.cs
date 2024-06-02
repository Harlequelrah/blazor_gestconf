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
        public ArticleAuteurService(AppDbContext context) : base(context)
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

        public override async Task<ArticleAuteur> GetByIdAsync(int id)
        {
            try
            {
                return await _context.ArticleAuteurs.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdAsync: {ex.Message}");
                return null;
            }
        }

        public override async Task<bool> AddAsync(ArticleAuteur articleAuteur)
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

        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var articleAuteur = await _context.ArticleAuteurs.FindAsync(id);
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
