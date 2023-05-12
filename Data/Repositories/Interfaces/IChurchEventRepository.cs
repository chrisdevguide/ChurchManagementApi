using ChurchManagementApi.Models;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public interface IChurchEventRepository
    {
        Task AddChurchEvent(ChurchEvent ChurchEvent);
        Task<bool> ChurchEventExists(Guid churchUserId, Guid ChurchEventId);
        Task DeleteChurchEvent(ChurchEvent ChurchEvent);
        Task<ChurchEvent> GetChurchEvent(Guid ChurchEventId);
        Task<ChurchEvent> GetChurchEvent(Guid churchUserId, Guid ChurchEventId);
        Task<List<ChurchEvent>> GetChurchEvents(Guid churchUserId);
        Task UpdateChurchEvent(ChurchEvent ChurchEvent);
        Task UpdateChurchEvents(List<ChurchEvent> ChurchEvents);
    }
}