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

    public class TransactionQueryFilter
    {
        [JsonProperty("sitereference")]
        public ValueWrapper[] SiteReference { get; set; }
        [JsonProperty("currencyiso3a")]
        public ValueWrapper[] CurrencyIso3a { get; set; }
        [JsonProperty("transactionreference")]
        public ValueWrapper[] TransactionReference { get; set; }
    }
}
