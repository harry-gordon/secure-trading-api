namespace SecureTradingApi.Enums
{
    public enum RequestTypeDescriptionEnum
    {
        Invalid, // Default value, should never occur
        TRANSACTIONQUERY,
        TRANSACTIONUPDATE,
        AUTH,
        REFUND,
        ORDER,
        ORDERDETAILS,
        ERROR,
        CACHETOKENISE,
        THREEDQUERY
    }
}
