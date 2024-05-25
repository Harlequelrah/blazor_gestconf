using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ArticleProofReaderService : GenericCrudService<ArticleProofReader>
    {
        public ArticleProofReaderService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<ArticleProofReader>> GetAllAsync()
        {
            return await _context.ArticleProofReaders.ToListAsync();
        }

        public override async Task<ArticleProofReader> GetByIdAsync(int id)
        {
            return await _context.ArticleProofReaders.FindAsync(id);
        }

        public override async Task AddAsync(ArticleProofReader articleProofReader)
        {
            _context.ArticleProofReaders.Add(articleProofReader);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(ArticleProofReader articleProofReader)
        {
            _context.ArticleProofReaders.Update(articleProofReader);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var articleProofReader = await _context.ArticleProofReaders.FindAsync(id);
            if (articleProofReader != null)
            {
                _context.ArticleProofReaders.Remove(articleProofReader);
                await _context.SaveChangesAsync();
            }
        }
    }
}
