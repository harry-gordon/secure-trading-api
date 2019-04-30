using System;
using Newtonsoft.Json;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Models
{
    public class CacheTokeniseResponse : BaseInnerResponse
    {
        [JsonProperty("paymenttypedescription")]
        public string PaymentTypeDescription { get; set; }
        [JsonProperty("sitereference")]
        public string SiteReference { get; set; }
        [JsonProperty("maskedPan")]
        public string MaskedCardNumber { get; set; }
        [JsonProperty("datacenterurl")]
        public string DataCenterUrl { get; set; }
        [JsonProperty("cacheToken")]
        public string CacheToken { get; set; }
        [JsonProperty("issuercountryiso2a")]
        public string IssuerCountryIso2a { get; set; }
        [JsonProperty("issuer")]
        public string Issuer { get; set; }
    }
}
