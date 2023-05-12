using ChurchManagementApi.Dtos;

namespace ChurchManagementApi.Services.Implementations
{
    public interface IIdentityServices
    {
        Task ResetPassword(string email);
        Task<ChurchUserDto> SignIn(SignInRequestDto request);
        Task<ChurchUserDto> SignUp(SignUpRequestDto request);
        Task UpdateChurchUser(Guid churchUserId, UpdateChurchUserRequestDto request);
    }
}