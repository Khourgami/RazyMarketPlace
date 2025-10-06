namespace RazySoft.MarketSync.Domain.Entities
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime RunDateTime { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public int RecordsAttempted { get; set; }
        public int RecordsSucceeded { get; set; }
        public int RecordsFailed { get; set; }
        public string Status { get; set; } = "Pending";
        public string? ErrorMessage { get; set; }
    }
}
