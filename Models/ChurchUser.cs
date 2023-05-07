namespace ChurchManagementApi.Models
{
    public class ChurchUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string ChurchName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
