using ChurchManagementApi.Dtos;
using ChurchManagementApi.Models;

namespace ChurchManagementApi.Services.Interfaces
{
    public interface IChurchEventServices
    {
        Task AddChurchEvent(Guid churchUserId, ChurchEventDto request);
        Task DeleteChurchEvent(Guid churchUserId, Guid ChurchEventId);
        Task<ChurchEvent> GetChurchEvent(Guid churchUserId, Guid ChurchEventId);
        Task<List<ChurchEvent>> GetChurchEvents(Guid churchUserId);
        Task UpdateChurchEvent(Guid churchUserId, ChurchEventDto request);
    }
}