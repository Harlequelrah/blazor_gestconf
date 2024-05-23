using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
public class CommitteeMemberService : ICommitteeMemberService
{
    private readonly AppDbContext _context;

    public CommitteeMemberService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CommitteeMember>> GetCommitteeMembersAsync()
    {
        return await _context.CommitteeMembers.ToListAsync();
    }

    public async Task<CommitteeMember> GetCommitteeMemberByIdAsync(int id)
    {
        return await _context.CommitteeMembers.FindAsync(id);
    }

    public async Task AddCommitteeMemberAsync(CommitteeMember CommitteeMember)
    {
        _context.CommitteeMembers.Add(CommitteeMember);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCommitteeMemberAsync(CommitteeMember CommitteeMember)
    {
        _context.CommitteeMembers.Update(CommitteeMember);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCommitteeMemberAsync(int id)
    {
        var CommitteeMember = await _context.CommitteeMembers.FindAsync(id);
        if (CommitteeMember != null)
        {
            _context.CommitteeMembers.Remove(CommitteeMember);
            await _context.SaveChangesAsync();
        }
    }
}


}
