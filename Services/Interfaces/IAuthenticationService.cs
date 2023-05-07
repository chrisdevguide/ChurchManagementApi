using ChurchManagementApi.Models;

namespace ChurchManagementApi.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateAuthenticationToken(ChurchUser churchUser);
    }
}