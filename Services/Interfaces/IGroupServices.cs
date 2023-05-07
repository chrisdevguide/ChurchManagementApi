using ChurchManagementApi.Models;

namespace ChurchManagementApi.Services.Implementations
{
    public interface IGroupServices
    {
        Task AddGroup(Guid churchUserId, GroupDto request);
        Task DeleteGroup(Guid churchUserId, Guid groupId);
        Task<List<Group>> GetGroups(Guid churchUserId);
        Task UpdateGroup(Guid churchUserId, GroupDto request);
    }
}