namespace IMS.Models
{
    public class RCA
    {
        public int Id { get; set; }
        public int WorkItemId { get; set; }
        public string RootCause { get; set; }
        public string Fix { get; set; }
        public string Prevention { get; set; }
    }
}
