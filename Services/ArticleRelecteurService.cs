using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ArticleRelecteurService : GenericCrudService<ArticleRelecteur>
    {
        public ArticleRelecteurService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<ArticleRelecteur>> GetAllAsync()
        {
            return await _context.ArticleRelecteurs.ToListAsync();
        }

        public override async Task<ArticleRelecteur> GetByIdAsync(int id)
        {
            return await _context.ArticleRelecteurs.FindAsync(id);
        }

        public override async Task AddAsync(ArticleRelecteur articleRelecteur)
        {
            _context.ArticleRelecteurs.Add(articleRelecteur);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(ArticleRelecteur articleRelecteur)
        {
            _context.ArticleRelecteurs.Update(articleRelecteur);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var articleRelecteur = await _context.ArticleRelecteurs.FindAsync(id);
            if (articleRelecteur != null)
            {
                _context.ArticleRelecteurs.Remove(articleRelecteur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
