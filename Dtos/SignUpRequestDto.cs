using System.ComponentModel.DataAnnotations;

namespace ChurchManagementApi.Dtos
{
    public class SignUpRequestDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string ChurchName { get; set; }
    }
}