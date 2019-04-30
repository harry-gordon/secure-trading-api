namespace SecureTradingApi.Enums
{
    public enum RequestTypeDescription
    {
        Invalid, // Default value, should never occur
        TRANSACTIONQUERY,
        TRANSACTIONUPDATE,
        AUTH,
        REFUND,
        ORDER,
        ORDERDETAILS,
        ERROR
    }
}
