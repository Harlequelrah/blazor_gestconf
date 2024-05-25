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

        public override async Task AddAsync(CommitteeMember entity)
        {
            _context.CommitteeMembers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(CommitteeMember entity)
        {
            _context.CommitteeMembers.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await _context.CommitteeMembers.FindAsync(id);
            if (entity != null)
            {
                _context.CommitteeMembers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
