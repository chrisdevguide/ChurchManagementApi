using AutoMapper;
using ChurchManagementApi.Data.Repositories.Implementations;
using ChurchManagementApi.Dtos;
using ChurchManagementApi.Models;
using ChurchManagementApi.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ChurchManagementApi.Services.Implementations
{
    public class IdentityServices : IIdentityServices
    {
        private readonly IChurchUserRepository _churchUserRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public IdentityServices(IChurchUserRepository churchUserRepository, IAuthenticationService authenticationService, IMapper mapper)
        {
            _churchUserRepository = churchUserRepository;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<ChurchUserDto> SignUp(SignUpRequestDto request)
        {
            if (await _churchUserRepository.ChurchUserExist(request.Email)) throw new ApiException("El usuario ya existe.");

            ChurchUser churchUser = _mapper.Map<ChurchUser>(request);

            using HMACSHA512 hmac = new();

            churchUser.PasswordHash = HashPassword(hmac, request.Password);
            churchUser.PasswordSalt = hmac.Key;

            await _churchUserRepository.AddChurchUser(churchUser);

            return new()
            {
                Id = churchUser.Id,
                Username = churchUser.Username,
                ChurchName = churchUser.ChurchName,
                Token = _authenticationService.GenerateAuthenticationToken(churchUser)
            };
        }

        public async Task<ChurchUserDto> SignIn(SignInRequestDto request)
        {
            ChurchUser churchUser = await _churchUserRepository.GetChurchUser(request.Email) ?? throw new ApiException("El usuario no existe.");

            using HMACSHA512 hmac = new(churchUser.PasswordSalt);

            if (!HashPassword(hmac, request.Password).SequenceEqual(churchUser.PasswordHash)) throw new ApiException("La contraseña es incorrecta.");

            return new()
            {
                Id = churchUser.Id,
                Username = churchUser.Username,
                ChurchName = churchUser.ChurchName,
                Token = _authenticationService.GenerateAuthenticationToken(churchUser)
            };
        }

        public async Task ResetPassword(string email)
        {
            ChurchUser churchUser = await _churchUserRepository.GetChurchUser(email);
            if (churchUser == null) return;

            string newPassword = GenerateRandomPassword();

            using HMACSHA512 hmac = new();

            churchUser.PasswordHash = HashPassword(hmac, newPassword);
            churchUser.PasswordSalt = hmac.Key;

            //await _churchUserRepository.UpdateChurchUser(churchUser);
        }

        private byte[] HashPassword(HMACSHA512 hmac, string password)
        {
            return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private static string GenerateRandomPassword()
        {
            Random random = new();
            random.NextBytes(new byte[16]);
            return random.ToString();
        }

    }
}
