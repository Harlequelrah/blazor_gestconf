using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services{
    public class ProofReaderService : IProofReaderService
{
    private readonly AppDbContext _context;

    public ProofReaderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProofReader>> GetProofReadersServiceAsync()
    {
        return await _context.ProofReaders.ToListAsync();
    }

    public async Task<ProofReader> GetProofReaderServiceByIdAsync(int id)
    {
        return await _context.ProofReaders.FindAsync(id);
    }

    public async Task AddProofReaderServiceAsync(ProofReader proofReader)
    {
        _context.ProofReaders.Add(proofReader);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProofReaderServiceAsync(ProofReader proofReader)
    {
        _context.ProofReaders.Update(proofReader);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProofReaderServiceAsync(int id)
    {
        var proofReader = await _context.ProofReaders.FindAsync(id);
        if (proofReader != null)
        {
            _context.ProofReaders.Remove(proofReader);
            await _context.SaveChangesAsync();
        }
    }
}

}
