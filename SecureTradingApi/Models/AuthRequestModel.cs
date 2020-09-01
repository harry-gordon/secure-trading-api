using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SecureTradingApi.Enums;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class AuthRequestModel : BaseInnerRequest
    {
        public AuthRequestModel() : base(RequestTypeDescriptionEnum.AUTH)
        {
        }

        [JsonProperty("accounttypedescription")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountTypeDescription AccountTypeDescription => AccountTypeDescription.ECOM;

        [JsonProperty("currencyiso3a")]
        public string Currency { get; set; }

        [JsonProperty("baseamount")]
        public string BaseAmount { get; set; }

        [JsonProperty("orderreference")]
        public string OrderReference { get; set; }

        [JsonProperty("sitereference")]
        public string SiteReference { get; set; }
        
        [JsonProperty("pan")]
        public string PAN { get; set; }
        
        [JsonProperty("expirydate")]
        public string Expiry { get; set; }
        
        [JsonProperty("securitycode")]
        public string CVV { get; set; }
    }
}