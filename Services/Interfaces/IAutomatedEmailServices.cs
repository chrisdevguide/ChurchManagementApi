using ChurchManagementApi.Models;

namespace ChurchManagementApi.Services.Implementations
{
    public interface IAutomatedEmailServices
    {
        Task AddAutomatedEmail(Guid churchUserId, AutomatedEmailDto request);
        Task DeleteAutomatedEmail(Guid churchUserId, Guid automatedEmailId);
        Task<AutomatedEmail> GetAutomatedEmail(Guid churchUserId, Guid automatedEmailId);
        Task<List<AutomatedEmail>> GetAutomatedEmails(Guid churchUserId);
        Task SendAutomatedEmails();
        Task UpdateAutomatedEmail(Guid churchUserId, AutomatedEmailDto request);
    }
}