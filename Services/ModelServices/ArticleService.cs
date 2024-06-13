using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;
using Microsoft.EntityFrameworkCore;

namespace blazor_gestconf.Services
{
    public class ArticleService : GenericCrudService<Article>
    {
        public ArticleService(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Article>> GetAllAsync()
        {
            try
            {
                return await _context.Articles.Include(a => a.Conference)
                                              .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return new List<Article>();
            }
        }

        public override async Task<Article> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Articles.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public override async Task<bool> AddAsync(Article article)
        {
            try
            {
                _context.Articles.Add(article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task <int> GetLastInsertedId()
    {
        var task = Task.Run(() =>
    {
        return _context.Articles.OrderByDescending(a => a.Id).FirstOrDefault().Id;
    });

    return await task;
    }

        public override async Task<bool> UpdateAsync(Article article)
        {
            try
            {
                _context.Articles.Update(article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Article>> GetArticlesByAuteurAsync(int auteurId)
        {
            return await _context.Articles
                .Where(a => a.Auteurs.Any(aa => aa.AuteurId == auteurId))
                .Include(a => a.Conference) // Inclure la conférence si nécessaire
                .ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByConference(int conferenceId)
        {
            return await _context.Articles
                .Where(a => a.ConferenceId == conferenceId)
                .Include(a => a.Conference)
                .ToListAsync();
        }

        public async Task<List<Article>> GetArticlesByRelecteurAsync(int relecteurId)
        {
            return await _context.Articles
                .Where(a => a.Relectures.Any(r => r.RelecteurId == relecteurId))
                .Include(a => a.Conference) // Inclure la conférence si nécessaire
                .ToListAsync();
        }



        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var article = await _context.Articles.FindAsync(id);
                if (article != null)
                {
                    _context.Articles.Remove(article);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
