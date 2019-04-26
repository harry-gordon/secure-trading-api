namespace SecureTradingApi.Enums
{
    public enum SettleStatus
    {
        Pending = 0,
        PendingManual = 1,
        Suspended = 2,
        Cancelled = 3,
        Settling = 10,
        Settled = 100
    }
}
