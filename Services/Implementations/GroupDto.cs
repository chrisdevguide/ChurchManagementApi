using System.ComponentModel.DataAnnotations;

namespace ChurchManagementApi.Services.Implementations
{
    public class GroupDto
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Guid> MemberIds { get; set; }
    }
}