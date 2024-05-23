using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ArticleProofReaderService : IArticleProofReaderService
{
    private readonly AppDbContext _context;

    public ArticleProofReaderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ArticleProofReader>> GetArticleProofReadersAsync()
    {
        return await _context.ArticleProofReaders.ToListAsync();
    }

    public async Task<ArticleProofReader> GetArticleProofReaderByIdAsync(int id)
    {
        return await _context.ArticleProofReaders.FindAsync(id);
    }

    public async Task AddArticleProofReaderAsync(ArticleProofReader ArticleProofReader)
    {
        _context.ArticleProofReaders.Add(ArticleProofReader);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateArticleProofReaderAsync(ArticleProofReader ArticleProofReader)
    {
        _context.ArticleProofReaders.Update(ArticleProofReader);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteArticleProofReaderAsync(int id)
    {
        var ArticleProofReader = await _context.ArticleProofReaders.FindAsync(id);
        if (ArticleProofReader != null)
        {
            _context.ArticleProofReaders.Remove(ArticleProofReader);
            await _context.SaveChangesAsync();
        }
    }
}

}
