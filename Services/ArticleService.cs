using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ArticleService : GenericCrudService<Article>
    {
        public ArticleService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Article>> GetAllAsync()
        {
            try
            {
                return await _context.Articles.ToListAsync();
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
