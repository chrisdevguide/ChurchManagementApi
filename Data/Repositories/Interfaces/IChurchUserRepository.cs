using ChurchManagementApi.Models;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public interface IChurchUserRepository
    {
        Task AddChurchUser(ChurchUser churchUser);
        Task<bool> ChurchUserExist(string email);
        Task<ChurchUser> GetChurchUser(string email);
        Task UpdateChurchUser(ChurchUser churchUser);
    }
}