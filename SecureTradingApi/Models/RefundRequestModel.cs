﻿using Newtonsoft.Json;
using SecureTradingApi.Enums;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class RefundRequestModel : BaseInnerRequest
    {
        public RefundRequestModel() : base(RequestTypeDescriptionEnum.REFUND)
        {
        }
        
        [JsonProperty("parenttransactionreference")]
        public string ParentTransactionReference { get; set; }

        [JsonProperty("sitereference")]
        public string SiteReference { get; set; }

        [JsonProperty("baseamount")]
        public string BaseAmount { get; set; }

        [JsonProperty("currencyiso3a")]
        public string CurrencyIso3a { get; set; }

        [JsonProperty("cachetoken")]
        public string CacheToken { get; set; }

        [JsonProperty("orderreference")]
        public string OrderReference { get; set; }

        [JsonProperty("chargedescription")]
        public string ChargeDescription { get; set; }
    }
}