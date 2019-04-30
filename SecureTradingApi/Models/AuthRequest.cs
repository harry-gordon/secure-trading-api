using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SecureTradingApi.Enums;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class AuthRequest : BaseInnerRequest
    {
        public AuthRequest() : base(RequestTypeDescription.AUTH)
        {
        }

        [JsonProperty("accounttypedescription")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountTypeDescription AccountTypeDescription => AccountTypeDescription.ECOM;

        [JsonProperty("currencyiso3a")]
        public string CurrencyIso3a { get; set; }

        [JsonProperty("baseamount")]
        public string BaseAmount { get; set; }

        [JsonProperty("orderreference")]
        public string OrderReference { get; set; }

        [JsonProperty("cachetoken")]
        public string CacheToken { get; set; }

        [JsonProperty("sitereference")]
        public string SiteReference { get; set; }

        [JsonProperty("parenttransactionreference")]
        public string ParentTransactionReference { get; set; }

        [JsonProperty("authmethod")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AuthMethod AuthMethod { get; set; }

        [JsonProperty("initiationreason")]
        public string InitiationReason { get; set; }

        [JsonIgnore]
        public CredentialsOnFile CredentialsOnFile { get; set; }
        [JsonProperty("credentialsonfile")]
        private string _credentialsOnFile => ((int)CredentialsOnFile).ToString();
    }
}
