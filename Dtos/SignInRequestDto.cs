using System.ComponentModel.DataAnnotations;

namespace ChurchManagementApi.Dtos
{
    public class SignInRequestDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
    }
}