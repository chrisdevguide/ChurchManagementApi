using ChurchManagementApi.Models;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public interface IMemberRepository
    {
        Task AddMember(Member member);
        Task DeleteMember(Member member);
        Task<Member> GetMember(Guid churchUserId, Guid memberId);
        Task<List<Member>> GetMembers(Guid churchUserId);
        Task<List<Member>> GetMembers(Guid churchUserId, List<Guid> memberIds);
        Task<List<Member>> GetMembers(List<Guid> memberIds);
        Task<bool> MemberExists(Guid churchUserId, Guid memberId);
        Task UpdateMember(Member member);
    }
}