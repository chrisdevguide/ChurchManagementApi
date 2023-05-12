using ChurchManagementApi.Dtos;
using ChurchManagementApi.Extentions;
using ChurchManagementApi.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChurchManagementApi.Controllers
{
    public class IdentityController : BaseController
    {
        private readonly IIdentityServices _identityServices;

        public IdentityController(IIdentityServices identityServices)
        {
            _identityServices = identityServices;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ChurchUserDto>> SignUp(SignUpRequestDto request)
        {
            return Ok(await _identityServices.SignUp(request));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ChurchUserDto>> SignIn(SignInRequestDto request)
        {
            return Ok(await _identityServices.SignIn(request));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateChurchUser(UpdateChurchUserRequestDto request)
        {
            await _identityServices.UpdateChurchUser(User.GetChurchUserId(), request);
            return Ok();
        }

    }
}
