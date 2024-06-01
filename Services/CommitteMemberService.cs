using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class CommitteeMemberService : GenericCrudService<MembreComite>
    {
        public CommitteeMemberService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<MembreComite>> GetAllAsync()
        {
            return await _context.MembreComites.ToListAsync();
        }

        public override async Task<MembreComite> GetByIdAsync(int id)
        {
            return await _context.MembreComites.FindAsync(id);
        }

        public override async Task AddAsync(MembreComite committeeMember)
        {
            _context.MembreComites.Add(committeeMember);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(MembreComite committeeMember)
        {
            _context.MembreComites.Update(committeeMember);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var committeeMember = await _context.MembreComites.FindAsync(id);
            if (committeeMember != null)
            {
                _context.MembreComites.Remove(committeeMember);
                await _context.SaveChangesAsync();
            }
        }
    }
}
