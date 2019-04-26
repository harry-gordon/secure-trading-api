using Newtonsoft.Json;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class TransactionQueryRequest : BaseRequest<TransactionQueryRequest.InnerRequest>
    {
        public class InnerRequest : BaseInnerRequest
        {
            public Filter Filter { get; set; }
        }

        public class Filter
        {
            [JsonProperty("sitereference")]
            public ValueWrapper[] SiteReference { get; set; }
            [JsonProperty("currencyiso3a")]
            public ValueWrapper[] CurrencyIso3a { get; set; }
            [JsonProperty("transactionreference")]
            public ValueWrapper[] TransactionReference { get; set; }
        }
    }
}
