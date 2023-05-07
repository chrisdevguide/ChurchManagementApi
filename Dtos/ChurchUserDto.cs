namespace ChurchManagementApi.Dtos
{
    public class ChurchUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string ChurchName { get; set; }
        public string Token { get; set; }
    }
}
