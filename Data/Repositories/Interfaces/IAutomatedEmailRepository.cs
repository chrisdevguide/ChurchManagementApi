using ChurchManagementApi.Models;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public interface IAutomatedEmailRepository
    {
        Task AddAutomatedEmail(AutomatedEmail automatedEmail);
        Task<bool> AutomatedEmailExists(Guid churchUserId, Guid automatedEmailId);
        Task DeleteAutomatedEmail(AutomatedEmail automatedEmail);
        Task<AutomatedEmail> GetAutomatedEmail(Guid churchUserId, Guid automatedEmailId);
        Task<List<AutomatedEmail>> GetAutomatedEmails(Guid churchUserId);
        Task<List<AutomatedEmail>> GetAutomatedEmailsToSend();
        Task UpdateAutomatedEmail(AutomatedEmail automatedEmail);
        Task UpdateAutomatedEmails(List<AutomatedEmail> automatedEmails);
    }
}