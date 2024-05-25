using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ArticleAuthorService : GenericCrudService<ArticleAuthor>
    {
        public ArticleAuthorService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<ArticleAuthor>> GetAllAsync()
        {
            return await _context.ArticleAuthors.ToListAsync();
        }

        public override async Task<ArticleAuthor> GetByIdAsync(int id)
        {
            return await _context.ArticleAuthors.FindAsync(id);
        }

        public override async Task AddAsync(ArticleAuthor entity)
        {
            _context.ArticleAuthors.Add(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(ArticleAuthor entity)
        {
            _context.ArticleAuthors.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await _context.ArticleAuthors.FindAsync(id);
            if (entity != null)
            {
                _context.ArticleAuthors.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
