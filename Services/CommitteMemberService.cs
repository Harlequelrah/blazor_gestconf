using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public class CommitteeMemberService : GenericCrudService<CommitteeMember>
    {
        public CommitteeMemberService(AppDbContext context) : base(context)
        {
        }

        public override async Task<List<CommitteeMember>> GetAllAsync()
        {
            return await _context.CommitteeMembers.ToListAsync();
        }

        public override async Task<CommitteeMember> GetByIdAsync(int id)
        {
            return await _context.CommitteeMembers.FindAsync(id);
        }

        public override async Task AddAsync(CommitteeMember committeeMember)
        {
            _context.CommitteeMembers.Add(committeeMember);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(CommitteeMember committeeMember)
        {
            _context.CommitteeMembers.Update(committeeMember);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var committeeMember = await _context.CommitteeMembers.FindAsync(id);
            if (committeeMember != null)
            {
                _context.CommitteeMembers.Remove(committeeMember);
                await _context.SaveChangesAsync();
            }
        }
    }
}
