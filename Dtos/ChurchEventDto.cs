namespace ChurchManagementApi.Dtos
{
    public class ChurchEventDto
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public List<string> Participants { get; set; }
    }
}