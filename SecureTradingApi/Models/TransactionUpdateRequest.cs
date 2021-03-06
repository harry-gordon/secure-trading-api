﻿using SecureTradingApi.Enums;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class TransactionUpdateRequest : BaseInnerRequest
    {
        public TransactionUpdateRequest() : base(RequestTypeDescription.TRANSACTIONUPDATE)
        {
        }

        public TransactionUpdateFilter Filter { get; set; }
        public TransactionUpdate Updates { get; set; }
    }
}
