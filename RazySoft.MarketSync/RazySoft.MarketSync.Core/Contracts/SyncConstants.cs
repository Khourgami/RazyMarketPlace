namespace RazySoft.MarketSync.Core.Contracts
{
    public static class SyncConstants
    {
        public const string EntityInvoice = "Invoice";
        public const string EntityParty = "Party";
        public const string EntityProduct = "Product";

        public const string StatusSuccess = "Success";
        public const string StatusFailed = "Failed";
        public const string StatusPending = "Pending";

        public const string ConfigKeySellerId = "SellerId";
        public const string ConfigKeyLastSyncTime = "LastSyncTime";

        // Default values
        public static readonly string DefaultSellerId = "00000000-0000-0000-0000-000000000000";
    }
}
