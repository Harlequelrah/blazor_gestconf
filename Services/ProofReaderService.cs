using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ProofReaderService : GenericCrudService<Relecteur>
    {
        public ProofReaderService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<Relecteur>> GetAllAsync()
        {
            return await _context.Relecteurs.ToListAsync();
        }

        public override async Task<Relecteur> GetByIdAsync(int id)
        {
            return await _context.Relecteurs.FindAsync(id);
        }

        public override async Task AddAsync(Relecteur proofReader)
        {
            _context.Relecteurs.Add(proofReader);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Relecteur proofReader)
        {
            _context.Relecteurs.Update(proofReader);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var proofReader = await _context.Relecteurs.FindAsync(id);
            if (proofReader != null)
            {
                _context.Relecteurs.Remove(proofReader);
                await _context.SaveChangesAsync();
            }
        }
    }
}
