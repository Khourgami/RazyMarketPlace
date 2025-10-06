namespace RazySoft.MarketSync.AdminWeb.Services.Models
{
    public class SyncStatus
    {
        public bool IsRunning { get; set; }
        public DateTime? LastRun { get; set; }
        public bool LastRunSuccess { get; set; }
    }
}
