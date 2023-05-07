using System.ComponentModel.DataAnnotations;

namespace ChurchManagementApi.Services.Implementations
{
    public class AutomatedEmailDto
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime SendingDate { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public List<Guid> Recipients { get; set; }
    }
}