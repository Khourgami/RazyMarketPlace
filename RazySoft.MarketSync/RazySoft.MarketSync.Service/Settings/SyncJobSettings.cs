namespace RazySoft.MarketSync.Service.Settings
{
    public class SyncJobSettings
    {
        public string CronExpression { get; set; } = "0 0 2 * * ?";
        public int RetryCount { get; set; } = 3;
        public int RetryIntervalMinutes { get; set; } = 30;
    }
}
