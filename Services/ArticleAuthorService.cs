using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ArticleAuthorService : IArticleAuthorService
{
    private readonly AppDbContext _context;

    public ArticleAuthorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ArticleAuthor>> GetArticleAuthorsAsync()
    {
        return await _context.ArticleAuthors.ToListAsync();
    }

    public async Task<ArticleAuthor> GetArticleAuthorByIdAsync(int id)
    {
        return await _context.ArticleAuthors.FindAsync(id);
    }

    public async Task AddArticleAuthorAsync(ArticleAuthor ArticleAuthor)
    {
        _context.ArticleAuthors.Add(ArticleAuthor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateArticleAuthorAsync(ArticleAuthor ArticleAuthor)
    {
        _context.ArticleAuthors.Update(ArticleAuthor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteArticleAuthorAsync(int id)
    {
        var ArticleAuthor = await _context.ArticleAuthors.FindAsync(id);
        if (ArticleAuthor != null)
        {
            _context.ArticleAuthors.Remove(ArticleAuthor);
            await _context.SaveChangesAsync();
        }
    }
}

}
