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
            return await _context.ArticleAuteurs.ToListAsync();
        }

        public override async Task<ArticleAuteur> GetByIdAsync(int id)
        {
            return await _context.ArticleAuteurs.FindAsync(id);
        }

        public override async Task AddAsync(ArticleAuteur articleAuteur)
        {
            _context.ArticleAuteurs.Add(articleAuteur);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(ArticleAuteur articleAuteur)
        {
            _context.ArticleAuteurs.Update(articleAuteur);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var articleAuteur = await _context.ArticleAuteurs.FindAsync(id);
            if (articleAuteur != null)
            {
                _context.ArticleAuteurs.Remove(articleAuteur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
