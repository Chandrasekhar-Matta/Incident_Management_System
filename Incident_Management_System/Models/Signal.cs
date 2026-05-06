namespace IMS.Models
{
    public class Signal
    {
        public string ComponentId { get; set; }
        public string Payload { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
