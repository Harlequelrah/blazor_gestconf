// ProofReaderService
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class ProofReaderService : GenericCrudService<ProofReader>
    {
        public ProofReaderService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<ProofReader>> GetAllAsync()
        {
            return await _context.ProofReaders.ToListAsync();
        }

        public override async Task<ProofReader> GetByIdAsync(int id)
        {
            return await _context.ProofReaders.FindAsync(id);
        }

        public override async Task AddAsync(ProofReader entity)
        {
            _context.ProofReaders.Add(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(ProofReader entity)
        {
            _context.ProofReaders.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await _context.ProofReaders.FindAsync(id);
            if (entity != null)
            {
                _context.ProofReaders.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
