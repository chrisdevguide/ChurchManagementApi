using ChurchManagementApi.Dtos;
using ChurchManagementApi.Models;

namespace ChurchManagementApi.Services.Implementations
{
    public interface IMemberServices
    {
        Task AddMember(Guid churchUserId, MemberDto request);
        Task ArchiveMember(Guid churchUserId, Guid memberId, bool isArchived);
        Task DeleteMember(Guid churchUserId, Guid memberId);
        Task<List<Member>> GetMembers(Guid churchUserId);
        Task UpdateMember(Guid churchUserId, MemberDto request);
    }
}