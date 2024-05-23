using blazor_gestconf.Services;

namespace blazor_gestconf.Models
{
    public class CommitteeMember : User
    {
        private readonly ICommitteeMemberService _committeeMemberService;

        public CommitteeMember(ICommitteeMemberService committeeMemberService)
        {
            _committeeMemberService = committeeMemberService;
        }
    }
}
