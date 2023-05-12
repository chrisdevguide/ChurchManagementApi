using ChurchManagementApi.Models;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public interface IChurchUserRepository
    {
        Task AddChurchUser(ChurchUser churchUser);
        Task<bool> ChurchUserExist(string username);
        Task<ChurchUser> GetChurchUser(Guid churchUserId, string username);
        Task<ChurchUser> GetChurchUser(string username);
        Task UpdateChurchUser(ChurchUser churchUser);
    }
}