using System;
using Newtonsoft.Json;
using SecureTradingApi.Enums;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class TransactionQueryRequest : BaseInnerRequest
    {
        public TransactionQueryFilter Filter { get; set; }

        public TransactionQueryRequest() : base(RequestTypeDescription.TRANSACTIONQUERY)
        {
        }
    }
}
