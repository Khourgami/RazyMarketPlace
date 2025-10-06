namespace RazySoft.MarketSync.Service.Api
{
    public class SyncStatus
    {
        public bool IsRunning { get; set; }
        public DateTime LastRun { get; set; }
        public bool LastRunSuccess { get; set; }
    }

}
