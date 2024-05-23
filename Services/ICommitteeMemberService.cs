using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public interface ICommitteeMemberService
{
    Task<List<CommitteeMember>> GetCommitteeMembersAsync();
    Task<CommitteeMember> GetCommitteeMemberByIdAsync(int id);
    Task AddCommitteeMemberAsync(CommitteeMember CommitteeMember);
    Task UpdateCommitteeMemberAsync(CommitteeMember CommitteeMember);
    Task DeleteCommitteeMemberAsync(int id);
}

}
