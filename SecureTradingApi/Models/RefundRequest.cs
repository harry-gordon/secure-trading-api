using Newtonsoft.Json;
using SecureTradingApi.Enums;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class RefundRequest : BaseInnerRequest
    {
        public RefundRequest() : base(RequestTypeDescription.REFUND)
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

        [JsonIgnore]
        public CredentialsOnFile CredentialsOnFile { get; set; }
        [JsonProperty("credentialsonfile")]
        private string _credentialsOnFile => ((int)CredentialsOnFile).ToString();
    }
}
