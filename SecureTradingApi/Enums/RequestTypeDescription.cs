namespace SecureTradingApi.Enums
{
    public enum RequestTypeDescription
    {
        Invalid, // Default value, should never occur
        TRANSACTIONQUERY,
        AUTH,
        REFUND,
        ERROR
    }
}
