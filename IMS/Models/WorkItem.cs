namespace IMS.Models
{
    public class WorkItem
    {
        public int Id { get; set; }
        public string ComponentId { get; set; }
        public string Status { get; set; } = "OPEN";
        public string Severity { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime? EndTime { get; set; }
    }
}
