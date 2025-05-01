namespace Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
    }
}
