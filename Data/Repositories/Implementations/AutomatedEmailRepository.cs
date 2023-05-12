using ChurchManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchManagementApi.Data.Repositories.Implementations
{
    public class AutomatedEmailRepository : IAutomatedEmailRepository
    {
        private readonly DataContext _dataContext;

        public AutomatedEmailRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<List<AutomatedEmail>> GetAutomatedEmails(Guid churchUserId)
        {
            return await _dataContext.AutomatedEmails
                .Where(x => x.ChurchUserId == churchUserId)
                .ToListAsync();
        }

        public async Task<List<AutomatedEmail>> GetAutomatedEmailsToSend()
        {
            return await _dataContext.AutomatedEmails
                .Include(x => x.ChurchUser)
                .Where(x => DateTime.Now > x.SendingDate.AddHours(-2) && !x.Sent)
                .ToListAsync();
        }

        public async Task<AutomatedEmail> GetAutomatedEmail(Guid churchUserId, Guid automatedEmailId)
        {
            return await _dataContext.AutomatedEmails
                .SingleOrDefaultAsync(x => x.Id == automatedEmailId && x.ChurchUserId == churchUserId);
        }

        public async Task<bool> AutomatedEmailExists(Guid churchUserId, Guid automatedEmailId)
        {
            return await _dataContext.AutomatedEmails
                .AnyAsync(x => x.Id == automatedEmailId && x.ChurchUserId == churchUserId);
        }

        public async Task AddAutomatedEmail(AutomatedEmail automatedEmail)
        {
            _dataContext.AutomatedEmails.Add(automatedEmail);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAutomatedEmail(AutomatedEmail automatedEmail)
        {
            _dataContext.AutomatedEmails.Update(automatedEmail);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAutomatedEmails(List<AutomatedEmail> automatedEmails)
        {
            _dataContext.AutomatedEmails.UpdateRange(automatedEmails);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAutomatedEmail(AutomatedEmail automatedEmail)
        {
            _dataContext.AutomatedEmails.Remove(automatedEmail);
            await _dataContext.SaveChangesAsync();
        }

    }
}
