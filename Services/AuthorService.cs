// AuthorService
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class AuthorService : GenericCrudService<Author>
    {
        public AuthorService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public override async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public override async Task AddAsync(Author entity)
        {
            _context.Authors.Add(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Author entity)
        {
            _context.Authors.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await _context.Authors.FindAsync(id);
            if (entity != null)
            {
                _context.Authors.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
