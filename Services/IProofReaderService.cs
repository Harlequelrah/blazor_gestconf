using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services{
public interface IProofReaderService
{
    Task<List<ProofReader>> GetProofReadersServiceAsync();
    Task<ProofReader> GetProofReaderServiceByIdAsync(int id);
    Task AddProofReaderServiceAsync(ProofReader proofReader);
    Task UpdateProofReaderServiceAsync(ProofReader proofReader);
    Task DeleteProofReaderServiceAsync(int id);
}
}
