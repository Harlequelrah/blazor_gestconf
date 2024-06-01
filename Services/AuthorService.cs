using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class AuthorService : GenericCrudService<Auteur>
    {
        public AuthorService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Auteur>> GetAllAsync()
        {
            return await _context.Auteurs.ToListAsync();
        }

        public override async Task<Auteur> GetByIdAsync(int id)
        {
            return await _context.Auteurs.FindAsync(id);
        }

        public override async Task AddAsync(Auteur author)
        {
            _context.Auteurs.Add(author);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Auteur author)
        {
            _context.Auteurs.Update(author);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var author = await _context.Auteurs.FindAsync(id);
            if (author != null)
            {
                _context.Auteurs.Remove(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}
