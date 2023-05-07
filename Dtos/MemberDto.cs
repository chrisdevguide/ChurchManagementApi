using ChurchManagementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ChurchManagementApi.Dtos
{
    public class MemberDto
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public Nationality Nationality { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        public MaritalStatus MaritalStatus { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Required]
        public bool IsWaterBaptized { get; set; }
        public DateOnly? BaptismDate { get; set; }
    }
}