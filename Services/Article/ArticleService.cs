using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services.Article
{
    public class ArticleService : IArticleService
    {
        private readonly AppDbContext _context;
        private readonly ILogger? _logger;

        public ArticleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Models.Article> GetArticleById(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task InsererUnArticle(Models.Article art)
        {
            _context.Articles.Add(art);
            await _context.SaveChangesAsync();
        }

        public async Task EditerUnArticle(Models.Article art)
        {
            _context.Articles.Update(art);
            await _context.SaveChangesAsync();
        }

        public async Task SupprimerUnArticle(int id)
        {
            var article = await GetArticleById(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }
    }
}
