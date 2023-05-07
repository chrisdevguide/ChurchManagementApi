using ChurchManagementApi.Models;

namespace ChurchManagementApi.Services.Interfaces
{
    public interface IEmailServices
    {
        void SendEmail(AutomatedEmail email, List<string> recipients);
    }
}